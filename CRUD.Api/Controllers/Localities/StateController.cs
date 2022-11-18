using CRUD.Application.Features.Localities.States.Queries.GetState;
using CRUD.Domain.Infra.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Api.Controllers.Localities
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/states")]
    [AllowAnonymous]
    public class StateController : BaseController
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public StateController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        /// <summary>
        /// Endpoint para recuperar estados
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesDefaultResponseType(typeof(BasePagedResponse<GetStateQueryResponse>))]
        public async Task<IActionResult> Get([FromQuery] GetStateQuery request)
        {
            var response = new BasePagedResponse<GetStateQueryResponse>();
            try
            {
                response = await _mediator.Send(request);
                response.Success = true;
                response.Message = "Busca de estado realizada com sucesso.";
            }
            catch (Exception ex)
            { response.MontarErro(ex); }

            return Result(response);
        }
    }
}
