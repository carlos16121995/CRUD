using Bogus;
using CRUD.Application.Features.Users.Users.Commands.InsertUsers;
using CRUD.Application.Features.Users.Users.Commands.UpdateUsers;
using CRUD.Domain.Enums;
using CRUD.Infrastructure.Persistence;
using FluentValidation.TestHelper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CRUD.Test.Tests.Features.Users.Users.UpdateUsers
{
    public class UpdateUserCommandHandler
    {
        private readonly Context _context;
        private readonly IMediator _mediator;
        private readonly UpdateUserCommandValidator _validator;

        public UpdateUserCommandHandler(Context context, IMediator mediator)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _validator = new UpdateUserCommandValidator(context);
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Theory]
        [MemberData(nameof(UpdateUserCommandData.NameValidation), MemberType = typeof(UpdateUserCommandData))]
        public void UpdateUser_InvalidValuesForName_ReturnError(UpdateUserCommand command)
        {
            var resultado = _validator.TestValidate(command);
            resultado.ShouldHaveValidationErrorFor(c => c.Data.Name);
        }

        [Theory]
        [MemberData(nameof(UpdateUserCommandData.IdValidation), MemberType = typeof(UpdateUserCommandData))]
        public void UpdateUser_InvalidValuesForId_ReturnError(UpdateUserCommand command)
        {
            var resultado = _validator.TestValidate(command);
            resultado.ShouldHaveValidationErrorFor(c => c.Id);
        }

        [Fact]
        public void UpdateUser_InvalidValuesForGender_ReturnError()
        {
            var resultado = _validator.TestValidate(new()
            {
                Data = new()
                {
                    Gender = 0
                }
            });
            resultado.ShouldHaveValidationErrorFor(c => c.Data.Gender);
        }

        [Fact]
        public void UpdateUser_InvalidValuesForBirthDate_ReturnError()
        {
            var resultado = _validator.TestValidate(new()
            {
                Data = new()
                {
                    BirthDate = DateTime.UtcNow.Date.AddDays(1)
                }
            });
            resultado.ShouldHaveValidationErrorFor(c => c.Data.BirthDate);
        }

        [Fact]
        public async Task UpdateUser_UserValidValues_ReturnSuccess()
        {
            var user = await _context.Users.FirstAsync(u => !u.Deleted && u.Activated);

            var newUser = new UpdateUserCommand()
            {
                Id = user.Id,
                Data = new Faker<InsertUserCommand>()
                .RuleFor((p) => p.Name, (f) => f.Person.FullName)
                .RuleFor((p) => p.BirthDate, (f) => f.Person.DateOfBirth)
                .RuleFor((p) => p.Gender, f => f.Random.Enum<EGender>())
                .RuleFor((p) => p.Activated, !user.Activated)
                .Generate()
            };

            await _mediator.Send(newUser);
            
            Assert.Equal(newUser.Data.Name, user.Name);
            Assert.Equal(newUser.Data.BirthDate, user.BirthDate);
            Assert.Equal(newUser.Data.Gender, user.Gender);
            Assert.Equal(newUser.Data.Activated, user.Activated);
        }
    }
}
