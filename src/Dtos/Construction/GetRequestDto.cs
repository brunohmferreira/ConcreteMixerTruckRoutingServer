namespace ConcreteMixerTruckRoutingServer.Dtos.Construction
{
    public class GetRequestDto
    {
        public string? Description { get; set; }
        public decimal? VolumeDemand { get; set; }
        public bool? Delivered { get; set; }
    }
}
