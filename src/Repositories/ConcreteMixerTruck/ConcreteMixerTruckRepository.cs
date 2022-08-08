using ConcreteMixerTruckRoutingServer.Entities;
using ConcreteMixerTruckRoutingServer.Repositories.Base;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.ConcreteMixerTruck;
using Dapper;

namespace ConcreteMixerTruckRoutingServer.Repositories.ConcreteMixerTruck
{
    public class ConcreteMixerTruckRepository : RepositoryBase, IConcreteMixerTruckRepository
    {
        public async Task<IEnumerable<ConcreteMixerTruckEntity>> GetConcreteMixerTrucksList()
        {
            return await Context.Connection.QueryAsync<ConcreteMixerTruckEntity>(
                sql: $@"
                    SELECT 
                        C.ConcreteMixerTruckId,
                        C.MaximumCapacity,
                        C.UseCost,
                        C.Available,
                        C.ChangeDatetime
                    FROM ConcreteMixerTruck C
                    WHERE C.Available = 1",
                transaction: Context.Transaction);
        }

    }
}
