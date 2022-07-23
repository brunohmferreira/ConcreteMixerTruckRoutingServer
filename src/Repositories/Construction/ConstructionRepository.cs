using ConcreteMixerTruckRoutingServer.Entities;
using ConcreteMixerTruckRoutingServer.Repositories.Base;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Construction;
using Dapper;

namespace ConcreteMixerTruckRoutingServer.Repositories.Construction
{
    public class ConstructionRepository : RepositoryBase, IConstructionRepository
    {
        public Task<IEnumerable<ConstructionEntity>> GetConstructionsList()
        {
            return Context.Connection.QueryAsync<ConstructionEntity>(
                sql: $@"
                    SELECT 
                        
                    FROM 
                    WHERE ",
                transaction: Context.Transaction);
        }

        public Task<ConstructionEntity> GetConstructionById(int constructionId)
        {
            return Context.Connection.QuerySingleOrDefaultAsync<ConstructionEntity>(
                sql: $@"
                    SELECT 
                        
                    FROM 
                    WHERE ConstructionId = @ConstructionId",
                param: new { ConstructionId = constructionId },
                transaction: Context.Transaction);
        }
    }
}
