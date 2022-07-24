namespace ConcreteMixerTruckRoutingServer.Dtos.Client
{
    public class GetResponseDto
	{
		public GetResponseDto()
		{
			Name = string.Empty;
		}

		public int ClientId { get; set; }
		public string Name { get; set; }
	}
}
