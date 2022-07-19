using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.ComponentModel;
using System.Reflection;

namespace ConcreteMixerTruckRoutingServer.Api.Startups
{
    public static class SwaggerStartup
    {
        private const string ENDPOINT_SWAGGER = "/swagger/v1/swagger.json";

        public static void AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Concrete Mixer Truck Routing Server: Web Api .NET 6", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.CustomSchemaIds(x => x.FullName);
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.OrderActionsBy(x => { x.TryGetMethodInfo(out var info); return info.DeclaringType.GetCustomAttributes().OfType<DescriptionAttribute>()?.FirstOrDefault()?.Description; });
            });
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.OAuthAppName("Concrete Mixer Truck Routing Server - Swagger");
                c.SwaggerEndpoint($"{(string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..")}{ENDPOINT_SWAGGER}", "API REST v1");
                c.DocExpansion(DocExpansion.None);
            });

            return app;
        }
    }
}
