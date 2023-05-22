using System;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace UMS.Configs
{
	public class SwaggerFilter : IDocumentFilter
	{
		public SwaggerFilter()
		{
		}

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            
        }
    }
}

