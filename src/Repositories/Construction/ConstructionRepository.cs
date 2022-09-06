using ConcreteMixerTruckRoutingServer.Dtos.Construction;
using ConcreteMixerTruckRoutingServer.Entities;
using ConcreteMixerTruckRoutingServer.Repositories.Base;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Construction;
using Dapper;

namespace ConcreteMixerTruckRoutingServer.Repositories.Construction
{
    public class ConstructionRepository : RepositoryBase, IConstructionRepository
    {
        public async Task<IEnumerable<ConstructionEntity>> GetConstructionsList()
        {
            return await Context.Connection.QueryAsync<ConstructionEntity>(
                sql: $@"
                    SELECT 
                        C.ConstructionId,
                        C.Description,
                        C.ClientId,
                        C.ConcreteTypeId,
                        C.VolumeDemand,
                        C.Delivered,
                        C.ChangeDatetime
                    FROM Construction C
                    WHERE Delivered = 0",
                transaction: Context.Transaction);
        }

        public async Task<ConstructionEntity> GetConstructionById(int constructionId)
        {
            return await Context.Connection.QuerySingleOrDefaultAsync<ConstructionEntity>(
                sql: $@"
                    SELECT 
                        C.ConstructionId,
                        C.Description,
                        C.ClientId,
                        C.ConcreteTypeId,
                        C.VolumeDemand,
                        C.Delivered,
                        C.ChangeDatetime
                    FROM Construction C 
                    WHERE C.ConstructionId = @ConstructionId",
                param: new { ConstructionId = constructionId },
                transaction: Context.Transaction);
        }

        public async Task<IEnumerable<ConstructionEntity>> GetConstructionsByFilter(GetRequestDto filter)
        {
            return await Context.Connection.QueryAsync<ConstructionEntity>(
                sql: $@"
                    SELECT 
                        C.ConstructionId,
                        C.Description,
                        C.ClientId,
                        C.ConcreteTypeId,
                        C.VolumeDemand,
                        C.Delivered,
                        C.ChangeDatetime
                    FROM Construction C 
                    WHERE C.ConstructionId <> 0
                        {(filter.Description != null ?
                        " AND C.Description = @Description" : "")}
                        {(filter.VolumeDemand.HasValue ?
                        " AND C.VolumeDemand = @VolumeDemand" : "")}
                        {(filter.Delivered.HasValue ?
                        " AND C.Delivered = @Delivered" : "")}",
                param: filter,
                transaction: Context.Transaction);
        }

        public async Task<int> InsertConstruction(PostRequestDto dto)
        {
            return await Context.Connection.QuerySingleOrDefaultAsync<int>(
                sql: $@"
                    INSERT INTO Construction (
                        Description,
                        ClientId,
                        ConcreteTypeId,
                        VolumeDemand,
                        Delivered,
                        ChangeDatetime
                    ) VALUES (
                        @Description,
                        @ClientId,
                        @ConcreteTypeId,
                        @VolumeDemand,
                        @Delivered,
                        GETDATE()
                    )
                    SELECT SCOPE_IDENTITY()",
                param: new
                {
                    Description = dto.Description,
                    ClientId = dto.Client.ClientId,
                    ConcreteTypeId = dto.ConcreteType.ConcreteTypeId,
                    VolumeDemand = dto.VolumeDemand,
                    Delivered = dto.Delivered,
                },
                transaction: Context.Transaction);
        }

        public async Task<bool> UpdateConstruction(PutRequestDto dto)
        {
            var amountOfAffectedRows = await Context.Connection.ExecuteAsync(
                sql: $@"
                    UPDATE Construction 
                    SET Description = @Description,
                        ClientId = @ClientId,
                        ConcreteTypeId = @ConcreteTypeId,
                        VolumeDemand = @VolumeDemand,
                        Delivered = @Delivered
                    WHERE ConstructionId = @ConstructionId",
                param: new
                {
                    ConstructionId = dto.ConstructionId,
                    Description = dto.Description,
                    ClientId = dto.Client.ClientId,
                    ConcreteTypeId = dto.ConcreteType.ConcreteTypeId,
                    VolumeDemand = dto.VolumeDemand,
                    Delivered = dto.Delivered
                },
                transaction: Context.Transaction);

            return amountOfAffectedRows > 0;
        }

        public async Task<bool> DeliverConstruction(int constructionId)
        {
            var amountOfAffectedRows = await Context.Connection.ExecuteAsync(
                sql: $@"
                    UPDATE Construction 
                    SET Delivered = 1
                    WHERE ConstructionId = @ConstructionId",
                param: new
                {
                    ConstructionId = constructionId
                },
                transaction: Context.Transaction);

            return amountOfAffectedRows > 0;
        }

        public async Task<bool> DeleteConstruction(int constructionId)
        {
            var amountOfAffectedRows = await Context.Connection.ExecuteAsync(
                sql: $@"
                    DELETE FROM Construction
                    WHERE ConstructionId = @ConstructionId",
                param: new { ConstructionId = constructionId },
                transaction: Context.Transaction);

            return amountOfAffectedRows > 0;
        }
    }
}
