using ConcreteMixerTruckRoutingServer.Dtos.Address;

namespace ConcreteMixerTruckRoutingServer.Services.Interfaces.Address
{
    public interface IAddressService
    {
        Task<GetResponseDto> GetAddressByConstructionId(int constructionId);
        Task<int> InsertAddress(PostRequestDto dto, int constructionId);
        Task<bool> UpdateAddress(PutRequestDto dto, int constructionId);
        Task<bool> DeleteAddress(int constructionId);
    }
}
