using ConcreteMixerTruckRoutingServer.Dtos.ConcreteType;
using ConcreteMixerTruckRoutingServer.Entities;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Base;

namespace ConcreteMixerTruckRoutingServer.Repositories.Interfaces.ConcreteType
{
    public interface IConcreteTypeRepository : IRepositoryContext
    {
        Task<IEnumerable<ConcreteTypeEntity>> GetConcreteTypesList();
        Task<ConcreteTypeEntity> GetConcreteTypeById(int concreteTypeId);
        Task<IEnumerable<ClientEntity>> GetConcreteTypeByFilter(GetRequestDto filter);
        Task<int> InsertConcreteType(PostRequestDto dto);
        Task<bool> UpdateConcreteType(PutRequestDto dto);
    }
}
