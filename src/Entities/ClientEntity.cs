using ConcreteMixerTruckRoutingServer.Entities.Base;

namespace ConcreteMixerTruckRoutingServer.Entities
{
    public class ClientEntity : EntityBase
    {
		public ClientEntity()
		{
			Name = string.Empty;
		}

		public int ClientId { get; set; }
		public string Name { get; set; }
		public DateTime ChangeDatetime { get; set; }

	}
}
