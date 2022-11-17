using CRUD.Domain.Entities.Users.Addresses;
using CRUD.Infrastructure.Persistence;
using CRUD.Infrastructure.Repositories;
using MediatR;

namespace CRUD.Application.Features.Users.Addressess.Commands.InativeAddresses
{
    /// <summary>
    /// 
    /// </summary>
    public class InativeAddressCommandHandler : IRequestHandler<InativeAddressCommand>
    {
        private readonly Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public InativeAddressCommandHandler(Context context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Unit> Handle(InativeAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.GetDelete())
                    await _context.UpdateAsync<Address, Guid>((address) => address.Id.Equals(request.Id), (u) =>
                    {
                        u.Delete();
                    });

                else
                    await _context.UpdateAsync<Address, Guid>((address) => address.Id.Equals(request.Id), (u) =>
                    {
                        u.Inactivate();
                    });

                return Unit.Value;
            }
            catch (Exception ex) { throw new Exception(); } // TODO: Mensagens
        }
    }
}
