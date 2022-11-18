using CRUD.Infrastructure.Persistence;
using FluentValidation;

namespace CRUD.Application.Features.Users.Users.Commands.RemoveUsers
{
    /// <summary>
    /// 
    /// </summary>
    public class RemoveUserCommandValidator : AbstractValidator<RemoveUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public RemoveUserCommandValidator(Context context)
        {
            RuleFor(u => u.Id)
                .Must(id => context.Users.Any((u) => u.Id.Equals(id)))
                .WithMessage(user => $"O usuário {user.Id} não está elegível para essa ação");
        }
    }
}
