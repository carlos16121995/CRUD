using CRUD.Application.Features.Users.Addressess.Queries.GetAddress;
using CRUD.Application.Features.Users.Users.Commands.InsertUsers;

namespace CRUD.Application.Features.Users.Users.Queries.GetUsers
{
    /// <summary>
    /// Objeto de retorno do usuário
    /// </summary>
    public class GetUserQueryResponse : InsertUserCommand
    {
        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Data de criação do registro
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Data da ultima atualização do registro
        /// </summary>
        public DateTime UpdateAt { get; set; }

        /// <summary>
        /// Lista de endereços do usuário retornado quando a propriedade Address for marcada como verdadeira
        /// </summary>
        public IEnumerable<GetAddressQueryResponse>? Addresses { get; set; } = new HashSet<GetAddressQueryResponse>();
    }

}
