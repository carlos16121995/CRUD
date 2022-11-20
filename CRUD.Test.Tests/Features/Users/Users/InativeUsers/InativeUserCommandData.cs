using CRUD.Application.Features.Users.Users.Commands.InativeUsers;
using CRUD.Application.Features.Users.Users.Commands.UpdateUsers;

namespace CRUD.Test.Tests.Features.Users.Users.InativeUsers
{
    public static class InativeUserCommandData
    {
        public static IEnumerable<object[]> IdValidation()
        {
            yield return new object[]
            {
                new InativeUserCommand()
                {
                    Id = Guid.Empty,
                }
            };

            yield return new object[]
            {
                new InativeUserCommand()
                {
                    Id = Guid.NewGuid(),
                }
            };
        }
    }
}
