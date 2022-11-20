using CRUD.Application.Features.Users.Users.Commands.InsertUsers;
using CRUD.Infrastructure.Persistence;
using FluentValidation.TestHelper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CRUD.Test.Tests.Features.Users.Users.InsertUsers
{
    public class InsertUserCommandHandler
    {
        private readonly Context _context;
        private readonly IMediator _mediator;
        private readonly InsertUserCommandValidator _validator;

        public InsertUserCommandHandler(Context context, IMediator mediator)
        {
            _validator = new InsertUserCommandValidator();
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Theory]
        [MemberData(nameof(InsertUserCommandData.NameValidation), MemberType = typeof(InsertUserCommandData))]
        public void InsertUser_InvalidValuesForName_ReturnError(InsertUserCommand command)
        {
            var resultado = _validator.TestValidate(command);
            resultado.ShouldHaveValidationErrorFor(c => c.Name);
        }

        [Fact]
        public void InsertUser_InvalidValuesForGender_ReturnError()
        {
            var resultado = _validator.TestValidate(new()
            {
                Gender = 0
            });
            resultado.ShouldHaveValidationErrorFor(c => c.Gender);
        }

        [Fact]
        public void InsertUser_InvalidValuesForBirthDate_ReturnError()
        {
            var resultado = _validator.TestValidate(new()
            {
                BirthDate = DateTime.UtcNow.Date.AddDays(1)
            });
            resultado.ShouldHaveValidationErrorFor(c => c.BirthDate);
        }

        [Theory]
        [MemberData(nameof(InsertUserCommandData.UserValidValues), MemberType = typeof(InsertUserCommandData))]
        public async Task InsertUser_UserValidValues_ReturnSuccess(InsertUserCommand command)
        {
            var ret = await _mediator.Send(command);
            Assert.True(await _context.Users.AnyAsync(u => u.Id == ret.Id));
        }
    }
}
