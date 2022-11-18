using CRUD.Application.Features.Localities.Cities.Queries.GetCities;
using CRUD.Domain.Infra.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Api.Controllers.Localities
{
    [Route("api/cities")]
    [AllowAnonymous]
    public class CityController : BaseController
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet]
        [ProducesDefaultResponseType(typeof(BasePagedResponse<GetCityQueryResponse>))]
        public async Task<IActionResult> Get([FromQuery] GetCityQuery request)
        {
            var response = new BasePagedResponse<GetCityQueryResponse>();
            try
            {
                response = await _mediator.Send(request);
                response.Success = true;
                response.Message = "Busca de cidade realizada com sucesso.";
            }
            catch (Exception ex)
            { response.MontarErro(ex); }

            return Result(response);
        }
    }
}
