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

                    var resultado = new ExceptionModel();

                    if (errorContext.Error.GetType().IsAssignableFrom(typeof(ItemNotFoundException)))
                    {
                        resultado.HttpStatus = (int)HttpStatusCode.NotFound;
                        resultado.Messages.Add(errorContext.Error.GetBaseException().Message);
                    }
                    else if (errorContext.Error.GetType().IsAssignableFrom(typeof(EmptyListException)))
                    {
                        resultado.HttpStatus = (int)HttpStatusCode.NoContent;
                        resultado.Messages.Add(errorContext.Error.GetBaseException().Message);
                    }
                    else if (errorContext.Error.GetType().IsAssignableFrom(typeof(FluentValidationException)))
                    {
                        resultado.HttpStatus = (int)HttpStatusCode.BadRequest;
                        resultado.Messages.AddRange(((FluentValidationException)errorContext.Error).ErrorList);
                    }
                    else if (errorContext.Error.GetType().IsAssignableFrom(typeof(GenericBadRequestException)))
                    {
                        resultado.HttpStatus = (int)HttpStatusCode.BadRequest;
                        resultado.Messages.Add(errorContext.Error.GetBaseException().Message);
                    }
                    else
                    {
                        resultado.HttpStatus = (int)HttpStatusCode.InternalServerError;
                        resultado.Messages.Add(errorContext.Error.Message);
                    }

                    resultado.Details = errorContext.Error.StackTrace;

                    context.Response.StatusCode = resultado.HttpStatus;
                    context.Response.ContentType = "application/json";

                    var resultadoJson = JsonSerializer.Serialize<ExceptionModel>(resultado);
                    var bufferUtf8 = System.Text.Encoding.UTF8.GetBytes(resultadoJson);
                    context.Response.ContentLength = bufferUtf8.Length;

                    await context.Response.WriteAsync(resultadoJson);
                });
            });
        }
    }
}
