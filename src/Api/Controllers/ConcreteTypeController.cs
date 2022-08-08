using AutoMapper;
using ConcreteMixerTruckRoutingServer.Api.Models.ConcreteType;
using ConcreteMixerTruckRoutingServer.Api.Models.General;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.ConcreteType;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;

namespace Api.Controllers;

[Description("ConcreteType")]
[ApiVersion("1.0")]
[ApiController]
[Route("[controller]/v{version:apiVersion}")]
public class ConcreteTypeController : ControllerBase
{
    #region Properties

    protected IMapper Mapper { get; set; }
    protected IConcreteTypeService ConcreteTypeService { get; set; }

    #endregion

    #region Constructor

    public ConcreteTypeController(IMapper mapper, IConcreteTypeService concreteTypeService)
    {
        Mapper = mapper;
        ConcreteTypeService = concreteTypeService;
    }

    #endregion

    #region GET

    /// <summary>
    /// Gets the list of available concrete types
    /// </summary>
    /// <returns>List of available concrete types</returns>
    [HttpGet(Name = "GetConcreteTypes")]
    [Produces("application/json", Type = typeof(List<GetResponseModel>))]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Get()
    {
        var response = await ConcreteTypeService.GetConcreteTypesList();
        return Ok(Mapper.Map<List<GetResponseModel>>(response));
    }

    #endregion

}
