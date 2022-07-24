using ConcreteMixerTruckRoutingServer.Dtos.ConcreteType;
using ConcreteMixerTruckRoutingServer.Exceptions.General;
using ConcreteMixerTruckRoutingServer.Services.Base;
using ConcreteMixerTruckRoutingServer.Services.ConcreteType.Validation;
using ConcreteMixerTruckRoutingServer.Services.Extensions;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.ConcreteType;
using ConcreteMixerTruckRoutingServer.UnitOfWorks.Interfaces;

namespace ConcreteMixerTruckRoutingServer.Services.ConcreteType
{
    public class ConcreteTypeService : ServiceBase, IConcreteTypeService
    {
        #region Constructor

        public ConcreteTypeService(IDatabaseUnitOfWork unitOfWork) : base(unitOfWork) { }

        #endregion

        #region public

        public async Task<GetResponseDto> GetConcreteTypeById(int concreteTypeId)
        {
            var entity = await DatabaseUnitOfWork.ConcreteType.GetConcreteTypeById(concreteTypeId);

            if (!entity.Available)
                throw new GenericBadRequestException("The concrete type requested is not available.");

            var response = new GetResponseDto()
            {
                ConcreteTypeId = entity.ConcreteTypeId,
                Description = entity.Description
            };

            return response;
        }

        public async Task<int> InsertConcreteType(PostRequestDto dto)
        {
            await dto.Validate<InsertValidation, PostRequestDto>(DatabaseUnitOfWork);

            var response = await TransactionExtension.ExecuteInTransactionAsync(async () =>
            {
                int concreteTypeId = await DatabaseUnitOfWork.ConcreteType.InsertConcreteType(dto);
                return concreteTypeId;
            }, DatabaseUnitOfWork);

            return response;
        }

        #endregion
    }
}
