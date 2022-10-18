using ConcreteMixerTruckRoutingServer.Dtos.Address;
using ConcreteMixerTruckRoutingServer.Services.Base;
using FluentValidation;

namespace ConcreteMixerTruckRoutingServer.Services.Address.Validation
{
    public class InsertValidation: ValidationBase<PostRequestDto>
    {
        public InsertValidation()
        {
            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null)
                        return false;

                    return true;
                })
                .WithMessage("O endereço não pode ser nulo.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || model.Street == null || model.Street.Trim() == string.Empty)
                        return false;

                    return true;
                })
                .WithMessage("O endereço deve ter um nome de logradouro.");

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
                .WithMessage("O endereço deve ter um nome de logradouro.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || (!model.Number.HasValue && !model.NoNumber))
                        return false;

                    return true;
                })
                .WithMessage("O endereço deve ter um número ou ser S/N.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || (model.Number.HasValue && model.NoNumber))
                        return false;

                    return true;
                })
                .WithMessage("O endereço deve ter um número ou ser S/N.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || model.Neighborhood == null || model.Neighborhood.Trim() == string.Empty)
                        return false;

                    return true;
                })
                .WithMessage("O endereço deve ter o nome do bairro.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || model.ZipCode == null || model.ZipCode.Trim() == string.Empty)
                        return false;

                    return true;
                })
                .WithMessage("O endereço deve ter um CEP.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || model.ZipCode == null || model.ZipCode.Trim() == string.Empty || 
                        model.ZipCode.Length != 9 || !model.ZipCode.Contains("-"))
                        return false;

                    return true;
                })
                .WithMessage("O endereço deve ter um CEP.");


            RuleFor(x => x)
               .Must((model) =>
               {
                   if (model == null || model.City == null || model.City.Trim() == string.Empty)
                       return false;

                   return true;
               })
               .WithMessage("O endereço deve ter o nome da cidade.");
            
            RuleFor(x => x)
               .Must((model) =>
               {
                   if (model == null || model.State == null || model.State.Trim() == string.Empty)
                       return false;

                   return true;
               })
               .WithMessage("O endereço deve ter o nome do estado.");
            
            RuleFor(x => x)
               .Must((model) =>
               {
                   if (model == null || model.Country == null || model.Country.Trim() == string.Empty)
                       return false;

                   return true;
               })
               .WithMessage("O endereço deve ter o nome do país.");

            RuleFor(x => x)
               .Must((model) =>
               {
                   if (model == null || model.Latitude == 0)
                       return false;

                   return true;
               })
               .WithMessage("O endereço deve ter uma latitude.");

            RuleFor(x => x)
              .Must((model) =>
              {
                  if (model == null || model.Longitude == 0)
                      return false;

                  return true;
              })
              .WithMessage("O endereço deve ter uma longitude.");
        }
    }
}
