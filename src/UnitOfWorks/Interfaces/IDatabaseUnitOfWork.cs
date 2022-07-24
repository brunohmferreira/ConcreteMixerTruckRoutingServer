using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Client;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.ConcreteType;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Construction;
using ConcreteMixerTruckRoutingServer.UnitOfWorks.Interfaces.Base;

namespace ConcreteMixerTruckRoutingServer.UnitOfWorks.Interfaces
{
    public interface IDatabaseUnitOfWork : IUnitOfWork
    {
        #region Repositories

        IConstructionRepository Construction { get; }
        IClientRepository Client { get; }
        IConcreteTypeRepository ConcreteType { get; }

        #endregion
    }
}
