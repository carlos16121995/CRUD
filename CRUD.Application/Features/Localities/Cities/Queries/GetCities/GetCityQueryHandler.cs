using CRUD.Domain.Entities.Localities;
using CRUD.Domain.Infra.Exceptions;
using CRUD.Domain.Infra.Responses;
using CRUD.Infrastructure.Extensions;
using CRUD.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUD.Application.Features.Localities.Cities.Queries.GetCities
{
    /// <summary>
    /// 
    /// </summary>
    public class GetCityQueryHandler : IRequestHandler<GetCityQuery, BasePagedResponse<GetCityQueryResponse>>
    {
        private readonly Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public GetCityQueryHandler(Context context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<BasePagedResponse<GetCityQueryResponse>> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Cities.Where(Where(request))
                    .Select(city => new GetCityQueryResponse()
                    {
                        Id = city.Id,
                        Name = city.Name,
                        UF = city.UF,
                        Activated = city.Activated,
                    }).GetPagedListAsync<BasePagedResponse<GetCityQueryResponse>, GetCityQueryResponse>(request);
            }
            catch (Exception ex) { throw new CrudException("Falha ao recuperar cidades.", ex); }
        }

        private static Expression<Func<City, bool>> Where(GetCityQuery query)
        {
            Expression<Func<City, bool>> where = (user) => !user.Deleted;

            if (query.Id is not null)
                where = where.And(u => u.Id == query.Id.Value);

            if (query.UF is not null)
                where = where.And(u => u.UF == query.UF);

            if (query.Name is not null)
                where = where.And(u => EF.Functions.Like(u.Name, $"%{query.Name}%"));

            if (query.Activated is not null)
                where = where.And(u => u.Activated == query.Activated);

            return where;
        }
    }
}
