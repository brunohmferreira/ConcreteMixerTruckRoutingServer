namespace ConcreteMixerTruckRoutingServer.Api.Models.Construction
{
    public class PutRequestModel
	{
		public PutRequestModel()
		{
			Description = string.Empty;
			Client = new Client.PutRequestModel();
			ConcreteType = new ConcreteType.PutRequestModel();
			Address = new Address.PutRequestModel();
		}

		public int ConstructionId { get; set; }
		public string Description { get; set; }
		public decimal VolumeDemand { get; set; }
		public bool Delivered { get; set; }
		public Client.PutRequestModel Client { get; set; }
		public ConcreteType.PutRequestModel ConcreteType { get; set; }
		public Address.PutRequestModel Address { get; set; }
	}
}
