using ConcreteMixerTruckRoutingServer.Entities.Base;

namespace ConcreteMixerTruckRoutingServer.Entities
{
    public class ConcreteMixerTruckEntity : EntityBase
    {
		public int ConcreteMixerTruckId { get; set; }
		public decimal MaximumCapacity { get; set; }
		public decimal UseCost { get; set; }
		public bool Available { get; set; }
		public DateTime ChangeDatetime { get; set; }

	}
}
