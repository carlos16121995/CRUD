using CRUD.Application.Features.Users.Users.Commands.InsertUsers;
using CRUD.Infrastructure.Persistence;
using FluentValidation;

namespace CRUD.Application.Features.Users.Users.Commands.UpdateUsers
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UpdateUserCommandValidator(Context context)
        {
            RuleFor(u => u.Id)
                .Must(id => context.Users.Any((u) => !u.Deleted && u.Id.Equals(id)))
                .WithMessage(user => $"O usuário {user.Id} não está elegível para essa ação");

            RuleFor(u => u.Data)
                .SetValidator(new InsertUserCommandValidator());
        }
    }
}
