using ConcreteMixerTruckRoutingServer.Api.Models.General;
using ConcreteMixerTruckRoutingServer.Exceptions.General;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace ConcreteMixerTruckRoutingServer.Api.Startups
{
    public static class ExceptionStartup
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var errorContext = context.Features.Get<IExceptionHandlerFeature>();
                    if (errorContext == null)
                        return;

                    var result = new ExceptionModel();

                    if (errorContext.Error.GetType().IsAssignableFrom(typeof(ItemNotFoundException)))
                    {
                        result.HttpStatus = (int)HttpStatusCode.NotFound;
                        result.Messages.Add(errorContext.Error.GetBaseException().Message);
                    }
                    else if (errorContext.Error.GetType().IsAssignableFrom(typeof(EmptyListException)))
                    {
                        result.HttpStatus = (int)HttpStatusCode.NoContent;
                        result.Messages.Add(errorContext.Error.GetBaseException().Message);
                    }
                    else if (errorContext.Error.GetType().IsAssignableFrom(typeof(FluentValidationException)))
                    {
                        result.HttpStatus = (int)HttpStatusCode.BadRequest;
                        result.Messages.AddRange(((FluentValidationException)errorContext.Error).ErrorList);
                    }
                    else if (errorContext.Error.GetType().IsAssignableFrom(typeof(GenericBadRequestException)))
                    {
                        result.HttpStatus = (int)HttpStatusCode.BadRequest;
                        result.Messages.Add(errorContext.Error.GetBaseException().Message);
                    }
                    else if (errorContext.Error.GetType().IsAssignableFrom(typeof(OptimisationBadRequestException)))
                    {
                        result.HttpStatus = (int)HttpStatusCode.BadRequest;
                        result.Messages.Add(errorContext.Error.GetBaseException().Message);
                    }
                    else
                    {
                        result.HttpStatus = (int)HttpStatusCode.InternalServerError;
                        result.Messages.Add(errorContext.Error.Message);
                    }

                    result.Details = errorContext.Error.StackTrace;

                    context.Response.StatusCode = result.HttpStatus;
                    context.Response.ContentType = "application/json";

                    var resultJson = JsonSerializer.Serialize<ExceptionModel>(result);
                    var bufferUtf8 = System.Text.Encoding.UTF8.GetBytes(resultJson);
                    context.Response.ContentLength = bufferUtf8.Length;

                    await context.Response.WriteAsync(resultJson);
                });
            });
        }
    }
}
