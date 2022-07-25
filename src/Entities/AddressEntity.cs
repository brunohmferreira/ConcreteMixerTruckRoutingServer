﻿using ConcreteMixerTruckRoutingServer.Entities.Base;

namespace ConcreteMixerTruckRoutingServer.Entities
{
    public class AddressEntity : EntityBase
    {
		public AddressEntity()
		{
			Street = string.Empty;
			Neighborhood = string.Empty;
			ZipCode = "00000000";
			City = string.Empty;
			State = string.Empty;
			Country = string.Empty;
		}

		public int AddressId { get; set; }
		public string Street { get; set; }
		public int? Number { get; set; }
		public bool NoNumber { get; set; }
		public string? Complement { get; set; }
		public string Neighborhood { get; set; }
		public string ZipCode { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public decimal Latitude { get; set; }
		public decimal Longitude { get; set; }
		public DateTime ChangeDatetime { get; set; }
	}
}
