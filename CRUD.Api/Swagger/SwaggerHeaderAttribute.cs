// Copyright (c) 2022, Unidas. All rights reserved
// PRIVATE SOURCE. Any kind of unauthorized use is prohibited.

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CRUD.Infrastructure.Swagger
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerHeaderAttribute : IOperationFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();
        }
    }
}
