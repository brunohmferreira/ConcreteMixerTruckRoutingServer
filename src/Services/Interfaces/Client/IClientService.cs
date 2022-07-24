using ConcreteMixerTruckRoutingServer.Dtos.Client;

namespace ConcreteMixerTruckRoutingServer.Services.Interfaces.Client
{
    public interface IClientService
    {
        Task<GetResponseDto> GetClientById(int clientId);
        Task<int> InsertClient(PostRequestDto dto);
    }
}
