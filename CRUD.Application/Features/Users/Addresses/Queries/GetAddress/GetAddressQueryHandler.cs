using CRUD.Domain.Entities.Users.Addresses;
using CRUD.Domain.Infra.Exceptions;
using CRUD.Domain.Infra.Responses;
using CRUD.Infrastructure.Extensions;
using CRUD.Infrastructure.Persistence;
using MediatR;
using System.Linq.Expressions;

namespace CRUD.Application.Features.Users.Addresses.Queries.GetAddress
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, BasePagedResponse<GetAddressQueryResponse>>
    {
        private readonly Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public GetAddressQueryHandler(Context context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<BasePagedResponse<GetAddressQueryResponse>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Addresses.Where(Where(request))
                    .Select(a => new GetAddressQueryResponse()
                    {
                        Id = a.Id,
                        UserId = a.UserId,
                        CityId = a.CityId,
                        CityName = a.City!.Name,
                        UF = a.City.UF,
                        StateName = a.City!.State!.Name,
                        ZipCode = a.ZipCode,
                        AddressType = a.AddressType,
                        Neighborhood = a.Neighborhood,
                        Street = a.Street,
                        Number = a.Number,
                        Complement = a.Complement,
                        CreatedAt = a.CreatedAt,
                        UpdateAt = a.UpdatedAt,
                        Activated = a.Activated
                    }).GetPagedListAsync<BasePagedResponse<GetAddressQueryResponse>, GetAddressQueryResponse>(request);
            }
            catch (Exception ex) { throw new CrudException("Falha ao recuperar endereços.", ex); }
        }

        private static Expression<Func<Address, bool>> Where(GetAddressQuery query)
        {
            Expression<Func<Address, bool>> where = (user) => !user.Deleted;

            if (query.Id is not null)
                where = where.And(u => u.Id == query.Id.Value);

            if (query.UserId is not null)
                where = where.And(u => u.UserId == query.UserId.Value);

            if (query.Activated is not null)
                where = where.And(u => u.Activated == query.Activated);

            return where;
        }
    }
}
