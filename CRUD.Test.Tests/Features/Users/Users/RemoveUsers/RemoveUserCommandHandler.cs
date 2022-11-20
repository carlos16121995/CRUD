using CRUD.Application.Features.Users.Users.Commands.InativeUsers;
using CRUD.Application.Features.Users.Users.Commands.RemoveUsers;
using CRUD.Infrastructure.Persistence;
using CRUD.Test.Tests.Features.Users.Users.InativeUsers;
using FluentValidation.TestHelper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CRUD.Test.Tests.Features.Users.Users.RemoveUsers
{
    public class RemoveUserCommandHandler
    {
        private readonly Context _context;
        private readonly IMediator _mediator;
        private readonly RemoveUserCommandValidator _validator;

        public RemoveUserCommandHandler(Context context, IMediator mediator)
        {
            _validator = new RemoveUserCommandValidator(context);
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Theory]
        [MemberData(nameof(RemoveUserCommandData.IdValidation), MemberType = typeof(RemoveUserCommandData))]
        public void RemoveUser_InvalidValuesForId_ReturnError(RemoveUserCommand command)
        {
            var resultado = _validator.TestValidate(command);
            resultado.ShouldHaveValidationErrorFor(c => c.Id);
        }

        [Fact]
        public async Task RemoveUser_ValidId_ReturnSuccess()
        {
            var userId = await _context.Users.Select(u => u.Id).FirstAsync();

            var addressId = await _context.Addresses.Where(a => a.UserId == userId).Select(u => u.Id).ToListAsync();

            await _mediator.Send(new RemoveUserCommand() { Id = userId });

            Assert.False(await _context.Users.AnyAsync(u => u.Id == userId));
            Assert.False(await _context.Addresses.AnyAsync(u => addressId.Contains(u.Id)));
        }
    }
}
