using CRUD.Domain.Entities.Localities;
using CRUD.Domain.Infra.Responses;
using CRUD.Infrastructure.Extensions;
using CRUD.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUD.Application.Features.Localities.States.Queries.GetState
{
    /// <summary>
    /// 
    /// </summary>
    public class GetStateQueryHandler : IRequestHandler<GetStateQuery, BasePagedResponse<GetStateQueryResponse>>
    {
        private readonly Context _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public GetStateQueryHandler(Context context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<BasePagedResponse<GetStateQueryResponse>> Handle(GetStateQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.States.Where(Where(request))
                    .Select(state => new GetStateQueryResponse()
                    {
                        UF = state.UF,
                        Name = state.Name,
                        Activated = state.Activated
                    }).GetPagedListAsync<BasePagedResponse<GetStateQueryResponse>, GetStateQueryResponse>(request);
            }
            catch (Exception ex) { throw new Exception(); } // TODO: Mensagens
        }

        private static Expression<Func<State, bool>> Where(GetStateQuery query)
        {
            Expression<Func<State, bool>> where = (user) => !user.Deleted;

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
