using CRUD.Application.Features.Users.Addresses.Commands.InsertAddresses;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Application.Features.Users.Addresses.Queries.GetAddress
{
    /// <summary>
    /// Objeto para recuperar endereços
    /// </summary>
    public class GetAddressQueryResponse : InsertAddress
    {
        /// <summary>
        /// Identificador do endereço
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Nome da cidade
        /// </summary>
        [MaxLength(60)]
        public string CityName { get; set; } = string.Empty;

        /// <summary>
        /// Uf do estado
        /// </summary>
        [MaxLength(2)]
        public string UF { get; set; } = string.Empty;

        /// <summary>
        /// Nome do estado
        /// </summary>
        [MaxLength(62)]
        public string StateName { get; set; } = string.Empty;

        /// <summary>
        /// Data de criação do registro
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Data da ultima modificação
        /// </summary>
        public DateTime UpdateAt { get; set; }
    }
}
