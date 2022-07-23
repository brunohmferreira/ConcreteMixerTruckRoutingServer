using AutoMapper;
using ConcreteMixerTruckRoutingServer.Api.Models.Construction;
using ConcreteMixerTruckRoutingServer.Api.Models.General;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.Construction;
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
    #region Properties

    protected IMapper Mapper { get; set; }
    protected IConstructionService ConstructionService { get; set; }

    #endregion

    #region Constructor

    public ConstructionController(IMapper mapper, IConstructionService constructionService)
    {
        Mapper = mapper;
        ConstructionService = constructionService;
    }

    #endregion

    #region GET

    /// <summary>
    /// Get the list of pending constructions for delivery
    /// </summary>
    /// <returns>List of pending constructions for delivery</returns>
    [HttpGet(Name = "GetConstructions")]
    [Produces("application/json", Type = typeof(List<GetResponseModel>))]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Get()
    {
        var response = await ConstructionService.GetConstructionsList();
        return Ok(Mapper.Map<List<GetResponseModel>>(response));
    }

    /// <summary>
    /// Get the construction by id
    /// </summary>
    /// /// <param name="constructionId">Construction identifier</param>
    /// <returns>Construction</returns>
    [HttpGet("{constructionId}", Name = "GetConstructionById")]
    [Produces("application/json", Type = typeof(GetResponseModel))]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetById(int constructionId)
    {
        var response = await ConstructionService.GetConstructionById(constructionId);
        return Ok(Mapper.Map<GetResponseModel>(response));
    }

    #endregion
}
