using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiEcommerce.Swagger
{
    public class IgnoreSchemaFile : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null || context.Type == null) return;

            var propertiesToIgnore = new[] { "Imagem" };

            foreach (var property in propertiesToIgnore)
            {
                if (schema.Properties.ContainsKey(property))
                {
                    schema.Properties.Remove(property);
                }
            }

        }
    }
}


