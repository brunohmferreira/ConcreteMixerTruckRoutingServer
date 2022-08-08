using ConcreteMixerTruckRoutingServer.Dtos.Address;
using ConcreteMixerTruckRoutingServer.Services.Address.Validation;
using ConcreteMixerTruckRoutingServer.Services.Base;
using ConcreteMixerTruckRoutingServer.Services.Extensions;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.Address;
using ConcreteMixerTruckRoutingServer.UnitOfWorks.Interfaces;

namespace ConcreteMixerTruckRoutingServer.Services.Address
{
    public class AddressService : ServiceBase, IAddressService
    {
        #region Constructor

        public AddressService(IDatabaseUnitOfWork unitOfWork) : base(unitOfWork) { }

        #endregion

        #region public

        public async Task<GetResponseDto> GetAddressByConstructionId(int constructionId)
        {
            var entity = await DatabaseUnitOfWork.Address.GetAddressByConstructionId(constructionId).ValidateItemNotFound();

            var response = new GetResponseDto()
            {
                AddressId = entity.AddressId,
                Street = entity.Street,
                Number = entity.Number,
                NoNumber = entity.NoNumber,
                Complement = entity.Complement,
                Neighborhood = entity.Neighborhood,
                ZipCode = entity.ZipCode,
                City = entity.City,
                State = entity.State,
                Country = entity.Country,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude
            };

            return response;
        }

        public async Task<int> InsertAddress(PostRequestDto dto, int constructionId)
        {
            dto.Latitude = 1;
            dto.Longitude = 1;
            await dto.Validate<InsertValidation, PostRequestDto>(DatabaseUnitOfWork);

            var response = await TransactionExtension.ExecuteInTransactionAsync(async () =>
            {
                return await DatabaseUnitOfWork.Address.InsertAddress(dto, constructionId);
            }, DatabaseUnitOfWork);

            return response;
        }

        public async Task<bool> UpdateAddress(PutRequestDto dto, int constructionId)
        {
            dto.Latitude = 1;
            dto.Longitude = 1;
            await dto.Validate<UpdateValidation, PutRequestDto>(DatabaseUnitOfWork);

            var response = await TransactionExtension.ExecuteInTransactionAsync(async () =>
            {
                return await DatabaseUnitOfWork.Address.UpdateAddress(dto, constructionId);
            }, DatabaseUnitOfWork);

            return response;
        }

        public async Task<bool> DeleteAddress(int constructionId)
        {
            var response = await TransactionExtension.ExecuteInTransactionAsync(async () =>
            {
                var deleted = await DatabaseUnitOfWork.Address.DeleteAddress(constructionId);
                return deleted;
            }, DatabaseUnitOfWork);

            return response;
        }

        #endregion
    }
}
