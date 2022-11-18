using CRUD.Application.Features.Users.Addresses.Commands.InsertAddresses;
using CRUD.Infrastructure.Persistence;
using FluentValidation;

namespace CRUD.Application.Features.Users.Addresses.Commands.UpdateAddresses
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UpdateAddressCommandValidator(Context context)
        {
            RuleFor(a => a.AddressId)
                .Must(id => context.Addresses.Any(u => !u.Deleted && u.Activated && u.Id.Equals(id)))
                .WithMessage(a => $"O endereço {a.AddressId} não é elegível para esta ação.");

            RuleFor(a => a.Data)
                .SetValidator(new InsertAddressValidator(context));
        }
    }
}
