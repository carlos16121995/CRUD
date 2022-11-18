using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Application.Features.Users.Users.Commands.InativeUsers
{
    /// <summary>
    /// Objeto para inativar ou remover um usuário
    /// </summary>
    public class InativeUserCommand : IRequest
    {
        private bool delete;

        /// <summary>
        /// Método para recuperar ação
        /// </summary>
        /// <returns></returns>
        public bool GetDelete() => delete;

        /// <summary>
        /// Método para setar ação
        /// </summary>
        /// <param name="value"></param>
        public void SetDelete(bool value) => delete = value;

        /// <summary>
        /// Identificador do usuário a ser inativado.
        /// </summary>
        [FromRoute]
        public Guid Id { get; set; }
    }
}
