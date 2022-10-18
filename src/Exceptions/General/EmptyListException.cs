using ConcreteMixerTruckRoutingServer.Exceptions.Base;

namespace ConcreteMixerTruckRoutingServer.Exceptions.General
{
    public class EmptyListException : ExceptionBase
    {
        public const string BASE_MESSAGE = "Nenhum registro encontrado para a lista de {0}.";

        public EmptyListException(string name) : base(string.Format(BASE_MESSAGE, name)) { }
    }
}
