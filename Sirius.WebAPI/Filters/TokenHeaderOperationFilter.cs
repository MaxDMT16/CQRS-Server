using System.Collections.Generic;
using System.Web.Http.Description;
using Sirius.WebAPI.Controllers.Abstract;
using Swashbuckle.Swagger;

namespace Sirius.WebAPI.Filters
{
    public class TokenHeaderOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var controllerType =
                apiDescription.ActionDescriptor.ControllerDescriptor.ControllerType;

            if (!typeof(CustomerController).IsAssignableFrom(controllerType))
            {
                return;
            }

            var attributeDescription = "oken for Customer";
            operation.parameters = operation.parameters ?? new List<Parameter>();
            operation.parameters.Add(new Parameter
            {
                name = "Token",
                @in = "header",
                description = attributeDescription,
                required = true,
                type = "string"
            });
        }
    }
}