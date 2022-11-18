using CRUD.Application.Features.Users.Users.Commands.InativeUsers;
using CRUD.Application.Features.Users.Users.Commands.InsertUsers;
using CRUD.Application.Features.Users.Users.Commands.RemoveUsers;
using CRUD.Application.Features.Users.Users.Commands.UpdateUsers;
using CRUD.Application.Features.Users.Users.Queries.GetUsers;
using CRUD.Domain.Infra.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Api.Controllers
{
    [Route("api/users")]
    [AllowAnonymous]
    public partial class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpPost]
        [ProducesDefaultResponseType(typeof(BaseResponse<InsertUserCommandResponse>))]
        public async Task<IActionResult> Insert(InsertUserCommand request)
        {
            var response = new BaseResponse<InsertUserCommandResponse>();
            try
            {
                response.Data = await _mediator.Send(request);
                response.Success = true;
                response.Message = "Usuario inserido com sucesso.";
            }
            catch (Exception ex)
            { response.MontarErro(ex); }

            return Result(response);
        }

        [HttpPut("{Id}")]
        [ProducesDefaultResponseType(typeof(BaseResponse<string>))]
        public async Task<IActionResult> Update([FromRoute] UpdateUserCommand request)
        {
            var response = new BaseResponse<string>();
            try
            {
                await _mediator.Send(request);
                response.Success = true;
                response.Message = "Usuario alterado com sucesso.";
            }
            catch (Exception ex)
            { response.MontarErro(ex); }

            return Result(response);
        }

        [HttpPut("{Id}/inactivate")]
        [ProducesDefaultResponseType(typeof(BaseResponse<string>))]
        public async Task<IActionResult> Inactivate([FromRoute] InativeUserCommand request)
        {
            var response = new BaseResponse<string>();
            try
            {
                request.SetDelete(false);
                await _mediator.Send(request);
                response.Success = true;
                response.Message = "Usuario inativado com sucesso.";
            }
            catch (Exception ex)
            { response.MontarErro(ex); }

            return Result(response);
        }

        [HttpPut("{Id}/remove")]
        [ProducesDefaultResponseType(typeof(BaseResponse<string>))]
        public async Task<IActionResult> Remove([FromRoute] InativeUserCommand request)
        {
            var response = new BaseResponse<string>();
            try
            {
                request.SetDelete(true);
                await _mediator.Send(request);
                response.Success = true;
                response.Message = "Usuario removido com sucesso.";
            }
            catch (Exception ex)
            { response.MontarErro(ex); }

            return Result(response);
        }

        [HttpDelete("{Id}")]
        [ProducesDefaultResponseType(typeof(BaseResponse<string>))]
        public async Task<IActionResult> Delete([FromRoute] RemoveUserCommand request)
        {
            var response = new BaseResponse<string>();
            try
            {
                await _mediator.Send(request);
                response.Success = true;
                response.Message = "Usuario deletado com sucesso.";
            }
            catch (Exception ex)
            { response.MontarErro(ex); }

            return Result(response);
        }

        [HttpGet]
        [ProducesDefaultResponseType(typeof(BasePagedResponse<GetUserQueryResponse>))]
        public async Task<IActionResult> Get([FromQuery] GetUserQuery request)
        {
            var response = new BasePagedResponse<GetUserQueryResponse>();
            try
            {
                response = await _mediator.Send(request);
                response.Success = true;
                response.Message = "Busca de usuário realizada com sucesso.";
            }
            catch (Exception ex)
            { response.MontarErro(ex); }

            return Result(response);
        }
    }
}
