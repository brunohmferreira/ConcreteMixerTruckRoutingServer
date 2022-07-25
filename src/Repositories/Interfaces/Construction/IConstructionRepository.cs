using ConcreteMixerTruckRoutingServer.Dtos.Construction;
using ConcreteMixerTruckRoutingServer.Entities;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Base;

namespace ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Construction
{
    public interface IConstructionRepository : IRepositoryContext
    {
        Task<IEnumerable<ConstructionEntity>> GetConstructionsList();
        Task<ConstructionEntity> GetConstructionById(int constructionId);
        Task<IEnumerable<ConstructionEntity>> GetConstructionsByFilter(GetRequestDto filter);
        Task<int> InsertConstruction(PostRequestDto dto);
        Task<bool> UpdateConstruction(PutRequestDto dto);
        Task<bool> DeleteConstruction(int constructionId);
    }
}
