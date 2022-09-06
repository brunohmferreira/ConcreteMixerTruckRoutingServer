using ConcreteMixerTruckRoutingServer.Dtos.Route;

namespace ConcreteMixerTruckRoutingServer.Services.Interfaces.Route
{
    public interface IRouteService
    {
        Task<List<GetResponseDto>> GetRoutes();
        Task<CalculationResponseDto> CalculateRoutes(List<PostRequestDto> dto, List<List<double>> distanceMatrix);
        Task<bool> CarryOutRoute(int routeId);
        Task<bool> CancelRoute(int routeId);
    }
}
