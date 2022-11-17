using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Features.Users.Address.Commands.InsertAddress
{
    public class InsertAddressCommandValidator : AbstractValidator<InsertAddressCommand>
    {
        public InsertAddressCommandValidator()
        {
        }
    }
}
