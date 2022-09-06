namespace ConcreteMixerTruckRoutingServer.Api.Models.Route
{
    public class CalculationRequestModel
    {
        public List<PostRequestModel> Constructions { get; set; }
        public List<List<double>> DistanceMatrix { get; set; }
    }
}
