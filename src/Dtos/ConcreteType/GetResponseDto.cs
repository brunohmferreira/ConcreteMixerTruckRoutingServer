namespace ConcreteMixerTruckRoutingServer.Dtos.ConcreteType
{
    public class GetResponseDto
	{
		public GetResponseDto()
		{
			Description = string.Empty;
		}

		public int ConcreteTypeId { get; set; }
		public string Description { get; set; }
	}
}
