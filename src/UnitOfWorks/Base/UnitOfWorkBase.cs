using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Base;
using ConcreteMixerTruckRoutingServer.UnitOfWorks.Interfaces.Base;

namespace ConcreteMixerTruckRoutingServer.UnitOfWorks.Base
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        #region Properties

        protected readonly IServiceProvider ServiceProvider;
        protected readonly IDatabaseContext Context;
        protected readonly Dictionary<Type, IRepositoryContext> Repositories = new Dictionary<Type, IRepositoryContext>();

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        protected UnitOfWorkBase(IServiceProvider serviceProvider, IDatabaseContext databaseContext)
        {
            ServiceProvider = serviceProvider;
            Context = databaseContext;
        }

        /// <summary>
        /// Dispose of class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose of class.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && Context != null)
                Context.Dispose();
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Configures the repositories.
        /// </summary>
        protected virtual TRepository Configure<TRepository>() where TRepository : IRepositoryContext
        {
            var key = typeof(TRepository);

            lock (Repositories)
            {
                if (!Repositories.ContainsKey(key))
                {
                    var repository = (IRepositoryContext)ServiceProvider.GetService(key);
                    repository.Context = Context;

                    Repositories.Add(key, repository);
                }
            }

            return (TRepository)Repositories[key];
        }

        #endregion

        #region Transactions

        /// <summary>
        /// Initializes a transaction.
        /// </summary>
        public void InitializeTransaction()
        {
            Context.InitializeTransaction();
        }

        /// <summary>
        /// Commit current transaction.
        /// </summary>
        public void CommitTransaction()
        {
            Context.CommitTransaction();
        }

        /// <summary>
        /// Cancel current transaction.
        /// </summary>
        public void CancelTransaction()
        {
            Context.CancelTransaction();
        }

        #endregion

        #region Cache

        public void Cache(bool status)
        {
            Context.Cache(status);
        }

        #endregion
    }
}
