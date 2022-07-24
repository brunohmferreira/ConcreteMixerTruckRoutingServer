namespace ConcreteMixerTruckRoutingServer.Api.Models.Client
{
	public class GetResponseModel
	{
		public GetResponseModel()
		{
			Name = string.Empty;
		}

		public int ClientId { get; set; }
		public string Name { get; set; }
	}
}
