namespace ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Base
{
    public interface IRepositoryContext
    {
        #region Properties

        IDatabaseContext Context { get; set; }

        #endregion
    }
}
