using Microsoft.AspNetCore.Mvc;

namespace USSC.Controllers;

[ApiController]
[Route("[controller]")]
public class PracticesController : ControllerBase
{
    [HttpGet("GetPractices")]
    public IActionResult GetPractices()
    {
        // возвращает поля практики name, description, info, id
        return Ok();
    }

    [HttpPut("UpdatePractices")]
    public IActionResult UpdatePractices()
    {
        return Ok();
    }

    [HttpPost("CreatePractices")]
    public IActionResult CreatePractices()
    {
        return Ok();
    }
}