using AutoMapper;
using ConcreteMixerTruckRoutingServer.Api.Models.Construction;
using ConcreteMixerTruckRoutingServer.Api.Models.General;
using ConcreteMixerTruckRoutingServer.Dtos.Construction;
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
    /// Gets the list of pending constructions for delivery
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
    /// Gets the construction by id
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

    #region POST

    /// <summary>
    /// Inserts a new construction, client and concrete type
    /// </summary>
    /// <param name="model">Request model</param>
    /// <returns>Construction identifier</returns>
    [HttpPost(Name = "PostConstruction")]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Post([FromBody] PostRequestModel model)
    {
        var dto = Mapper.Map<PostRequestDto>(model);
        int response = await ConstructionService.InsertConstruction(dto);
        return Ok(response);
    }

    #endregion

    #region PUT

    /// <summary>
    /// Updates a construction
    /// </summary>
    /// <param name="model">Request model</param>
    /// <returns>Boolean confirming the action</returns>
    [HttpPut(Name = "PutConstruction")]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Put([FromBody] PutRequestModel model)
    {
        var dto = Mapper.Map<PutRequestDto>(model);
        bool response = await ConstructionService.UpdateConstruction(dto);
        return Ok(response);
    }

    #endregion

    #region DELETE

    /// <summary>
    /// Deletes a construction by id
    /// </summary>
    /// <param name="constructionId">Construction identifier</param>
    /// <returns>Boolean confirming the action</returns>
    [HttpDelete("{constructionId}", Name = "DeleteConstruction")]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Delete(int constructionId)
    {
        bool response = await ConstructionService.DeleteConstruction(constructionId);
        return Ok(response);
    }

    #endregion
}
