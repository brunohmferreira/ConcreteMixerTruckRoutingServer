namespace ConcreteMixerTruckRoutingServer.Api.Models
{
    public class ExceptionModel
    {
        public ExceptionModel()
        {
            Messages = new List<string>();
        }

        public int HttpStatus { get; set; }
        public List<string> Messages { get; set; }
        public string Details { get; set; }
    }
}
