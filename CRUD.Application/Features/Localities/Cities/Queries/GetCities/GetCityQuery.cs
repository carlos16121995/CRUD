using CRUD.Domain.Infra.Requests;
using CRUD.Domain.Infra.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Application.Features.Localities.Cities.Queries.GetCities
{
    /// <summary>
    /// Objeto para recuperar cidades
    /// </summary>
    public class GetCityQuery : BasePagedRequest, IRequest<BasePagedResponse<GetCityQueryResponse>>
    {
        /// <summary>
        /// Identificador da cidade
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// UF do estado
        /// </summary>
        [MaxLength(2)]
        public string? UF { get; set; }

        /// <summary>
        /// Nome da cidade
        /// </summary>
        [MaxLength(60)]
        public string? Name { get; set; }

        /// <summary>
        /// Filtro para recuperar cidades por estado da entidade. Ao não informar o estado da entidade retorna ativos e inativos.
        /// </summary>
        public bool? Activated { get; set; }
    }
}
