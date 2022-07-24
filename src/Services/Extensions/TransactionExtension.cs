using ConcreteMixerTruckRoutingServer.Exceptions.General;
using ConcreteMixerTruckRoutingServer.UnitOfWorks.Interfaces.Base;

namespace ConcreteMixerTruckRoutingServer.Services.Extensions
{
    public static class TransactionExtension
    {
        public static T ExecuteInTransaction<T>(Func<T> method,
            params IUnitOfWork[] unitOfWorksList)
        {
            try
            {
                InitializeTransaction(unitOfWorksList);
                T result = method();
                CommitTransaction(unitOfWorksList);
                return result;
            }
            catch
            {
                CancelTransaction(unitOfWorksList);
                throw;
            }
        }

        public static void ExecuteInTransaction(Action action,
            params IUnitOfWork[] unitOfWorksList)
        {
            try
            {
                InitializeTransaction(unitOfWorksList);
                action();
                CommitTransaction(unitOfWorksList);
            }
            catch
            {
                CancelTransaction(unitOfWorksList);
                throw;
            }
        }

        public static async Task<T> ExecuteInTransactionAsync<T>(Func<Task<T>> method,
            params IUnitOfWork[] unitOfWorksList)
        {
            try
            {
                InitializeTransaction(unitOfWorksList);
                T result;
                result = await method();
                CommitTransaction(unitOfWorksList);
                return result;
            }
            catch
            {
                CancelTransaction(unitOfWorksList);
                throw;
            }
        }

        public static async Task ExecuteInTransactionAsync(Func<Task> method,
            params IUnitOfWork[] unitOfWorksList)
        {
            try
            {
                InitializeTransaction(unitOfWorksList);
                await method();
                CommitTransaction(unitOfWorksList);
            }
            catch
            {
                CancelTransaction(unitOfWorksList);
                throw;
            }
        }

        private static void InitializeTransaction(IEnumerable<IUnitOfWork> unitOfWorksList)
        {
            if (!unitOfWorksList.Any())
            {
                throw new TransactionWithoutUnitOfWorks();
            }
            foreach (var unitOfWork in unitOfWorksList)
            {
                unitOfWork.InitializeTransaction();
            }
        }

        private static void CommitTransaction(IEnumerable<IUnitOfWork> unitOfWorksList)
        {
            foreach (var unitOfWork in unitOfWorksList)
            {
                unitOfWork.CommitTransaction();
            }
        }

        private static void CancelTransaction(IEnumerable<IUnitOfWork> unitOfWorksList)
        {
            foreach (var unitOfWork in unitOfWorksList)
            {
                unitOfWork.CancelTransaction();
            }
        }
    }
}
