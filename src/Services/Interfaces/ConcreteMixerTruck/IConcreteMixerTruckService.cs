
using ConcreteMixerTruckRoutingServer.Dtos.ConcreteMixerTruck;

namespace ConcreteMixerTruckRoutingServer.Services.Interfaces.ConcreteMixerTruck
{
    public interface IConcreteMixerTruckService
    {
        Task<List<GetResponseDto>> GetConcreteMixerTrucksList();
    }
}
