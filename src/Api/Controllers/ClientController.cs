using AutoMapper;
using ConcreteMixerTruckRoutingServer.Api.Models.Client;
using ConcreteMixerTruckRoutingServer.Api.Models.General;
using ConcreteMixerTruckRoutingServer.Services.Interfaces.Client;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;

namespace Api.Controllers;

[Description("Client")]
[ApiVersion("1.0")]
[ApiController]
[Route("[controller]/v{version:apiVersion}")]
public class ClientController : ControllerBase
{
    #region Properties

    protected IMapper Mapper { get; set; }
    protected IClientService ClientService { get; set; }

    #endregion

    #region Constructor

    public ClientController(IMapper mapper, IClientService clientService)
    {
        Mapper = mapper;
        ClientService = clientService;
    }

    #endregion

    #region GET

    /// <summary>
    /// Gets the list of clients
    /// </summary>
    /// <returns>List of clients</returns>
    [HttpGet(Name = "GetClients")]
    [Produces("application/json", Type = typeof(List<GetResponseModel>))]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ExceptionModel), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Get()
    {
        var response = await ClientService.GetClientsList();
        return Ok(Mapper.Map<List<GetResponseModel>>(response));
    }

    #endregion

}
