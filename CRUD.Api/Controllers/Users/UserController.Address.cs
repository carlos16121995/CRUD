using CRUD.Application.Features.Users.Addresses.Commands.InativeAddresses;
using CRUD.Application.Features.Users.Addresses.Commands.InsertAddresses;
using CRUD.Application.Features.Users.Addresses.Commands.UpdateAddresses;
using CRUD.Application.Features.Users.Addresses.Queries.GetAddress;
using CRUD.Domain.Infra.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Api.Controllers
{
    public partial class UserController
    {
        /// <summary>
        /// Endpoint para inserir endereço
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{UserId}/addressess")]
        [ProducesDefaultResponseType(typeof(BaseResponse<InsertAddressCommandResponse>))]
        public async Task<IActionResult> Insert([FromRoute] InsertAddressCommand request)
        {
            var response = new BaseResponse<InsertAddressCommandResponse>();
            try
            {
                response.Data = await _mediator.Send(request);
                response.Success = true;
                response.Message = "Endereço inserido com sucesso.";
            }
            catch (Exception ex)
            { response.MontarErro(ex); }

            return Result(response);
        }

        /// <summary>
        /// Endpoint para alterar endereço
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("addressess/{Id}")]
        [ProducesDefaultResponseType(typeof(BaseResponse<string>))]
        public async Task<IActionResult> Update([FromRoute] UpdateAddressCommand request)
        {
            var response = new BaseResponse<string>();
            try
            {
                await _mediator.Send(request);
                response.Success = true;
                response.Message = "Endereço alterado com sucesso.";
            }
            catch (Exception ex)
            { response.MontarErro(ex); }

            return Result(response);
        }

        /// <summary>
        /// Endpoint para inativar endereço
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("addressess/{Id}/inactivate")]
        [ProducesDefaultResponseType(typeof(BaseResponse<string>))]
        public async Task<IActionResult> Inactivate([FromRoute] InativeAddressCommand request)
        {
            var response = new BaseResponse<string>();
            try
            {
                request.SetDelete(false);
                await _mediator.Send(request);
                response.Success = true;
                response.Message = "Endereço inativado com sucesso.";
            }
            catch (Exception ex)
            { response.MontarErro(ex); }

            return Result(response);
        }

        /// <summary>
        /// Endpoint para remover logicamente o endereço
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("addressess/{Id}/remove")]
        [ProducesDefaultResponseType(typeof(BaseResponse<string>))]
        public async Task<IActionResult> Remove([FromRoute] InativeAddressCommand request)
        {
            var response = new BaseResponse<string>();
            try
            {
                request.SetDelete(true);
                await _mediator.Send(request);
                response.Success = true;
                response.Message = "Endereço removido com sucesso.";
            }
            catch (Exception ex)
            { response.MontarErro(ex); }

            return Result(response);
        }

        /// <summary>
        /// Endpoint para recuperar endereços
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("addressess")]
        [ProducesDefaultResponseType(typeof(BasePagedResponse<GetAddressQueryResponse>))]
        public async Task<IActionResult> Get([FromQuery] GetAddressQuery request)
        {
            var response = new BasePagedResponse<GetAddressQueryResponse>();
            try
            {
                response = await _mediator.Send(request);
                response.Success = true;
                response.Message = "Busca de endereço realizada com sucesso.";
            }
            catch (Exception ex)
            { response.MontarErro(ex); }

            return Result(response);
        }
    }
}
