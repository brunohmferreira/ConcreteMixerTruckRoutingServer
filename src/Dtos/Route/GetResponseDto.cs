namespace ConcreteMixerTruckRoutingServer.Dtos.Route
{
    public class GetResponseDto
    {
        public GetResponseDto()
        {
            SubRoutes = new List<SubRoute.GetResponseDto>();
        }

        public int RouteId { get; set; }
        public int ConcreteMixerTruckId { get; set; }
        public List<SubRoute.GetResponseDto> SubRoutes { get; set; }
    }
}
