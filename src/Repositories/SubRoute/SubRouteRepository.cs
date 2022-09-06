using ConcreteMixerTruckRoutingServer.Entities;
using ConcreteMixerTruckRoutingServer.Repositories.Base;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.SubRoute;
using Dapper;

namespace ConcreteMixerTruckRoutingServer.Repositories.SubRoute
{
    public class SubRouteRepository : RepositoryBase, ISubRouteRepository
    {
        public async Task<IEnumerable<SubRouteEntity>> GetSubRoutesByRoute(int routeId)
        {
            return await Context.Connection.QueryAsync<SubRouteEntity>(
                sql: $@"
                    SELECT 
                        S.SubRouteId,
                        S.RouteId,
                        S.ConstructionOriginId,
                        S.ConstructionDestinyId
                    FROM SubRoute S
                    WHERE S.RouteId = @RouteId",
                param: new
                {
                    RouteId = routeId
                },
                transaction: Context.Transaction);
        }

        public async Task<int> InsertSubRoute(SubRouteEntity subRoute)
        {
            return await Context.Connection.QuerySingleOrDefaultAsync<int>(
                sql: $@"
                    INSERT INTO SubRoute (
                        RouteId,
                        ConstructionOriginId,
                        ConstructionDestinyId
                    ) VALUES (
                        @RouteId,
                        @ConstructionOriginId,
                        @ConstructionDestinyId
                    )
                    SELECT SCOPE_IDENTITY()",
                param: new
                {
                    RouteId = subRoute.RouteId,
                    ConstructionOriginId = subRoute.ConstructionOriginId,
                    ConstructionDestinyId = subRoute.ConstructionDestinyId
                },
                transaction: Context.Transaction);
        }
    }
}
