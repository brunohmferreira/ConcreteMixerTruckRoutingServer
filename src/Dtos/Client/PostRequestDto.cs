namespace ConcreteMixerTruckRoutingServer.Dtos.Client
{
    public class PostRequestDto
	{
		public PostRequestDto()
		{
			Name = string.Empty;
		}

		public int? ClientId { get; set; }
		public string Name { get; set; }
	}
}
