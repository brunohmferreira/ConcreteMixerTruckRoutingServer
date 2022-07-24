using ConcreteMixerTruckRoutingServer.Dtos.Client;
using ConcreteMixerTruckRoutingServer.Services.Base;
using ConcreteMixerTruckRoutingServer.Services.Client.Validation;
using ConcreteMixerTruckRoutingServer.Services.Extensions;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.Client;
using ConcreteMixerTruckRoutingServer.UnitOfWorks.Interfaces;

namespace ConcreteMixerTruckRoutingServer.Services.Client
{
    public class ClientService : ServiceBase, IClientService
    {
        #region Constructor

        public ClientService(IDatabaseUnitOfWork unitOfWork) : base(unitOfWork) { }

        #endregion

        #region public

        public async Task<GetResponseDto> GetClientById(int clientId)
        {
            var entity = await DatabaseUnitOfWork.Client.GetClientById(clientId);

            var response = new GetResponseDto()
            {
                ClientId = entity.ClientId,
                Name = entity.Name
            };

            return response;
        }

        public async Task<int> InsertClient(PostRequestDto dto)
        {
            await dto.Validate<InsertValidation, PostRequestDto>(DatabaseUnitOfWork);

            var response = await TransactionExtension.ExecuteInTransactionAsync(async () =>
            {
                int clientId = await DatabaseUnitOfWork.Client.InsertClient(dto);
                return clientId;
            }, DatabaseUnitOfWork);

            return response;
        }

        #endregion
    }
}
