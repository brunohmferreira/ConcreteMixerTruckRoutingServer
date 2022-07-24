namespace ConcreteMixerTruckRoutingServer.Api.Models.Client
{
	public class PostRequestModel
	{
		public PostRequestModel()
		{
			Name = string.Empty;
		}

		public int? ClientId { get; set; }
		public string Name { get; set; }
	}
}
