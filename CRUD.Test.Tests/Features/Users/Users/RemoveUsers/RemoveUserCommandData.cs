using CRUD.Application.Features.Users.Users.Commands.RemoveUsers;

namespace CRUD.Test.Tests.Features.Users.Users.RemoveUsers
{
    public static class RemoveUserCommandData
    {
        public static IEnumerable<object[]> IdValidation()
        {
            yield return new object[]
            {
                new RemoveUserCommand()
                {
                    Id = Guid.Empty,
                }
            };

            yield return new object[]
            {
                new RemoveUserCommand()
                {
                    Id = Guid.NewGuid(),
                }
            };
        }
    }
}
