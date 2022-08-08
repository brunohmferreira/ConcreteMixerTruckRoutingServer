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

        public async Task<List<GetResponseDto>> GetConcreteTypesList()
        {
            var response = new List<GetResponseDto>();
            var concreteTypesList = await DatabaseUnitOfWork.ConcreteType.GetConcreteTypesList().ValidateEmptyList();

            foreach (var concreteType in concreteTypesList)
            {
                var dto = new GetResponseDto()
                {
                    ConcreteTypeId = concreteType.ConcreteTypeId,
                    Description = concreteType.Description
                };

                response.Add(dto);
            }

            return response;
        }

        public async Task<GetResponseDto> GetConcreteTypeById(int concreteTypeId)
        {
            var entity = await DatabaseUnitOfWork.ConcreteType.GetConcreteTypeById(concreteTypeId).ValidateItemNotFound();

            if (entity == null)
                throw new GenericBadRequestException("The concrete type requested was not found.");

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
                return await DatabaseUnitOfWork.ConcreteType.InsertConcreteType(dto);
            }, DatabaseUnitOfWork);

            return response;
        }

        public async Task<bool> UpdateConcreteType(PutRequestDto dto)
        {
            await dto.Validate<UpdateValidation, PutRequestDto>(DatabaseUnitOfWork);

            var response = await TransactionExtension.ExecuteInTransactionAsync(async () =>
            {
                return await DatabaseUnitOfWork.ConcreteType.UpdateConcreteType(dto);
            }, DatabaseUnitOfWork);

            return response;
        }

        #endregion
    }
}
