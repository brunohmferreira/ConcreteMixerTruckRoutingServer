namespace ConcreteMixerTruckRoutingServer.Dtos.Client
{
    public class PutRequestDto
	{
		public PutRequestDto()
		{
			Name = string.Empty;
		}

		public int? ClientId { get; set; }
		public string Name { get; set; }
	}
}
