﻿using ConcreteMixerTruckRoutingServer.Repositories.Address;
using ConcreteMixerTruckRoutingServer.Repositories.Base;
using ConcreteMixerTruckRoutingServer.Repositories.Client;
using ConcreteMixerTruckRoutingServer.Repositories.ConcreteType;
using ConcreteMixerTruckRoutingServer.Repositories.Construction;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Address;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Base;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Client;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.ConcreteType;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Construction;
using ConcreteMixerTruckRoutingServer.Services.Address;
using ConcreteMixerTruckRoutingServer.Services.Client;
using ConcreteMixerTruckRoutingServer.Services.ConcreteType;
using ConcreteMixerTruckRoutingServer.Services.Construction;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.Address;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.Client;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.ConcreteType;
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
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IConstructionService, ConstructionService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IConcreteTypeService, ConcreteTypeService>();
            #endregion

            #region Repositories
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IConstructionRepository, ConstructionRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IConcreteTypeRepository, ConcreteTypeRepository>();
            #endregion
        }
    }
}
