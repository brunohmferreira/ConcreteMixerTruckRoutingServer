using ConcreteMixerTruckRoutingServer.Entities.Base;

namespace ConcreteMixerTruckRoutingServer.Entities
{
    public class ConstructionEntity : EntityBase
    {
		public ConstructionEntity()
		{
			Description = string.Empty;
		}

		public int ConstructionId { get; set; }
		public string Description { get; set; }
		public int ClientId { get; set; }
		public int ConcreteTypeId { get; set; }
		public decimal VolumeDemand { get; set; }
		public bool Delivered { get; set; }
		public DateTime ChangeDatetime { get; set; }

	}
}
