using CRUD.Domain.Infra.Requests;
using CRUD.Domain.Infra.Responses;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infrastructure.Extensions
{
    public static class Pagination
    {
        public static async Task<TResponse> GetPagedListAsync<TResponse, T>(this IQueryable<T> query, BasePagedRequest request) where TResponse : BasePagedResponse<T>, new()
        {
            var response = new TResponse();
            var count = await query.CountAsync();

            response.TotalPages = (int)Math.Round((decimal)count / request.PageSize, mode: MidpointRounding.ToPositiveInfinity);
            response.TotalRegisters = count;
            response.Data = await query
                                    .Skip((request.Page - 1) * request.PageSize)
                                    .Take(request.PageSize)
                                    .ToListAsync();

            return response;
        }
    }
}
