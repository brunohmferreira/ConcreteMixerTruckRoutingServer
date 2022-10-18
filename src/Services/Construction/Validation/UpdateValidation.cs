using ConcreteMixerTruckRoutingServer.Dtos.Construction;
using ConcreteMixerTruckRoutingServer.Services.Base;
using FluentValidation;

namespace ConcreteMixerTruckRoutingServer.Services.Construction.Validation
{
    public class UpdateValidation : ValidationBase<PutRequestDto>
    {
        public UpdateValidation()
        {
            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null)
                        return false;

                    return true;
                })
                .WithMessage("A obra não pode ser nula.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || model.Description == null || model.Description.Trim() == string.Empty)
                        return false;

                    return true;
                })
                .WithMessage("A obra deve ter uma descrição.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || model.VolumeDemand == 0)
                        return false;

                    return true;
                })
                .WithMessage("A obra deve ter uma demanda em volume e essa demanda deve ser maior que 0 m³.");
            
            RuleFor(x => x)
                .MustAsync(async (model, context) =>
                {
                    if(model.ConstructionId == 0)
                    {
                        var dto = new GetRequestDto()
                        {
                            Description = model.Description,
                            VolumeDemand = model.VolumeDemand,
                            Delivered = false
                        };

                        var constructions = await UnitOfWork.Construction.GetConstructionsByFilter(dto);

                        if (constructions != null && constructions.Any())
                            return false;
                    }

                    return true;
                })
                .WithMessage("Essa obra já existe e tem uma entrega pendente.");
        }
    }
}
