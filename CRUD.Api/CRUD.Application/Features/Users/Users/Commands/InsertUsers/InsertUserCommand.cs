using CRUD.Domain.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Application.Features.Users.Users.Commands.InsertUsers
{
    /// <summary>
    /// Objeto para inserir um usuário
    /// </summary>
    public class InsertUserCommand : IRequest<InsertUserCommandResponse>
    {
        /// <summary>
        /// Nome completo do usuário.
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Data de aniversário do usuário.
        /// </summary>
        [Required]
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Gênero do usuário.
        /// </summary>
        [Required]
        public EGender Gender { get; set; }

        /// <summary>
        /// Estado atual do usuário.
        /// </summary>
        public bool Activated { get; set; }
    }
}
