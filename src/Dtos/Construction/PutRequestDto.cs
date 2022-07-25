namespace ConcreteMixerTruckRoutingServer.Dtos.Construction
{
    public class PutRequestDto
    {
        public PutRequestDto()
        {
            Description = string.Empty;
            Client = new Client.PutRequestDto();
            ConcreteType = new ConcreteType.PutRequestDto();
            Address = new Address.PutRequestDto();
        }

        public int ConstructionId { get; set; }
        public string Description { get; set; }
        public decimal VolumeDemand { get; set; }
        public bool Delivered { get; set; }
        public Client.PutRequestDto Client { get; set; }
        public ConcreteType.PutRequestDto ConcreteType { get; set; }
        public Address.PutRequestDto Address { get; set; }
    }
}
