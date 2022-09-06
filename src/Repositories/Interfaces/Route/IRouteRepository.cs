using ConcreteMixerTruckRoutingServer.Entities;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Base;

namespace ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Route
{
    public interface IRouteRepository : IRepositoryContext
    {
        Task<IEnumerable<RouteEntity>> GetPendingRoutesList();
        Task<RouteEntity> GetRouteById(int routeId);
        Task<int> InsertRoute(RouteEntity route);
        Task<bool> CarryOutRoute(int routeId);
        Task<bool> CancelRoute(int routeId);
        Task<bool> CancelActiveRoutes();
    }
}
