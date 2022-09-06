namespace ConcreteMixerTruckRoutingServer.Api.Models.SubRoute
{
    public class GetResponseModel
    {
        public GetResponseModel()
        {
            ConstructionOrigin = new Construction.GetResponseModel();
            ConstructionDestiny = new Construction.GetResponseModel();
        }

        public int SubRouteId { get; set; }
        public int ConstructionOriginId { get; set; }
        public int ConstructionDestinyId { get; set; }
        public Construction.GetResponseModel ConstructionOrigin { get; set; }
        public Construction.GetResponseModel ConstructionDestiny { get; set; }
    }
}
