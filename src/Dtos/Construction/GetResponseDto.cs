namespace ConcreteMixerTruckRoutingServer.Dtos.Construction
{
    public class GetResponseDto
    {
        public GetResponseDto()
        {
            Description = string.Empty;
            Client = new Client.GetResponseDto();
            ConcreteType = new ConcreteType.GetResponseDto();
        }

        public int ConstructionId { get; set; }
        public string Description { get; set; }
        public decimal VolumeDemand { get; set; }
        public bool Delivered { get; set; }
        public Client.GetResponseDto Client { get; set; }
        public ConcreteType.GetResponseDto ConcreteType { get; set; }
    }
}
