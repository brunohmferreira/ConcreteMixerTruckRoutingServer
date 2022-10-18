using ConcreteMixerTruckRoutingServer.Exceptions.Base;

namespace ConcreteMixerTruckRoutingServer.Exceptions.General
{
    public class ItemNotFoundException : ExceptionBase
    {
        public const string BASE_MESSAGE = "{0} não encontrado(a).";

        public ItemNotFoundException(string name) : base(string.Format(BASE_MESSAGE, name)) { }
    }
}
