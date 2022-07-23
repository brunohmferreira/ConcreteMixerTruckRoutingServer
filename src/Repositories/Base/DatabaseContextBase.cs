using ConcreteMixerTruckRoutingServer.Exceptions.General;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Base;
using System.Data;

namespace ConcreteMixerTruckRoutingServer.Repositories.Base
{
    public abstract class DatabaseContextBase : IDatabaseContext
    {
        #region Propriedades

        public IDbConnection Connection { get; protected set; }
        public IDbTransaction Transaction { get; private set; }
        public bool ActiveCache { get; private set; } = false;
        public int OpenTransactions { get; set; }

        #endregion

        #region Transactions

        /// <summary>
        /// Initializes a transaction.
        /// </summary>
        public void InitializeTransaction()
        {
            OpenTransactions++;

            if (OpenTransactions != 1)
                return;

            if (Connection.State != ConnectionState.Open)
                Connection.Open();

            Transaction = Connection.BeginTransaction();
        }

        /// <summary>
        /// Commits current transaction.
        /// </summary>
        public void CommitTransaction()
        {
            if (OpenTransactions == 0)
                throw new TransactionInitializationException();

            OpenTransactions--;

            if (OpenTransactions != 0)
                return;

            Transaction.Commit();
        }

        /// <summary>
        /// Cancel current transaction.
        /// </summary>
        public void CancelTransaction()
        {
            OpenTransactions = 0;
            Transaction.Rollback();
            Transaction.Dispose();

            Transaction = null;
        }

        #endregion

        #region Cache

        public void Cache(bool status)
        {
            ActiveCache = status;
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Dispose context.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose of classe.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            if (Connection != null)
            {
                if (Transaction != null)
                {
                    if (Connection.State == ConnectionState.Open && OpenTransactions > 0)
                        Transaction.Rollback();

                    Transaction.Dispose();
                }

                Connection.Dispose();
            }
        }

        #endregion
    }
}
