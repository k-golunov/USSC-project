using Microsoft.AspNetCore.Mvc;

namespace USSC.Controllers;

[ApiController]
[Route("[controller]")]
public class InternshipApplicationController : ControllerBase
{
    [HttpPost("createApplication")]
    public IActionResult CreateApplication()
    {
        // сделать проверку на авторизацию
        // if ()
        return Ok();
    }

    [HttpGet("GetApplication")]
    public IActionResult GetApplication()
    {
        // проверка на доступ пользователя к заявкам role == Tutor || Admin
        // if ()
        return Ok();
    }
}