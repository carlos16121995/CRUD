using CRUD.Infrastructure.Persistence;
using CRUD.Infrastructure.Repositories;
using MediatR;

namespace CRUD.Application.Features.Users.Addressess.Commands.UpdateAddresses
{
    using CRUD.Domain.Entities.Users.Addresses;

    /// <summary>
    /// 
    /// </summary>
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UpdateAddressCommandHandler(Context context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Unit> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _context.UpdateAsync<Address, Guid>((address) => address.Id.Equals(request.AddressId), (a) =>
                {
                    a.CityId = request.Data.CityId;
                    a.ZipCode = request.Data.ZipCode;
                    a.AddressType = request.Data.AddressType;
                    a.Neighborhood = request.Data.Neighborhood;
                    a.Street = request.Data.Street;
                    a.Number = request.Data.Number;
                    a.Complement = request.Data.Complement;
                    a.UpdatedAt = DateTime.UtcNow;
                    if (request.Data.Activated != a.Activated)
                        a.Inactivate();
                });

                return Unit.Value;
            }
            catch (Exception ex) { throw new Exception(); } // TODO: Mensagens
        }
    }
}
