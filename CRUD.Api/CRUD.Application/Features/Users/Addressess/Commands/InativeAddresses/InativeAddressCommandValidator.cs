using CRUD.Infrastructure.Persistence;
using FluentValidation;

namespace CRUD.Application.Features.Users.Addressess.Commands.InativeAddresses
{
    /// <summary>
    /// 
    /// </summary>
    public class InativeAddressCommandValidator : AbstractValidator<InativeAddressCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public InativeAddressCommandValidator(Context context)
        {
            RuleFor(u => u.Id)
                .Must(id => context.Addresses.Any((u) => !u.Deleted && u.Activated && u.Id.Equals(id)))
                .WithMessage(user => $"O endereço {user.Id} não está elegível para essa ação");
        }
    }
}
