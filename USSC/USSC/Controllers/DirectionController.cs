using Microsoft.AspNetCore.Mvc;
using USSC.Dto;
using USSC.Services;

namespace USSC.Controllers;

[ApiController]
[Route("direction")]
public class DirectionController : ControllerBase
{
    private readonly IDirectionService _directionService;

    public DirectionController(IDirectionService directionService)
    {
        _directionService = directionService;
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddNewDirection(DirectionsModel directionsModel)
    {
        var result = await _directionService.Add(directionsModel);
        return Ok(new SuccessResponse(true));
    }
}