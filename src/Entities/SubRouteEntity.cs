using ConcreteMixerTruckRoutingServer.Entities.Base;

namespace ConcreteMixerTruckRoutingServer.Entities
{
    public class SubRouteEntity : EntityBase
    {
		public int SubRouteId { get; set; }
		public int RouteId { get; set; }
		public int ConstructionOriginId { get; set; }
		public int ConstructionDestinyId { get; set; }
	}
}
