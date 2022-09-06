namespace ConcreteMixerTruckRoutingServer.Api.Models.Route
{
    public class CalculationResponseModel
    {
        public bool SolutionExists { get; set; }
        public bool SolutionIsInfeasible { get; set; }
        public bool SolutionsIsUnbounded { get; set; }
        public bool SolutionIsOptimal { get; set; }
        public double Gap { get; set; }
        public double BestBound { get; set; }
        public double Obj { get; set; }
    }
}
