using CRUD.Application.Features.Users.Users.Commands.InativeUsers;
using CRUD.Infrastructure.Persistence;
using FluentValidation.TestHelper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CRUD.Test.Tests.Features.Users.Users.InativeUsers
{
    public class InativeUserCommandHandler
    {
        private readonly Context _context;
        private readonly IMediator _mediator;
        private readonly InativeUserCommandValidator _validator;

        public InativeUserCommandHandler(Context context, IMediator mediator)
        {
            _validator = new InativeUserCommandValidator(context);
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Theory]
        [MemberData(nameof(InativeUserCommandData.IdValidation), MemberType = typeof(InativeUserCommandData))]
        public void InativeUser_InvalidValuesForId_ReturnError(InativeUserCommand command)
        {
            var resultado = _validator.TestValidate(command);
            resultado.ShouldHaveValidationErrorFor(c => c.Id);
        }

        [Fact]
        public async Task InativeUser_ValidId_ReturnSuccess()
        {
            var user = await _context.Users.FirstAsync(u => !u.Deleted && u.Activated && u.Addresses.Any(a => !a.Deleted && !a.Deleted));

            await _mediator.Send(new InativeUserCommand() { Id = user.Id });

            Assert.False(user.Deleted);
            Assert.False(user.Activated);
            user.Addresses.ToList().ForEach(a =>
            {
                Assert.False(a.Deleted);
                Assert.False(a.Activated);
            });
        }
    }
}
