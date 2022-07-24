namespace ConcreteMixerTruckRoutingServer.Api.Models.ConcreteType
{
	public class GetResponseModel
	{
		public GetResponseModel()
		{
			Description = string.Empty;
		}

		public int ConcreteTypeId { get; set; }
		public string Description { get; set; }
	}
}
