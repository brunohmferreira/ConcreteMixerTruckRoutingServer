using ConcreteMixerTruckRoutingServer.Entities.Base;

namespace ConcreteMixerTruckRoutingServer.Entities
{
    public class RouteEntity : EntityBase
    {
		public int RouteId { get; set; }
		public int ConcreteMixerTruckId { get; set; }
		public bool CarriedOut { get; set; }
		public bool Canceled { get; set; }
		public DateTime CreateDatetime { get; set; }
	}
}
