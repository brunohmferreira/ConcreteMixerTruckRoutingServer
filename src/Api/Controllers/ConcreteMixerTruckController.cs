using AutoMapper;
using ConcreteMixerTruckRoutingServer.Api.Models.ConcreteMixerTruck;
using ConcreteMixerTruckRoutingServer.Api.Models.General;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.ConcreteMixerTruck;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;

namespace Api.Controllers;

[Description("ConcreteMixerTruck")]
[ApiVersion("1.0")]
[ApiController]
[Route("[controller]/v{version:apiVersion}")]
public class ConcreteMixerTruckController : ControllerBase
{
    #region Properties

    protected IMapper Mapper { get; set; }
    protected IConcreteMixerTruckService ConcreteMixerTruckService { get; set; }

    #endregion

    #region Constructor

    public ConcreteMixerTruckController(IMapper mapper, IConcreteMixerTruckService concreteMixerTruckService)
    {
        Mapper = mapper;
        ConcreteMixerTruckService = concreteMixerTruckService;
    }

    #endregion

    #region GET

    /// <summary>
    /// Gets the list of available concrete mixer trucks
    /// </summary>
    /// <returns>List of concrete mixer trucks</returns>
    [HttpGet(Name = "GetConcreteMixerTrucks")]
    [Produces("application/json", Type = typeof(List<GetResponseModel>))]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Get()
    {
        var response = await ConcreteMixerTruckService.GetConcreteMixerTrucksList();
        return Ok(Mapper.Map<List<GetResponseModel>>(response));
    }

    #endregion

}
