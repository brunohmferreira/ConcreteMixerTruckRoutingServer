namespace ConcreteMixerTruckRoutingServer.Api.Models.Construction
{
    public class GetResponseModel
    {
		public GetResponseModel()
		{
			Description = string.Empty;
			Client = new Client.GetResponseModel();
			ConcreteType = new ConcreteType.GetResponseModel();
			Address = new Address.GetResponseModel();
		}

		public int ConstructionId { get; set; }
		public string Description { get; set; }
		public decimal VolumeDemand { get; set; }
		public bool Delivered { get; set; }
		public Client.GetResponseModel Client { get; set; }
		public ConcreteType.GetResponseModel ConcreteType { get; set; }
		public Address.GetResponseModel Address { get; set; }
	}
}
