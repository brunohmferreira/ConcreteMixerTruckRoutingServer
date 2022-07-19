using ConcreteMixerTruckRoutingServer.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;

namespace Api.Controllers;

[Description("Construction")]
[ApiVersion("1.0")]
[ApiController]
[Route("[controller]/v{version:apiVersion}")]
public class ConstructionController : ControllerBase
{
    #region Constructor
    public ConstructionController()
    {
    }
    #endregion

    #region GET
    [HttpGet("Teste")]
    //[Produces("application/json", Type = string]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.InternalServerError)]
    public string Get()
    {
        return "Ok";
    }
    //[HttpGet(Name = "GetWeatherForecast")]
    //public IEnumerable<WeatherForecast> Get()
    //{
    //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //    {
    //        Date = DateTime.Now.AddDays(index),
    //        TemperatureC = Random.Shared.Next(-20, 55),
    //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //    })
    //    .ToArray();
    //}
    #endregion
}
