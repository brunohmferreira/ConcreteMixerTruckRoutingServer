using ConcreteMixerTruckRoutingServer.Entities;
using ConcreteMixerTruckRoutingServer.Repositories.Base;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Route;
using Dapper;

namespace ConcreteMixerTruckRoutingServer.Repositories.Route
{
    public class RouteRepository : RepositoryBase, IRouteRepository
    {
        public async Task<IEnumerable<RouteEntity>> GetPendingRoutesList()
        {
            return await Context.Connection.QueryAsync<RouteEntity>(
                sql: $@"
                    SELECT 
                        R.RouteId,
                        R.ConcreteMixerTruckId,
                        R.CarriedOut,
                        R.Canceled,
                        R.CreateDatetime
                    FROM Route R
                    WHERE R.CarriedOut = 0
                        AND R.Canceled = 0
                    ORDER BY R.CreateDatetime",
                transaction: Context.Transaction);
        }

        public async Task<RouteEntity> GetRouteById(int routeId)
        {
            return await Context.Connection.QuerySingleOrDefaultAsync<RouteEntity>(
                sql: $@"
                    SELECT 
                        R.RouteId,
                        R.ConcreteMixerTruckId,
                        R.CarriedOut,
                        R.Canceled,
                        R.CreateDatetime
                    FROM Route R
                    WHERE R.RouteId = @RouteId",
                param: new
                {
                    RouteId = routeId
                },
                transaction: Context.Transaction);
        }

        public async Task<int> InsertRoute(RouteEntity route)
        {
            return await Context.Connection.QuerySingleOrDefaultAsync<int>(
                sql: $@"
                    INSERT INTO Route (
                        ConcreteMixerTruckId,
                        CarriedOut,
                        Canceled,
                        CreateDatetime
                    ) VALUES (
                        @ConcreteMixerTruckId,
                        @CarriedOut,
                        @Canceled,
                        GETDATE()
                    )
                    SELECT SCOPE_IDENTITY()",
                param: new
                {
                    ConcreteMixerTruckId = route.ConcreteMixerTruckId,
                    CarriedOut = route.CarriedOut,
                    Canceled = route.Canceled
                },
                transaction: Context.Transaction);
        }

        public async Task<bool> CarryOutRoute(int routeId)
        {
            var amountOfAffectedRows = await Context.Connection.ExecuteAsync(
                sql: $@"
                    UPDATE Route 
                    SET CarriedOut = 1
                    WHERE RouteId = @RouteId",
                param: new 
                {
                    RouteId = routeId
                },
                transaction: Context.Transaction);

            return amountOfAffectedRows > 0;
        }

        public async Task<bool> CancelRoute(int routeId)
        {
            var amountOfAffectedRows = await Context.Connection.ExecuteAsync(
                sql: $@"
                    UPDATE Route 
                    SET Canceled = 1
                    WHERE RouteId = @RouteId",
                param: new
                {
                    RouteId = routeId
                },
                transaction: Context.Transaction);

            return amountOfAffectedRows > 0;
        }

        public async Task<bool> CancelActiveRoutes()
        {
            var amountOfAffectedRows = await Context.Connection.ExecuteAsync(
                sql: $@"
                    UPDATE Route 
                    SET Canceled = 1
                    WHERE CarriedOut = 0
                    AND Canceled = 0",
                transaction: Context.Transaction);

            return amountOfAffectedRows > 0;
        }
    }
}
