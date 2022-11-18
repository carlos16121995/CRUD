using MediatR;

namespace CRUD.Application.Features.Users.Addresses.Commands.InsertAddresses
{
    using CRUD.Infrastructure.Persistence;
    using CRUD.Infrastructure.Repositories;
    using CRUD.Domain.Entities.Users.Addresses;
    using CRUD.Domain.Infra.Exceptions;

    /// <summary>
    /// 
    /// </summary>
    public class InsertAddressCommandHandler : IRequestHandler<InsertAddressCommand, InsertAddressCommandResponse>
    {
        private readonly Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public InsertAddressCommandHandler(Context context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<InsertAddressCommandResponse> Handle(InsertAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var id = await _context.InsertAsync<Address, Guid>(new Address()
                {
                    UserId = request.UserId,
                    CityId = request.Data.CityId,
                    ZipCode = request.Data.ZipCode,
                    AddressType = request.Data.AddressType,
                    Neighborhood = request.Data.Neighborhood,
                    Street = request.Data.Street,
                    Number = request.Data.Number,
                    Complement = request.Data.Complement,
                });

                return new()
                {
                    Id = id
                };
            }
            catch (Exception ex) { throw new CrudException("Falha ao inserir endereços.", ex); } 
        }
    }
}
