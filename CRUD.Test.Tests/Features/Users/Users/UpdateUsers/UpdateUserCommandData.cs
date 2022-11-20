using Bogus;
using CRUD.Application.Features.Users.Users.Commands.InsertUsers;
using CRUD.Application.Features.Users.Users.Commands.UpdateUsers;

namespace CRUD.Test.Tests.Features.Users.Users.UpdateUsers
{
    public static class UpdateUserCommandData
    {
        public static IEnumerable<object[]> NameValidation()
        {
            yield return new object[]
            {
                new UpdateUserCommand()
                {
                    Data = new Faker<InsertUserCommand>()
                    .RuleFor((p) => p.Name, (f) => f.Random.String2(65))
                    .Generate()
                }

            };

            yield return new object[]
            {
                new UpdateUserCommand()
                {
                    Data = new InsertUserCommand()
                    {
                        Name = "",
                    }
                }
            };

            yield return new object[]
            {
                new UpdateUserCommand()
                {
                    Data = new InsertUserCommand()
                    {
                        Name = "    ",
                    }
                }
            };
        }

        public static IEnumerable<object[]> IdValidation()
        {
            yield return new object[]
            {
                new UpdateUserCommand()
                {
                    Id = Guid.Empty,
                    Data = new()
                }

            };

            yield return new object[]
            {
                new UpdateUserCommand()
                {
                    Id = Guid.NewGuid(),
                    Data = new()
                }
            };
        }

    }
}

