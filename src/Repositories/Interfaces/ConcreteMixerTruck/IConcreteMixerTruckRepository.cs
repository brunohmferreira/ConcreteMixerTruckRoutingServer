using ConcreteMixerTruckRoutingServer.Entities;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Base;

namespace ConcreteMixerTruckRoutingServer.Repositories.Interfaces.ConcreteMixerTruck
{
    public interface IConcreteMixerTruckRepository : IRepositoryContext
    {
        Task<IEnumerable<ConcreteMixerTruckEntity>> GetConcreteMixerTrucksList();
    }
}
