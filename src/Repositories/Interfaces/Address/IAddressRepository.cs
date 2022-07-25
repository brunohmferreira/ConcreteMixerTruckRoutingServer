using ConcreteMixerTruckRoutingServer.Dtos.Address;
using ConcreteMixerTruckRoutingServer.Entities;
using ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Base;

namespace ConcreteMixerTruckRoutingServer.Repositories.Interfaces.Address
{
    public interface IAddressRepository : IRepositoryContext
    {
        Task<AddressEntity> GetAddressByConstructionId(int constructionId);
        Task<int> InsertAddress(PostRequestDto dto, int constructionId);
        Task<bool> UpdateAddress(PutRequestDto dto, int constructionId);
        Task<bool> DeleteAddress(int constructionId);
    }
}
