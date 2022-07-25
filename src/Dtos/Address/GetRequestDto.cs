namespace ConcreteMixerTruckRoutingServer.Dtos.Address
{
    public class GetRequestDto
	{
		public string? Street { get; set; }
		public int? Number { get; set; }
		public bool? NoNumber { get; set; }
		public string? Complement { get; set; }
		public string? Neighborhood { get; set; }
		public string? ZipCode { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? Country { get; set; }
		public decimal? Latitude { get; set; }
		public decimal? Longitude { get; set; }
	}
}
