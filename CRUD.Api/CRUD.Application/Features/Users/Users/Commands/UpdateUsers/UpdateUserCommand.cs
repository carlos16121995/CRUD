using CRUD.Application.Features.Users.Users.Commands.InsertUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Application.Features.Users.Users.Commands.UpdateUsers
{
    /// <summary>
    /// Objeto para alterar informações de um usuário
    /// </summary>
    public class UpdateUserCommand : IRequest
    {
        /// <summary>
        /// Identifiicador do usuário para alteração dos dados.
        /// </summary>
        [FromRoute]
        public Guid Id { get; set; }

        /// <summary>
        /// Objeto com os dados do usuário para alteração.
        /// </summary>
        [FromBody]
        [Required]
        public InsertUserCommand Data { get; set; } = new();
    }
}
