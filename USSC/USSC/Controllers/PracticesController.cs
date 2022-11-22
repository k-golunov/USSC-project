using Microsoft.AspNetCore.Mvc;

namespace USSC.Controllers;

[ApiController]
[Route("[controller]")]
public class PracticesController : ControllerBase
{
    [HttpGet("getAllPractices")]
    public IActionResult GetPractices()
    {
        // возвращает поля практики name, description, info, id
        return Ok();
    }

    [HttpGet("getPractices")]
    public IActionResult GetPracticesById(int practicesId)
    {
        return Ok();
    }

    [HttpPut("updatePractice")]
    public IActionResult UpdatePractices()
    {
        return Ok();
    }

    [HttpPost("createPractice")]
    public IActionResult CreatePractices()
    {
        return Ok();
    }

    [HttpDelete("deletePractice")]
    public IActionResult DeletePractices(int practicesId)
    {
        return Ok();
    }
}