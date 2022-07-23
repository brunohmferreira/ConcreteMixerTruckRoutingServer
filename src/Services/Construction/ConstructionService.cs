using ConcreteMixerTruckRoutingServer.Dtos.Constrution;
using ConcreteMixerTruckRoutingServer.Services.Base;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.Construction;
using ConcreteMixerTruckRoutingServer.UnitOfWorks.Interfaces;

namespace ConcreteMixerTruckRoutingServer.Services.Construction
{
    public class ConstructionService : ServiceBase, IConstructionService
    {
        #region Constructor

        public ConstructionService(IDatabaseUnitOfWork unitOfWork) : base(unitOfWork) { }

        #endregion

        #region public

        public async Task<List<GetResponseDto>> GetConstructionsList()
        {
            var response = new List<GetResponseDto>();
            var constructionsList = await DatabaseUnitOfWork.Construction.GetConstructionsList();

            foreach (var construction in constructionsList)
            {
                var dto = new GetResponseDto()
                {
                    ConstructionId = construction.ConstructionId
                };

                response.Add(dto);
            }

            return response;
        }

        public async Task<GetResponseDto> GetConstructionById(int constructionId)
        {
            var construction = await DatabaseUnitOfWork.Construction.GetConstructionById(constructionId);

            // get client

            var response = new GetResponseDto()
            {
                ConstructionId = construction.ConstructionId
            };

            return response;
        }

        #endregion
    }
}
