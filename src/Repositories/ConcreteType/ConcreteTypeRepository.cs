using ConcreteMixerTruckRoutingServer.Dtos.ConcreteType;
using ConcreteMixerTruckRoutingServer.Entities;
using ConcreteMixerTruckRoutingServer.Repositories.Base;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.ConcreteType;
using Dapper;

namespace ConcreteMixerTruckRoutingServer.Repositories.ConcreteType
{
    public class ConcreteTypeRepository : RepositoryBase, IConcreteTypeRepository
    {
        public async Task<ConcreteTypeEntity> GetConcreteTypeById(int concreteTypeId)
        {
            return await Context.Connection.QuerySingleOrDefaultAsync<ConcreteTypeEntity>(
                sql: $@"
                    SELECT 
                        C.ConcreteTypeId,
                        C.Description,
                        C.Available,
                        C.ChangeDatetime
                    FROM ConcreteType C 
                    WHERE C.ConcreteTypeId = @ConcreteTypeId",
                param: new { ConcreteTypeId = concreteTypeId },
                transaction: Context.Transaction);
        }

        public async Task<IEnumerable<ClientEntity>> GetConcreteTypeByFilter(GetRequestDto filter)
        {
            return await Context.Connection.QueryAsync<ClientEntity>(
                sql: $@"
                    SELECT 
                        C.ConcreteTypeId,
                        C.Description,
                        C.Available,
                        C.ChangeDatetime
                    FROM ConcreteType C 
                    WHERE C.ConcreteTypeId <> 0
                        {(filter.Description != null ?
                        " AND C.Description = @Description" : "")}",
                param: filter,
                transaction: Context.Transaction);
        }

        public async Task<int> InsertConcreteType(PostRequestDto dto)
        {
            return await Context.Connection.QuerySingleOrDefaultAsync<int>(
                sql: $@"
                    INSERT INTO ConcreteType (
                        Description,
                        Available,
                        ChangeDatetime
                    ) VALUES (
                        @Description,
                        @Available,
                        GETDATE()
                    )
                    SELECT SCOPE_IDENTITY()",
                param: dto,
                transaction: Context.Transaction);
        }

        public async Task<bool> UpdateConcreteType(PutRequestDto dto)
        {
            var amountOfAffectedRows = await Context.Connection.ExecuteAsync(
                sql: $@"
                    UPDATE ConcreteType 
                    SET Description = @Description,
                        Available = @Available
                    WHERE ConcreteTypeId = @ConcreteTypeId",
                param: dto,
                transaction: Context.Transaction);

            return amountOfAffectedRows > 0;
        }
    }
}
