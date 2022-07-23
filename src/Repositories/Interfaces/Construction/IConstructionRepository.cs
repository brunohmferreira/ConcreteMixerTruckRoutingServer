using ConcreteMixerTruckRoutingServer.Dtos.Constrution;
using ConcreteMixerTruckRoutingServer.Entities;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Base;

namespace ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Construction
{
    public interface IConstructionRepository : IRepositoryContext
    {
        Task<IEnumerable<ConstructionEntity>> GetConstructionsList();
        Task<ConstructionEntity> GetConstructionById(int constructionId);
    }
}
