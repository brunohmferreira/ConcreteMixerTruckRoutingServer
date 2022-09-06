using AutoMapper;
using ConcreteMixerTruckRoutingServer.Api.Models.Route;
using ConcreteMixerTruckRoutingServer.Api.Models.General;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.Route;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;
using ConcreteMixerTruckRoutingServer.Dtos.Route;

namespace Api.Controllers;

[Description("Route")]
[ApiVersion("1.0")]
[ApiController]
[Route("[controller]/v{version:apiVersion}")]
public class RouteController : ControllerBase
{
    #region Properties

    protected IMapper Mapper { get; set; }
    protected IRouteService RouteService { get; set; }

    #endregion

    #region Constructor

    public RouteController(IMapper mapper, IRouteService routeService)
    {
        Mapper = mapper;
        RouteService = routeService;
    }

    #endregion

    #region GET

    /// <summary>
    /// Gets the routes
    /// </summary>
    /// <returns>List of routes</returns>
    [HttpGet(Name = "GetRoutes")]
    [Produces("application/json", Type = typeof(List<GetResponseModel>))]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Get()
    {
        var response = await RouteService.GetRoutes();
        return Ok(Mapper.Map<List<GetResponseModel>>(response));
    }

    #endregion

    #region POST

    /// <summary>
    /// Calculates the routes
    /// </summary>
    /// <param name="model">Request model</param>
    /// <returns>Calculation Response</returns>
    [HttpPost(Name = "PostRoute")]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Calculate([FromBody] CalculationRequestModel model)
    {
        var dto = Mapper.Map<List<PostRequestDto>>(model.Constructions);
        var response = await RouteService.CalculateRoutes(dto, model.DistanceMatrix);
        return Ok(Mapper.Map<CalculationResponseModel>(response));
    }

    #endregion

    #region PUT

    /// <summary>
    /// Carries out the route
    /// </summary>
    /// <param name="routeId">route identifier</param>
    /// <returns>Boolean confirming the action</returns>
    [HttpPut("carry-out/{routeId}", Name = "CarryOutRoute")]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CarryOut(int routeId)
    {
        var response = await RouteService.CarryOutRoute(routeId);
        return Ok(response);
    }

    /// <summary>
    /// Carries out the route
    /// </summary>
    /// <param name="routeId">route identifier</param>
    /// <returns>Boolean confirming the action</returns>
    [HttpPut("cancel/{routeId}", Name = "CancelRoute")]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Cancel(int routeId)
    {
        var response = await RouteService.CancelRoute(routeId);
        return Ok(response);
    }

    #endregion

}
