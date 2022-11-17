using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Features.Users.Address.Commands.InsertAddress
{
    public class InsertAddressCommandHandler : IRequestHandler<InsertAddressCommand, InsertAddressCommandResponse>
    {
        public InsertAddressCommandHandler()
        {
        }

        public async Task<InsertAddressCommandResponse> Handle(InsertAddressCommand request, CancellationToken cancellationToken)
        {
			throw new NotImplementedException();
        }
    }
}
