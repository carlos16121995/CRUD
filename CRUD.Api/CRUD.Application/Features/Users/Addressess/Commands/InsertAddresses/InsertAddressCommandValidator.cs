using CRUD.Infrastructure.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CRUD.Application.Features.Users.Addressess.Commands.InsertAddresses
{
    /// <summary>
    /// 
    /// </summary>
    public class InsertAddressCommandValidator : AbstractValidator<InsertAddressCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public InsertAddressCommandValidator(Context context)
        {
            RuleFor(a => a.UserId)
                .Must(id => context.Users.Any(u => !u.Deleted && u.Activated && u.Id.Equals(id)))
                .WithMessage(a => $"O usuário {a.UserId} não é elegível para esta ação.");

            RuleFor(a => a.Data)
                .SetValidator(new InsertAddressValidator(context));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class InsertAddressValidator : AbstractValidator<InsertAddress>
    {
        /// <summary>
        /// 
        /// </summary>
        public InsertAddressValidator(Context context)
        {
            RuleFor(a => a.CityId)
                .Must(id => context.Cities.Any(c => !c.Deleted && c.Activated && c.Id.Equals(id)))
                .WithMessage(a => $"A cidade {a.CityId} não é elegível para esta ação.");

            RuleFor(a => a.ZipCode)
                .NotEmpty()
                .MaximumLength(8)
                .Must((value) => value == null || !Regex.Match(value, @"[^0-9]").Success)
                .WithMessage((c) => $"O cep '{c.ZipCode}'deve conter apenas números.");

            RuleFor(d => d.AddressType)
                .IsInEnum();

            RuleFor(d => d.Neighborhood)
                .NotEmpty()
                .MaximumLength(60);

            RuleFor(d => d.Street)
                .NotEmpty()
                .MaximumLength(60);

            RuleFor(d => d.Number)
                .NotEmpty()
                .MaximumLength(60);

            RuleFor(d => d.Complement)
                .MaximumLength(60);
        }
    }
}
