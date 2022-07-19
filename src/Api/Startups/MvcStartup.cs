using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using PartialResponse.AspNetCore.Mvc;
using PartialResponse.Extensions.DependencyInjection;

namespace ConcreteMixerTruckRoutingServer.Api.Startups
{
    public static class MvcStartup
    {
        public static void AddCustomMvc(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
            })
                .AddPartialJsonFormatters()
                .AddNewtonsoftJson()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.Configure<MvcPartialJsonOptions>(options =>
            {
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                options.IgnoreCase = true;
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddApiVersioning();
        }

        public static void UseCustomMvc(this IApplicationBuilder app)
        {
            app.UseHsts();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
