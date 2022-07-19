using ConcreteMixerTruckRoutingServer.Exceptions.Base;

namespace ConcreteMixerTruckRoutingServer.Exceptions.General
{
    public class FluentValidationException : ExceptionBase
    {
        public List<string> ErrorList { get; set; }

        public FluentValidationException(IEnumerable<string> errorList) : base("")
        {
            ErrorList = errorList.ToList();
        }
    }
}
