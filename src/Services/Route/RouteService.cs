using ConcreteMixerTruckRoutingServer.Dtos.Route;
using ConcreteMixerTruckRoutingServer.Entities;
using ConcreteMixerTruckRoutingServer.Exceptions.General;
using ConcreteMixerTruckRoutingServer.Services.Base;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.Construction;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.Route;
using ConcreteMixerTruckRoutingServer.UnitOfWorks.Interfaces;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace ConcreteMixerTruckRoutingServer.Services.Route
{
    public class RouteService : ServiceBase, IRouteService
    {
        #region Properties

        private readonly IConstructionService ConstructionService;

        #endregion

        #region Constructor

        public RouteService(IDatabaseUnitOfWork unitOfWork, IConstructionService constructionService) : base(unitOfWork)
        {
            ConstructionService = constructionService;
        }

        #endregion

        #region public

        [DllImport("..\\..\\..\\..\\x64\\Debug\\optimisation.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public extern static void ExecuteProcess(byte[] response, byte[] request);


        public async Task<List<GetResponseDto>> GetRoutes()
        {
            var response = new List<GetResponseDto>();

            var routesList = await DatabaseUnitOfWork.Route.GetPendingRoutesList();

            foreach(var route in routesList)
            {
                var subRoutesList = await DatabaseUnitOfWork.SubRoute.GetSubRoutesByRoute(route.RouteId);

                var subRoutesDto = new List<Dtos.SubRoute.GetResponseDto>();

                foreach(var subRoute in subRoutesList)
                {
                    var origin = new Dtos.Construction.GetResponseDto();
                    if (subRoute.ConstructionOriginId != 0)
                        origin = await ConstructionService.GetConstructionById(subRoute.ConstructionOriginId);

                    var destiny = new Dtos.Construction.GetResponseDto();
                    if (subRoute.ConstructionDestinyId != 0)
                        destiny = await ConstructionService.GetConstructionById(subRoute.ConstructionDestinyId);

                    var subRouteDto = new Dtos.SubRoute.GetResponseDto()
                    {
                        SubRouteId = subRoute.RouteId,
                        ConstructionOriginId = subRoute.ConstructionOriginId,
                        ConstructionDestinyId = subRoute.ConstructionDestinyId,
                        ConstructionOrigin = origin,
                        ConstructionDestiny = destiny
                    };

                    subRoutesDto.Add(subRouteDto);
                }

                var dto = new GetResponseDto()
                {
                    RouteId = route.RouteId,
                    ConcreteMixerTruckId = route.ConcreteMixerTruckId,
                    SubRoutes = subRoutesDto
                };

                response.Add(dto);
            }

            return response;
        }

        public async Task<CalculationResponseDto> CalculateRoutes(List<PostRequestDto> constructionList, List<List<double>> distanceMatrix)
        {
            try
            {
                var constructionListWithDepot = new List<PostRequestDto>();
                constructionListWithDepot.Add(new PostRequestDto());
                constructionListWithDepot.AddRange(constructionList);

                var concreteMixerTruckList = (await DatabaseUnitOfWork.ConcreteMixerTruck.GetConcreteMixerTrucksList()).ToList();
                var concreteTypesList = (await DatabaseUnitOfWork.ConcreteType.GetConcreteTypesList()).ToList();


                string requestString = await GenerateRequestString(constructionListWithDepot, concreteMixerTruckList, concreteTypesList, distanceMatrix);

                byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(requestString);
                byte[] buffer = new byte[1000000];

                ExecuteProcess(buffer, requestBytes);
                var jsonData = System.Text.Encoding.ASCII.GetString(buffer);

                if(jsonData == null)
                    throw new OptimisationBadRequestException();

                CalculationResponseDto dto = JsonConvert.DeserializeObject<CalculationResponseDto>(jsonData);

                if (dto == null)
                    throw new ItemNotFoundException("Route");

                await SaveRoutes(dto, constructionListWithDepot, concreteMixerTruckList);

                return dto;
            }
            catch (Exception ex)
            {
                throw new OptimisationBadRequestException();
            }
        }

        public async Task<bool> CarryOutRoute(int routeId)
        {
            var response = await DatabaseUnitOfWork.Route.CarryOutRoute(routeId);

            var route = await DatabaseUnitOfWork.Route.GetRouteById(routeId);
            response = await DatabaseUnitOfWork.ConcreteMixerTruck.MakeConcreteMixerTruckUnavailable(route.ConcreteMixerTruckId);

            var subRoutes = await DatabaseUnitOfWork.SubRoute.GetSubRoutesByRoute(route.RouteId);
            foreach (var subRoute in subRoutes)
            {
                if (subRoute.ConstructionDestinyId != 0)
                    response = await DatabaseUnitOfWork.Construction.DeliverConstruction(subRoute.ConstructionDestinyId);
            }

            return response;
        }
        
        public async Task<bool> CancelRoute(int routeId)
        {
            return await DatabaseUnitOfWork.Route.CancelRoute(routeId);
        }

        #endregion

        #region private

        private async Task<string> GenerateRequestString(List<PostRequestDto> constructionList, List<ConcreteMixerTruckEntity> concreteMixerTruckList, List<ConcreteTypeEntity> concreteTypesList, List<List<double>> distanceMatrix)
        {
            var requestString = string.Empty;

            requestString += "numberOfConstructions: ";
            requestString += (constructionList.Count - 1).ToString() + " ";
            requestString += "concreteMixerTruckFleet: ";
            requestString += concreteMixerTruckList.Count.ToString() + " ";
            requestString += "numberOfTypesOfConcrete: ";
            requestString += concreteTypesList.Count.ToString() + " ";
            requestString += "fixedCostOfUsingTheConcreteMixerTruck: ";
            requestString += concreteMixerTruckList.FirstOrDefault()?.UseCost.ToString() + " ";
            requestString += "concreteMixerTruckCapacity: ";
            requestString += concreteMixerTruckList.FirstOrDefault()?.MaximumCapacity.ToString() + " ";
            requestString += "demands: ";

            for (var i = 0; i < constructionList.Count; i++)
            {
                requestString += i.ToString() + " " + constructionList[i].VolumeDemand.ToString() + " " + (constructionList[i].ConcreteType.ConcreteTypeId ?? 0).ToString() + " ";
            }

            requestString += "distances: ";

            foreach(var line in distanceMatrix)
            {
                foreach(var item in line)
                {
                    requestString += item.ToString() + " ";
                }
            }

            return requestString;
        }

        private async Task SaveRoutes(CalculationResponseDto? dto, List<PostRequestDto> constructionList, List<ConcreteMixerTruckEntity> concreteMixerTruckList)
        {
            await DatabaseUnitOfWork.Route.CancelActiveRoutes();

            for (var k = 0; k < dto.sol_y.Count; k++)
            {
                if (dto.sol_y[k] == 1)
                {
                    RouteEntity routeEntity = new RouteEntity()
                    {
                        ConcreteMixerTruckId = concreteMixerTruckList[k].ConcreteMixerTruckId,
                        CarriedOut = false,
                        Canceled = false
                    };

                    routeEntity.RouteId = await DatabaseUnitOfWork.Route.InsertRoute(routeEntity);

                    for (var i = 0; i < dto.sol_x[k].Count; i++)
                    {
                        for (var j = 0; j < dto.sol_x[k][i].Count; j++)
                        {
                            if (dto.sol_x[k][i][j] == 1)
                            {
                                SubRouteEntity subRouteEntity = new SubRouteEntity()
                                {
                                    RouteId = routeEntity.RouteId,
                                    ConstructionOriginId = constructionList[i].ConstructionId,
                                    ConstructionDestinyId = constructionList[j].ConstructionId
                                };

                                subRouteEntity.SubRouteId = await DatabaseUnitOfWork.SubRoute.InsertSubRoute(subRouteEntity);
                            }

                        }
                    }
                }
            }
        }

        #endregion
    }
}
