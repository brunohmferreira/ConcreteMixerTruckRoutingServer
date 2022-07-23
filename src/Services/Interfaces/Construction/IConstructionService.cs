using ConcreteMixerTruckRoutingServer.Dtos.Constrution;

namespace ConcreteMixerTruckRoutingServer.Services.Interfaces.Construction
{
    public interface IConstructionService
    {
        Task<List<GetResponseDto>> GetConstructionsList();
        Task<GetResponseDto> GetConstructionById(int constructionId);
    }
}
