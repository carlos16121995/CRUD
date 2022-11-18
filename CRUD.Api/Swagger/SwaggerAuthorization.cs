using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;

namespace CRUD.Api.Swagger
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerAuthorization
    {
        private readonly RequestDelegate next;
        private readonly SwaggerConfiguration swaggerConfiguration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="swaggerConfiguration"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public SwaggerAuthorization(RequestDelegate next, SwaggerConfiguration swaggerConfiguration)
        {
            this.next = next;
            this.swaggerConfiguration = swaggerConfiguration ?? throw new ArgumentNullException(nameof(swaggerConfiguration));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                string authHeader = context.Request.Headers["Authorization"];
                if (authHeader != null && authHeader.StartsWith("Basic "))
                {
                    var encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();
                    if (string.IsNullOrWhiteSpace(encodedUsernamePassword))
                        return;
                    var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));

                    if (IsAuthorized(decodedUsernamePassword.Split(':', 2)[0], decodedUsernamePassword.Split(':', 2)[1]))
                    {
                        await next.Invoke(context);
                        return;
                    }
                }
                context.Response.Headers.Add("WWW-Authenticate", "Basic");
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
                await next.Invoke(context);
        }

        private bool IsAuthorized(string username, string password)
            => username.Equals(swaggerConfiguration.Login, StringComparison.InvariantCultureIgnoreCase) && password.Equals(swaggerConfiguration.Password);
    }
}
