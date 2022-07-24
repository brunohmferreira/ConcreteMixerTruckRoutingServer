﻿using ConcreteMixerTruckRoutingServer.Dtos.ConcreteType;
using ConcreteMixerTruckRoutingServer.Services.Base;
using FluentValidation;

namespace ConcreteMixerTruckRoutingServer.Services.ConcreteType.Validation
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
                .WithMessage("The concrete type can't be null.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || model.Description == null || model.Description.Trim() == string.Empty)
                        return false;

                    return true;
                })
                .WithMessage("The concrete type must have a description.");

            RuleFor(x => x)
                .MustAsync(async (model, context) =>
                {
                    var dto = new GetRequestDto()
                    {
                        Description = model.Description
                    };

                    var concreteTypes = await UnitOfWork.ConcreteType.GetConcreteTypeByFilter(dto);

                    if (concreteTypes != null && concreteTypes.Any())
                        return false;

                    return true;
                })
                .WithMessage("The concrete type already exists.");
        }
    }
}
