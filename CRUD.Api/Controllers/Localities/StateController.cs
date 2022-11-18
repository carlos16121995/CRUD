using CRUD.Application.Features.Localities.States.Queries.GetState;
using CRUD.Domain.Infra.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Api.Controllers.Localities
{
    [Route("api/states")]
    [AllowAnonymous]
    public class StateController : BaseController
    {
        private readonly IMediator _mediator;

        public StateController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

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
