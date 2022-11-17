using CRUD.Domain.Infra.Responses;
using MediatR;

namespace CRUD.Application.Features.Users.Addressess.Queries.GetAddress
{
    /// <summary>
    /// Objeto para recuperar endereços
    /// </summary>
    public class GetAddressQuery : IRequest<BasePagedResponse<GetAddressQueryResponse>>
    {
        /// <summary>
        /// Filtro para recuperar endereços pelo id.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Filtro para recuperar endereços do usuário.
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Filtro para recuperar endereços por estado de entidade. Ao não informar o estado da entidade retorna ativos e inativos.
        /// </summary>
        public bool? Activated { get; set; }
    }
}
