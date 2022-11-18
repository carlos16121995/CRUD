using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Application.Features.Users.Addresses.Commands.InativeAddresses
{
    /// <summary>
    /// Objeto para remover um endereço
    /// </summary>
    public class InativeAddressCommand : IRequest
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
        /// Identificador do endereço a ser inativado.
        /// </summary>
        [FromRoute]
        public Guid Id { get; set; }
    }
}
