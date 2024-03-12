using IOTWebAPI.DTOs;
using IOTWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IOTWebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GatewayController : Controller
{
    private readonly IGatewayService _gatewayService;
    
    public GatewayController(IGatewayService gatewayService)
    {
        _gatewayService = gatewayService;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(ICollection<GatewayDto>))]
    public IActionResult GetGateways()
    {
        var gateways = _gatewayService.GetGateways();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(gateways);
    }
    [HttpGet]
    [Route("{gatewayId:int}")]
    [ProducesResponseType(200, Type = typeof(GatewayDto))]
    public IActionResult GetGateway(int gatewayId)
    {
        var gateway = _gatewayService.GetGateway(gatewayId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(gateway);
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateGateway([FromBody] CreateGatewayDto createGatewayDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        if (_gatewayService.CreateGateway(createGatewayDto))
            return Ok("Successfully created");
        
        ModelState.AddModelError("", "Something went wrong while savin");
        return StatusCode(500, ModelState);
    }

    [HttpPut("{gatewayId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateGateway(int gatewayId, [FromBody] UpdateGatewayDto updateGatewayDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        if (_gatewayService.UpdateGateway(updateGatewayDto, gatewayId))
            return Ok("Successfully updated");

        ModelState.AddModelError("", "Something went wrong while updating");
        return StatusCode(500, ModelState);
    }
    [HttpDelete("{gatewayId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public IActionResult DeleteGateway(int gatewayId)
    {
        if (_gatewayService.DeleteGateway(gatewayId))
            return Ok("Successfully deleted");
        
        ModelState.AddModelError("", "Something went wrong while deleting");
        return StatusCode(500, ModelState);
    }
}
