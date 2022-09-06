namespace ConcreteMixerTruckRoutingServer.Dtos.Route
{
    public class CalculationResponseDto
    {
        public bool solutionExists { get; set; }
        public bool solutionIsInfeasible { get; set; }
        public bool solutionsIsUnbounded { get; set; }
        public bool solutionIsOptimal { get; set; }
        public double gap { get; set; }
        public double bestBound { get; set; }
        public double obj { get; set; }
        public List<List<List<double>>>? sol_x { get; set; }
        public List<double>? sol_y { get; set; }
        public List<List<double>>? sol_z { get; set; }
    }
}
