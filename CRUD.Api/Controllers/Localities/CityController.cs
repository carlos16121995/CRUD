using CRUD.Application.Features.Localities.Cities.Queries.GetCities;
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
    [Route("v{version:apiVersion}/cities")]
    [AllowAnonymous]
    public class CityController : BaseController
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public CityController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        /// <summary>
        /// Endpoint para recuperar cidades
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
