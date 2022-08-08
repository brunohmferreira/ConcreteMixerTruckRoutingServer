namespace ConcreteMixerTruckRoutingServer.Dtos.ConcreteMixerTruck
{
    public class GetResponseDto
	{
		public int ConcreteMixerTruckId { get; set; }
		public decimal MaximumCapacity { get; set; }
		public decimal UseCost { get; set; }
	}
}
