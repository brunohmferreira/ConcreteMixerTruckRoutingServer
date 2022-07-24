using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Base;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Client;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.ConcreteType;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Construction;
using ConcreteMixerTruckRoutingServer.UnitOfWorks.Base;
using ConcreteMixerTruckRoutingServer.UnitOfWorks.Interfaces;

namespace ConcreteMixerTruckRoutingServer.UnitOfWorks
{
    public class DatabaseUnitOfWork : UnitOfWorkBase, IDatabaseUnitOfWork
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public DatabaseUnitOfWork(IServiceProvider serviceProvider, IDatabaseContext context) : base(serviceProvider, context) { }

        #endregion

        #region Repositories

        public IConstructionRepository Construction { get => Configure<IConstructionRepository>(); }
        public IClientRepository Client { get => Configure<IClientRepository>(); }
        public IConcreteTypeRepository ConcreteType { get => Configure<IConcreteTypeRepository>(); }
        
        #endregion
    }
}
