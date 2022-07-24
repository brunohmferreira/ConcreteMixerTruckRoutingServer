using ConcreteMixerTruckRoutingServer.Entities.Base;
using ConcreteMixerTruckRoutingServer.Exceptions.General;
using ConcreteMixerTruckRoutingServer.Services.Base;

namespace ConcreteMixerTruckRoutingServer.Services.Extensions
{
    public static class ValidationExtension
    {
        public static async Task Validate<TValidator, TValidation>(this TValidation objectValidation, params object[] parameters)
            where TValidator : ValidationBase<TValidation>, new()
            where TValidation : class
        {
            if (objectValidation == null)
                return;

            var validator = new TValidator();
            validator.Parameters = new List<object>(parameters);
            var results = await validator.ValidateAsync(objectValidation);

            if (!results.IsValid)
                throw new FluentValidationException(results.Errors.Select(s => s.ErrorMessage));
        }

        public static async Task<TEntity> ValidateItemNotFound<TEntity>(this Task<TEntity> taskEntity)
            where TEntity : EntityBase
        {
            await taskEntity;

            if (taskEntity.Result != null)
                return taskEntity.Result;

            throw new ItemNotFoundException(RetrieveEntityName<TEntity>());
        }

        public static async Task<IEnumerable<TEntity>> ValidateEmptyList<TEntity>(this Task<IEnumerable<TEntity>> taskEntityLists)
            where TEntity : class
        {
            await taskEntityLists;

            if (taskEntityLists.Result.Any())
                return taskEntityLists.Result;

            throw new EmptyListException(RetrieveEntityName<TEntity>());
        }

        public static IEnumerable<TEntity> ValidateEmptyList<TEntity>(this IEnumerable<TEntity> taskEntityLists)
            where TEntity : class
        {
            if (taskEntityLists.Any())
                return taskEntityLists;

            throw new EmptyListException(RetrieveEntityName<TEntity>());
        }

        public static async Task<bool> ValidateUpdateItem<TEntity>(this Task<bool> taskUpdated)
            where TEntity : EntityBase
        {
            await taskUpdated;

            if (!taskUpdated.Result)
                throw new ItemNotFoundException(RetrieveEntityName<TEntity>());

            return taskUpdated.Result;
        }

        public static async Task<long> ValidateInsertItem<TEntity>(this Task<long> taskId)
            where TEntity : EntityBase
        {
            await taskId;

            if (taskId.Result == 0)
                throw new FailureInsertItemException(RetrieveEntityName<TEntity>());

            return taskId.Result;
        }

        public static async Task<bool> ValidateDeleteItem<TEntity>(this Task<bool> taskDeleted)
            where TEntity : EntityBase
        {
            await taskDeleted;

            if (!taskDeleted.Result)
                throw new FailureDeleteItemException(RetrieveEntityName<TEntity>());

            return taskDeleted.Result;
        }

        public static string RetrieveEntityName<TEntity>()
            where TEntity : class
        {
            return typeof(TEntity).Description() == null ? typeof(TEntity).Name.Replace("Entity", string.Empty) : typeof(TEntity).Description();
        }

        public static bool ValidateEnum<TEnum>(this TEnum enumerator) where TEnum : Enum
        {
            return Enum.IsDefined(typeof(TEnum), enumerator);
        }
    }
}
