using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace API
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
                {
                    c.OperationFilter<AddRequiredHeaderParameter>();
                    c.SingleApiVersion("v1", "API");
                }).EnableSwaggerUi(c =>  {  });
        }
    }

    public class AddRequiredHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();
        }
    }
}