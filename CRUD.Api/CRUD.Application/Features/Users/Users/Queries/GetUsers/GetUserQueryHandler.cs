using CRUD.Application.Features.Users.Addressess.Queries.GetAddress;
using CRUD.Domain.Entities.Users;
using CRUD.Domain.Infra.Responses;
using CRUD.Infrastructure.Extensions;
using CRUD.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUD.Application.Features.Users.Users.Queries.GetUsers
{
    /// <summary>
    /// 
    /// </summary>
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, BasePagedResponse<GetUserQueryResponse>>
    {
        private readonly Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public GetUserQueryHandler(Context context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<BasePagedResponse<GetUserQueryResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Users.Where(Where(request))
                    .Select(user => new GetUserQueryResponse()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        BirthDate = user.BirthDate,
                        Gender = user.Gender,
                        Activated = user.Activated,
                        CreatedAt = user.CreatedAt,
                        UpdateAt = user.UpdatedAt,
                        Addresses = request.Address ? MapAddress(user) : new()
                    }).GetPagedListAsync<BasePagedResponse<GetUserQueryResponse>, GetUserQueryResponse>(request);
            }
            catch (Exception ex) { throw new Exception(); } // TODO: Mensagens
        }

        private static List<GetAddressQueryResponse> MapAddress(User user) => user.Addresses.Where(a => !a.Deleted)
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
                                                                            }).ToList();

        private static Expression<Func<User, bool>> Where(GetUserQuery query)
        {
            Expression<Func<User, bool>> where = (user) => !user.Deleted;

            if (query.Id is not null)
                where = where.And(u => u.Id == query.Id.Value);

            if (query.Name is not null)
                where = where.And(u => EF.Functions.Like(u.Name, $"%{query.Name}%"));

            if (query.AddressId is not null)
                where = where.And(u => u.Addresses.Any(a => a.Id == query.AddressId));

            if (query.Activated is not null)
                where = where.And(u => u.Activated == query.Activated);

            return where;
        }
    }
}
