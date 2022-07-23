using ConcreteMixerTruckRoutingServer.Repositories.Base;
using ConcreteMixerTruckRoutingServer.Repositories.Construction;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Base;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Construction;
using ConcreteMixerTruckRoutingServer.Services.Construction;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.Construction;
using ConcreteMixerTruckRoutingServer.UnitOfWorks;
using ConcreteMixerTruckRoutingServer.UnitOfWorks.Interfaces;

namespace ConcreteMixerTruckRoutingServer.Api.Startups
{
    public static class DIStartup
    {
        public static void AddCustomDI(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            #region UnitOfWorks
            services.AddScoped<IDatabaseUnitOfWork, DatabaseUnitOfWork>();
            #endregion

            #region Contexts
            services.AddScoped<IDatabaseContext, DatabaseContext>();
            #endregion

            #region Services
            services.AddScoped<IConstructionService, ConstructionService>();
            #endregion

            #region Repositories
            services.AddScoped<IConstructionRepository, ConstructionRepository>();
            #endregion
        }
    }
}
