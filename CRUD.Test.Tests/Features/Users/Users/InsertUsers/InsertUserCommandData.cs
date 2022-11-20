using Bogus;
using CRUD.Application.Features.Users.Users.Commands.InsertUsers;
using CRUD.Domain.Enums;

namespace CRUD.Test.Tests.Features.Users.Users.InsertUsers
{
    public static class InsertUserCommandData
    {
        public static IEnumerable<object[]> NameValidation()
        {
            yield return new object[]
            {
                new Faker<InsertUserCommand>()
                .RuleFor((p) => p.Name, (f) => f.Random.String2(65))
                .Generate()
            };

            yield return new object[]
            {
                new InsertUserCommand()
                {
                    Name = "",
                }
            };

            yield return new object[]
            {
                new InsertUserCommand()
                {
                    Name = "    ",
                }
            };
        }

        public static IEnumerable<object[]> UserValidValues()
        {
            yield return new object[]
            {
                new Faker<InsertUserCommand>()
                .RuleFor((p) => p.Name, (f) => f.Person.FullName)
                .RuleFor((p) => p.BirthDate, (f) => f.Person.DateOfBirth)
                .RuleFor((p) => p.Gender,  f => f.Random.Enum<EGender>())
                .RuleFor((p) => p.Activated,  true)
                .Generate()
            };

            yield return new object[]
            {
                new Faker<InsertUserCommand>()
                .RuleFor((p) => p.Name, (f) => f.Person.FullName)
                .RuleFor((p) => p.BirthDate, (f) => f.Person.DateOfBirth)
                .RuleFor((p) => p.Gender,  f => f.Random.Enum<EGender>())
                .RuleFor((p) => p.Activated,  false)
                .Generate()
            };

            yield return new object[]
            {
                new Faker<InsertUserCommand>()
                .RuleFor((p) => p.Name, (f) => f.Person.FullName)
                .RuleFor((p) => p.BirthDate, (f) => f.Person.DateOfBirth)
                .RuleFor((p) => p.Gender,  f => f.Random.Enum<EGender>())
                .Generate()
            };
        }
    }
}
