using CRUD.Domain.Infra.Paginations;
using CRUD.Domain.Infra.Responses;
using MediatR;

namespace CRUD.Application.Features.Users.Users.Queries.GetUser
{
    /// <summary>
    /// Objeto com parâmetros para recuperar usuários
    /// </summary>
    public class GetUserQuery : BasePagedRequest, IRequest<BasePagedResponse<GetUserQueryResponse>>
    {
        /// <summary>
        /// Filtro para recuperar usuários pelo id.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Filtro para recuperar usuários pelo endereço.
        /// </summary>
        public Guid? AddressId { get; set; }

        /// <summary>
        /// Filtro para recuperar usuários pelo nome.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Filtro para recuperar usuários por estado. Ao não informar o estado retornar ativos e inativos.
        /// </summary>
        public bool? Activated { get; set; }

        /// <summary>
        /// Parâmetro para indicar necessidade de retornar endereços 
        /// </summary>
        public bool Address { get; set; }
    }
}
