namespace ConcreteMixerTruckRoutingServer.Dtos.Construction
{
    public class PostRequestDto
    {
        public PostRequestDto()
        {
            Description = string.Empty;
            Client = new Client.PostRequestDto();
            ConcreteType = new ConcreteType.PostRequestDto();
        }

        public string Description { get; set; }
        public decimal VolumeDemand { get; set; }
        public bool Delivered { get; set; }
        public Client.PostRequestDto Client { get; set; }
        public ConcreteType.PostRequestDto ConcreteType { get; set; }
    }
}
