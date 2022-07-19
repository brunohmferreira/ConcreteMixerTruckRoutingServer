namespace ConcreteMixerTruckRoutingServer.Api.Startups
{
    public static class CorsStartup
    {
        public static void AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddPolicy(name: "AllowAll", builder =>
                {
                    builder.SetIsOriginAllowed(_ => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });

                o.AddPolicy(name: "AllowEnvironment", builder =>
                {
                    builder.WithOrigins()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });
        }

        public static void UseCustomCors(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName.Equals("local", System.StringComparison.CurrentCultureIgnoreCase) ||
                env.EnvironmentName.Equals("development", System.StringComparison.CurrentCultureIgnoreCase))
            {
                app.UseCors("AllowAll");
            }
            else
            {
                app.UseCors("AllowEnvironment");
            }
        }
    }
}
