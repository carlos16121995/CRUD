using CRUD.Domain.Infra.Requests;
using CRUD.Domain.Infra.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Application.Features.Localities.States.Queries.GetState
{
    /// <summary>
    /// Objeto para recuperar estados
    /// </summary>
    public class GetStateQuery : BasePagedRequest, IRequest<BasePagedResponse<GetStateQueryResponse>>
    {
        /// <summary>
        /// UF do estado
        /// </summary>
        [MaxLength(2)]
        public string? UF { get; set; }

        /// <summary>
        /// Nome da cidade
        /// </summary>
        [MaxLength(32)]
        public string? Name { get; set; }

        /// <summary>
        /// Filtro para recuperar cidades por estado da entidade. Ao não informar o estado da entidade retorna ativos e inativos.
        /// </summary>
        public bool? Activated { get; set; }
    }
}
