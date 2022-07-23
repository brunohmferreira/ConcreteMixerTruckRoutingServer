using ConcreteMixerTruckRoutingServer.UnitOfWorks.Interfaces;

namespace ConcreteMixerTruckRoutingServer.Services.Base
{
    public abstract class ServiceBase
    {
        protected IDatabaseUnitOfWork DatabaseUnitOfWork { get; set; }

        protected ServiceBase() { }

        protected ServiceBase(IDatabaseUnitOfWork database)
        {
            DatabaseUnitOfWork = database;
        }
    }
}
