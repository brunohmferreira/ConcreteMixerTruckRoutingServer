using ConcreteMixerTruckRoutingServer.Entities;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Base;

namespace ConcreteMixerTruckRoutingServer.Repositories.Interfaces.SubRoute
{
    public interface ISubRouteRepository : IRepositoryContext
    {
        Task<IEnumerable<SubRouteEntity>> GetSubRoutesByRoute(int routeId);
        Task<int> InsertSubRoute(SubRouteEntity subRoute);
    }
}
