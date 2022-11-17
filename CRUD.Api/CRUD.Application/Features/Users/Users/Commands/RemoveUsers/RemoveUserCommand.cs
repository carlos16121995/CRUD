using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Application.Features.Users.Users.Commands.RemoveUsers
{
    /// <summary>
    /// Objeto para remover um usuário e seus endereços relacionados
    /// </summary>
    public class RemoveUserCommand : IRequest
    {
        /// <summary>
        /// Identificador do usuário a ser inativado.
        /// </summary>
        [FromRoute]
        public Guid Id { get; set; }
    }
}
