using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Construction;
using ConcreteMixerTruckRoutingServer.UnitOfWorks.Interfaces.Base;

namespace ConcreteMixerTruckRoutingServer.UnitOfWorks.Interfaces
{
    public interface IDatabaseUnitOfWork : IUnitOfWork
    {
        #region Repositories

        IConstructionRepository Construction { get; }

        #endregion
    }
}
