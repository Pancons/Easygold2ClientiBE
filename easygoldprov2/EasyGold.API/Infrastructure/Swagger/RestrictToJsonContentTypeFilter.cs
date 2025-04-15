using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EasyGold.API.Infrastructure.Swagger
{
    public class RestrictToJsonContentTypeFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Rimuove tutti i content types diversi da application/json
            if (operation.RequestBody != null)
            {
                var jsonOnly = operation.RequestBody.Content
                    .Where(c => c.Key == "application/json")
                    .ToDictionary(k => k.Key, v => v.Value);
                operation.RequestBody.Content = jsonOnly;
            }

            foreach (var response in operation.Responses)
            {
                var jsonOnly = response.Value.Content
                    .Where(c => c.Key == "application/json")
                    .ToDictionary(k => k.Key, v => v.Value);
                response.Value.Content = jsonOnly;
            }
        }
    }
}
