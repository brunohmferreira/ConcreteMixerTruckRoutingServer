using ConcreteMixerTruckRoutingServer.Exceptions.Base;

namespace ConcreteMixerTruckRoutingServer.Exceptions.General
{
    public class EmptyListException : ExceptionBase
    {
        public const string BASE_MESSAGE = "No records found for the list of {0}.";

        public EmptyListException(string name) : base(string.Format(BASE_MESSAGE, name)) { }
    }
}
