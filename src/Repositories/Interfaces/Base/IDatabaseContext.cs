using System.Data;

namespace ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Base
{
    public interface IDatabaseContext : IDisposable
    {
        #region Properties

        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        bool ActiveCache { get; }
        int OpenTransactions { get; }

        #endregion

        #region Transactions

        /// <summary>
        /// Initializes a transaction.
        /// </summary>
        void InitializeTransaction();

        /// <summary>
        /// Commits current transaction.
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
    }
}
