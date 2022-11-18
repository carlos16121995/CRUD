using CRUD.Domain.Infra.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace CRUD.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api")]
    [Produces("application/json", new string[] { "application/xml" })]
    public class BaseController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseController() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected IActionResult Result(BaseResponse response)
        {
            response ??= new BaseResponse<string>
            {
                Success = false,
                Message = "Não foi possível montar os dados para a sua requisição.",
                ErrorDetails = "Falha ao processar requisição."
            };

            response.Errors = response.Errors.Where(e => e.Message!.Any());

            if (response.StatusCode.HasValue)
                return StatusCode((int)response.StatusCode.Value, response);

            else if (response.Success)
                return Ok(response);

            return BadRequest(response);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!ModelState.IsValid)
            {
                BaseResponse<string> baseResponse = new()
                {
                    Errors = context.ModelState!.Select((KeyValuePair<string, ModelStateEntry> m) => new ErrorModel
                    {
                        Property = m.Key,
                        Message = m.Value.Errors.Select((e) => GetErrorMessage(e)).ToList()
                    }),
                    Success = false,
                    StatusCode = HttpStatusCode.BadRequest
                };
                context.Result = Result(baseResponse);
            }

            base.OnActionExecuting(context);
        }

        private static string GetErrorMessage(ModelError e) => e.ErrorMessage.Contains("' is not valid for ") || e.ErrorMessage.Contains("Error converting value") || e.ErrorMessage.Contains("Could not convert string to integer:")
                           ? "O Valor enviado não é válido! Verifique o tipo de propriedade e tente novamente."
                           : e.ErrorMessage;
    }
}
