using CRUD.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Application.Features.Users.Addresses.Commands.InsertAddresses
{
    /// <summary>
    /// Objeto para inserir endereço
    /// </summary>
    public class InsertAddressCommand : IRequest<InsertAddressCommandResponse>
    {
        /// <summary>
        /// Identificador do usuário dono do Endereço.
        /// </summary>
        [FromRoute]
        public Guid UserId { get; set; }

        /// <summary>
        /// Objeto contendo os dados a serem inseridos do endereço
        /// </summary>
        [FromBody]
        [Required]
        public InsertAddress Data { get; set; } = new();
    }

    /// <summary>
    /// Objeto contendo os dados a serem inseridos do endereço
    /// </summary>
    public class InsertAddress
    {
        /// <summary>
        /// Identificador da cidade.
        /// </summary>
        [Required]
        public int CityId { get; set; }

        /// <summary>
        /// Cep referente ao endereço
        /// </summary>
        [Required]
        [MaxLength(8)]
        public string ZipCode { get; set; } = string.Empty;

        /// <summary>
        /// Tipo do endereço
        /// </summary>
        public EAddressType AddressType { get; set; }

        /// <summary>
        /// Bairro do endereço
        /// </summary>
        [Required]
        [MaxLength(60)]
        public string Neighborhood { get; set; } = string.Empty;

        /// <summary>
        /// Rua do endereço
        /// </summary>
        [Required]
        [MaxLength(60)]
        public string Street { get; set; } = string.Empty;

        /// <summary>
        /// Número da cidade
        /// </summary>
        [Required]
        [MaxLength(60)]
        public string Number { get; set; } = string.Empty;

        /// <summary>
        /// Complemento do endereo
        /// </summary>
        [MaxLength(60)]
        public string? Complement { get; set; }

        /// <summary>
        /// Estado atual do endereço.
        /// </summary>
        public bool Activated { get; set; }
    }
}
