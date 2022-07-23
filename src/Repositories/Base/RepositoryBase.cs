using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Base;

namespace ConcreteMixerTruckRoutingServer.Repositories.Base
{
    public abstract class RepositoryBase
    {
        #region Properties

        protected TimeSpan TimeCache = new TimeSpan(0, 30, 0, 0);

        public IDatabaseContext Context { get; set; }

        #endregion

    }
}
