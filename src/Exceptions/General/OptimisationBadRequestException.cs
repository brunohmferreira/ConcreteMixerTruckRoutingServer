using ConcreteMixerTruckRoutingServer.Exceptions.Base;

namespace ConcreteMixerTruckRoutingServer.Exceptions.General
{
    public class OptimisationBadRequestException : ExceptionBase
    {
        public const string BASE_MESSAGE = "Falha ao calcular rota.";

        public OptimisationBadRequestException() : base(BASE_MESSAGE) { }
    }
}
