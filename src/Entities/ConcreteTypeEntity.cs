using ConcreteMixerTruckRoutingServer.Entities.Base;

namespace ConcreteMixerTruckRoutingServer.Entities
{
    public class ConcreteTypeEntity : EntityBase
    {
		public ConcreteTypeEntity()
		{
			Description = string.Empty;
		}

		public int ConcreteTypeId { get; set; }
		public string Description { get; set; }
		public bool Available { get; set; }
		public DateTime ChangeDatetime { get; set; }

	}
}
