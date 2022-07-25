using ConcreteMixerTruckRoutingServer.Dtos.ConcreteType;

namespace ConcreteMixerTruckRoutingServer.Services.Interfaces.ConcreteType
{
    public interface IConcreteTypeService
    {
        Task<GetResponseDto> GetConcreteTypeById(int concreteTypeId);
        Task<int> InsertConcreteType(PostRequestDto dto);
        Task<bool> UpdateConcreteType(PutRequestDto dto);
    }
}
