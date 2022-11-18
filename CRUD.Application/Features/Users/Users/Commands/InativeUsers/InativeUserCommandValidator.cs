using CRUD.Infrastructure.Persistence;
using FluentValidation;
using MediatR;

namespace CRUD.Application.Features.Users.Users.Commands.InativeUsers
{
    /// <summary>
    /// 
    /// </summary>
    public class InativeUserCommandValidator : AbstractValidator<InativeUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public InativeUserCommandValidator(Context context)
        {
            RuleFor(u => u.Id)
                .Must(id => context.Users.Any((u) => !u.Deleted && u.Activated && u.Id.Equals(id)))
                .WithMessage(user => $"O usuário {user.Id} não está elegível para essa ação");
        }
    }
}
