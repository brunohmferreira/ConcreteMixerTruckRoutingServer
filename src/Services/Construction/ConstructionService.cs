using ConcreteMixerTruckRoutingServer.Dtos.Construction;
using ConcreteMixerTruckRoutingServer.Exceptions.General;
using ConcreteMixerTruckRoutingServer.Services.Base;
using ConcreteMixerTruckRoutingServer.Services.Construction.Validation;
using ConcreteMixerTruckRoutingServer.Services.Extensions;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.Client;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.ConcreteType;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.Construction;
using ConcreteMixerTruckRoutingServer.UnitOfWorks.Interfaces;

namespace ConcreteMixerTruckRoutingServer.Services.Construction
{
    public class ConstructionService : ServiceBase, IConstructionService
    {
        #region Properties

        private readonly IClientService ClientService;
        private readonly IConcreteTypeService ConcreteTypeService;

        #endregion

        #region Constructor

        public ConstructionService(IDatabaseUnitOfWork unitOfWork, IClientService clientService, IConcreteTypeService concreteTypeService) : base(unitOfWork)
        {
            ClientService = clientService;
            ConcreteTypeService = concreteTypeService;
        }

        #endregion

        #region public

        public async Task<List<GetResponseDto>> GetConstructionsList()
        {
            var response = new List<GetResponseDto>();
            var constructionsList = await DatabaseUnitOfWork.Construction.GetConstructionsList();

            foreach (var construction in constructionsList)
            {
                var clientDto = await ClientService.GetClientById(construction.ClientId);
                var concreteTypeDto = await ConcreteTypeService.GetConcreteTypeById(construction.ConcreteTypeId);

                var dto = new GetResponseDto()
                {
                    ConstructionId = construction.ConstructionId,
                    Description = construction.Description,
                    VolumeDemand = construction.VolumeDemand,
                    Delivered = construction.Delivered,
                    Client = clientDto,
                    ConcreteType = concreteTypeDto
                };

                response.Add(dto);
            }

            return response;
        }

        public async Task<GetResponseDto> GetConstructionById(int constructionId)
        {
            var construction = await DatabaseUnitOfWork.Construction.GetConstructionById(constructionId).ValidateItemNotFound();

            var clientDto = new Dtos.Client.GetResponseDto();
            if (construction.ClientId != 0)
                clientDto = await ClientService.GetClientById(construction.ClientId);
            else
                throw new ItemNotFoundException("client");

            var concreteTypeDto = new Dtos.ConcreteType.GetResponseDto();
            if (construction.ConcreteTypeId != 0)
                concreteTypeDto = await ConcreteTypeService.GetConcreteTypeById(construction.ConcreteTypeId);
            else
                throw new ItemNotFoundException("concrete type");

            var response = new GetResponseDto()
            {
                ConstructionId = construction.ConstructionId,
                Description = construction.Description,
                VolumeDemand = construction.VolumeDemand,
                Delivered = construction.Delivered,
                Client = clientDto,
                ConcreteType = concreteTypeDto
            };

            return response;
        }

        public async Task<int> InsertConstruction(PostRequestDto dto)
        {
            await dto.Validate<InsertValidation, PostRequestDto>(DatabaseUnitOfWork);

            var response = await TransactionExtension.ExecuteInTransactionAsync(async () =>
            {
                if (!dto.Client.ClientId.HasValue)
                    dto.Client.ClientId = await ClientService.InsertClient(dto.Client);

                if (!dto.ConcreteType.ConcreteTypeId.HasValue)
                    dto.ConcreteType.ConcreteTypeId = await ConcreteTypeService.InsertConcreteType(dto.ConcreteType);

                int constructionId = await DatabaseUnitOfWork.Construction.InsertConstruction(dto);
                return constructionId;
            }, DatabaseUnitOfWork);

            return response;
        }

        #endregion
    }
}
