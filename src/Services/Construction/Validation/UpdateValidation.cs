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
                .WithMessage("The construction can't be null.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || model.Description == null || model.Description.Trim() == string.Empty)
                        return false;

                    return true;
                })
                .WithMessage("The construction must have a description.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || model.VolumeDemand == 0)
                        return false;

                    return true;
                })
                .WithMessage("The construction must have a volume demand ans it must be greater then 0 m³.");
            
            RuleFor(x => x)
                .MustAsync(async (model, context) =>
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

                    return true;
                })
                .WithMessage("The construction already exists and it is pending delivery.");
        }
    }
}
