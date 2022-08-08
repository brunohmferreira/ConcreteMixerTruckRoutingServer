namespace ConcreteMixerTruckRoutingServer.Dtos.ConcreteType
{
    public class PutRequestDto
	{
		public PutRequestDto()
		{
			Description = string.Empty;
		}

		public int? ConcreteTypeId { get; set; }
		public string Description { get; set; }
		public bool Available { get; set; }
	}
}
