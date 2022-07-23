namespace ConcreteMixerTruckRoutingServer.UnitOfWorks.Interfaces.Base
{
    public interface IUnitOfWork : IDisposable
    {
        #region Transactions

        /// <summary>
        /// Initializes a transaction.
        /// </summary>
        void InitializeTransaction();

        /// <summary>
        /// Commit current transaction.
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Cancel current transaction.
        /// </summary>
        void CancelTransaction();

        #endregion

        #region Cache

        void Cache(bool status);

        #endregion

        #region Repositories

        #endregion
    }
}
