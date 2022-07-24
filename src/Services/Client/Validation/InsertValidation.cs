﻿using ConcreteMixerTruckRoutingServer.Dtos.Client;
using ConcreteMixerTruckRoutingServer.Services.Base;
using FluentValidation;

namespace ConcreteMixerTruckRoutingServer.Services.Client.Validation
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
                .WithMessage("The client can't be null.");

            RuleFor(x => x)
                .Must((model) =>
                {
                    if (model == null || model.Name == null || model.Name.Trim() == string.Empty)
                        return false;

                    return true;
                })
                .WithMessage("The client must have a name.");

            RuleFor(x => x)
                .MustAsync(async (model, context) =>
                {
                    var dto = new GetRequestDto()
                    {
                        Name = model.Name
                    };

                    var clients = await UnitOfWork.Client.GetClientByFilter(dto);

                    if (clients != null && clients.Any())
                        return false;

                    return true;
                })
                .WithMessage("The client already exists.");
        }
    }
}
