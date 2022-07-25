using ConcreteMixerTruckRoutingServer.Dtos.Address;
using ConcreteMixerTruckRoutingServer.Services.Base;
using FluentValidation;

namespace ConcreteMixerTruckRoutingServer.Services.Address.Validation
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
                .WithMessage("The address can't be null.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || model.Street == null || model.Street.Trim() == string.Empty)
                        return false;

                    return true;
                })
                .WithMessage("The address must have a street name.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || model.Street == null || model.Street.Trim() == string.Empty || 
                    !(model.Street.ToLower().Contains("rua") || model.Street.ToLower().Contains("r.") ||
                    model.Street.ToLower().Contains("avenida") || model.Street.ToLower().Contains("av.") ||
                    model.Street.ToLower().Contains("alameda") || model.Street.ToLower().Contains("al.") ||
                    model.Street.ToLower().Contains("condomínio") || model.Street.ToLower().Contains("condominio")))
                        return false;

                    return true;
                })
                .WithMessage("The address must have a street name.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || (!model.Number.HasValue && !model.NoNumber))
                        return false;

                    return true;
                })
                .WithMessage("The address must have a number or be no number.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || (model.Number.HasValue && model.NoNumber))
                        return false;

                    return true;
                })
                .WithMessage("The address must have a number or be no number.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || model.Neighborhood == null || model.Neighborhood.Trim() == string.Empty)
                        return false;

                    return true;
                })
                .WithMessage("The address must have a neighborhood name.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || model.ZipCode == null || model.ZipCode.Trim() == string.Empty)
                        return false;

                    return true;
                })
                .WithMessage("The address must have a Zip Code.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || model.ZipCode == null || model.ZipCode.Trim() == string.Empty || 
                        model.ZipCode.Length != 9 || !model.ZipCode.Contains("-"))
                        return false;

                    return true;
                })
                .WithMessage("The address has an invalid Zip Code.");


            RuleFor(x => x)
               .Must((model) =>
               {
                   if (model == null || model.City == null || model.City.Trim() == string.Empty)
                       return false;

                   return true;
               })
               .WithMessage("The address must have a city name.");
            
            RuleFor(x => x)
               .Must((model) =>
               {
                   if (model == null || model.State == null || model.State.Trim() == string.Empty)
                       return false;

                   return true;
               })
               .WithMessage("The address must have a state name.");
            
            RuleFor(x => x)
               .Must((model) =>
               {
                   if (model == null || model.Country == null || model.Country.Trim() == string.Empty)
                       return false;

                   return true;
               })
               .WithMessage("The address must have a country name.");

            RuleFor(x => x)
               .Must((model) =>
               {
                   if (model == null || model.Latitude == 0)
                       return false;

                   return true;
               })
               .WithMessage("The address must have a latitude.");

            RuleFor(x => x)
              .Must((model) =>
              {
                  if (model == null || model.Longitude == 0)
                      return false;

                  return true;
              })
              .WithMessage("The address must have a longitude.");
        }
    }
}
