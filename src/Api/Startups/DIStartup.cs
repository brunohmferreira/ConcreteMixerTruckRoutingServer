namespace ConcreteMixerTruckRoutingServer.Api.Startups
{
    public static class DIStartup
    {
        public static void AddCustomDI(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            #region UnitOfWorks
            //services.AddScoped<ISiacWebUnitOfWork, SiacWebUnitOfWork>();
            #endregion

            #region Contexts
            //services.AddScoped<ICorporativoContexto, CorporativoContexto>();
            #endregion

            #region Services
            //services.AddScoped<IAutorizacaoRestServico, AutorizacaoRestServico>();
            #endregion

            #region Repositories
            //services.AddScoped<IImplantacaoDataSourceRepositorio, ImplantacaoDataSourceRepositorio>();
            #endregion
        }
    }
}
