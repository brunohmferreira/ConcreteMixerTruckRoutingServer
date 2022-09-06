namespace ConcreteMixerTruckRoutingServer.Dtos.Route
{
    public class PostRequestDto
    {
        public PostRequestDto()
        {
            Description = string.Empty;
            Client = new Client.PostRequestDto();
            ConcreteType = new ConcreteType.PostRequestDto();
            Address = new Address.PostRequestDto();
        }

        public int ConstructionId { get; set; }
        public string Description { get; set; }
        public decimal VolumeDemand { get; set; }
        public bool Delivered { get; set; }
        public Client.PostRequestDto Client { get; set; }
        public ConcreteType.PostRequestDto ConcreteType { get; set; }
        public Address.PostRequestDto Address { get; set; }
    }
}
