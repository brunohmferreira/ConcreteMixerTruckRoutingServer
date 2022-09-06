﻿namespace ConcreteMixerTruckRoutingServer.Api.Models.Route
{
	public class PostRequestModel
	{
		public PostRequestModel()
		{
			Description = string.Empty;
			Client = new Client.PostRequestModel();
			ConcreteType = new ConcreteType.PostRequestModel();
			Address = new Address.PostRequestModel();
		}

		public int ConstructionId { get; set; }
		public string Description { get; set; }
		public decimal VolumeDemand { get; set; }
		public bool Delivered { get; set; }
		public Client.PostRequestModel Client { get; set; }
		public ConcreteType.PostRequestModel ConcreteType { get; set; }
		public Address.PostRequestModel Address { get; set; }
	}
}
