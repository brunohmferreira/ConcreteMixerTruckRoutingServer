namespace ConcreteMixerTruckRoutingServer.Api.Models.ConcreteType
{
	public class PostRequestModel
	{
		public PostRequestModel()
		{
			Description = string.Empty;
		}

		public int? ConcreteTypeId { get; set; }
		public string Description { get; set; }
		public bool Available { get; set; }
	}
}
