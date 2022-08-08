using ConcreteMixerTruckRoutingServer.Dtos.ConcreteMixerTruck;
using ConcreteMixerTruckRoutingServer.Services.Base;
using ConcreteMixerTruckRoutingServer.Services.Extensions;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.ConcreteMixerTruck;
using ConcreteMixerTruckRoutingServer.UnitOfWorks.Interfaces;

namespace ConcreteMixerTruckRoutingServer.Services.ConcreteMixerTruck
{
    public class ConcreteMixerTruckService : ServiceBase, IConcreteMixerTruckService
    {
        #region Constructor

        public ConcreteMixerTruckService(IDatabaseUnitOfWork unitOfWork) : base(unitOfWork) { }

        #endregion

        #region public

        public async Task<List<GetResponseDto>> GetConcreteMixerTrucksList()
        {
            var response = new List<GetResponseDto>();
            var concreteMixerTrucksList = await DatabaseUnitOfWork.ConcreteMixerTruck.GetConcreteMixerTrucksList().ValidateEmptyList();

            foreach (var concreteMixerTruck in concreteMixerTrucksList)
            {
                var dto = new GetResponseDto()
                {
                    ConcreteMixerTruckId = concreteMixerTruck.ConcreteMixerTruckId,
                    MaximumCapacity = concreteMixerTruck.MaximumCapacity,
                    UseCost = concreteMixerTruck.UseCost
                };

                response.Add(dto);
            }

            return response;
        }

        #endregion
    }
}
