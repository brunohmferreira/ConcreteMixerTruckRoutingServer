using ConcreteMixerTruckRoutingServer.UnitOfWorks.Interfaces;
using FluentValidation;

namespace ConcreteMixerTruckRoutingServer.Services.Base
{
    public class ValidationBase<TValidation> : AbstractValidator<TValidation>
    {
        protected IDatabaseUnitOfWork UnitOfWork { get { return Parameters?.OfType<IDatabaseUnitOfWork>()?.FirstOrDefault(); } }
        public List<object> Parameters { get; set; }
    }
}
