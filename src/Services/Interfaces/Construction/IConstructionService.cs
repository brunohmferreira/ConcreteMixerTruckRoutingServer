using ConcreteMixerTruckRoutingServer.Dtos.Construction;

namespace ConcreteMixerTruckRoutingServer.Services.Interfaces.Construction
{
    public interface IConstructionService
    {
        Task<List<GetResponseDto>> GetConstructionsList();
        Task<GetResponseDto> GetConstructionById(int constructionId);
        Task<int> InsertConstruction(PostRequestDto dto);
    }
}
