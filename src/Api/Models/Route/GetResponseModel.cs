namespace ConcreteMixerTruckRoutingServer.Api.Models.Route
{
    public class GetResponseModel
    {
        public GetResponseModel()
        {
            SubRoutes = new List<SubRoute.GetResponseModel>();
        }

        public int RouteId { get; set; }
        public int ConcreteMixerTruckId { get; set; }
        public List<SubRoute.GetResponseModel> SubRoutes { get; set; }
    }
}
