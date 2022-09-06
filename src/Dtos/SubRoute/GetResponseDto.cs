namespace ConcreteMixerTruckRoutingServer.Dtos.SubRoute
{
    public class GetResponseDto
    {
        public GetResponseDto()
        {
            ConstructionOrigin = new Construction.GetResponseDto();
            ConstructionDestiny = new Construction.GetResponseDto();
        }

        public int SubRouteId { get; set; }
        public int ConstructionOriginId { get; set; }
        public int ConstructionDestinyId { get; set; }
        public Construction.GetResponseDto ConstructionOrigin { get; set; }
        public Construction.GetResponseDto ConstructionDestiny { get; set; }

    }
}
