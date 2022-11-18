using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Application.Features.Users.Addresses.Commands.UpdateAddresses
{
    using CRUD.Application.Features.Users.Addresses.Commands.InsertAddresses;

    /// <summary>
    /// Objeto para atualizar endereço
    /// </summary>
    public class UpdateAddressCommand : IRequest
    {
        /// <summary>
        /// Identificador do endereço a ser atualizado.
        /// </summary>
        [FromRoute]
        public Guid AddressId { get; set; }

        /// <summary>
        /// Objeto contendo os campos a serem atualizados do endereço
        /// </summary>
        [FromBody]
        [Required]
        public InsertAddress Data { get; set; } = new();
    }
}
