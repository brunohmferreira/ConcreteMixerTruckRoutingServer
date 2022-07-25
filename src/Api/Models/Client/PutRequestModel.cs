namespace ConcreteMixerTruckRoutingServer.Api.Models.Client
{
	public class PutRequestModel
	{
		public PutRequestModel()
		{
			Name = string.Empty;
		}

		public int ClientId { get; set; }
		public string Name { get; set; }
	}
}
