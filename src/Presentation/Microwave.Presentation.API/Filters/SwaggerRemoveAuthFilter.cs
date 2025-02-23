using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Microwave.Presentation.API.Filters
{
    public class SwaggerRemoveAuthFilter : IOperationFilter
    {
        private readonly List<string> _publicEndpoints = ["user/auth", "user/create"];

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var path = context.ApiDescription.RelativePath;

            if (_publicEndpoints.Contains(path ?? string.Empty))
                operation.Security.Clear();
        }
    }
}
