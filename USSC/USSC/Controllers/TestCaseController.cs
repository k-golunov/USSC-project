using Microsoft.AspNetCore.Mvc;

namespace USSC.Controllers;

[ApiController]
[Route("[controller]")]
public class TestCaseController : ControllerBase
{
    [HttpGet("downoload")]
    public IActionResult DownoloadFile()
    {
        // сделать проверку на авторизацию и доступ к практике
        // if ()
        return Ok();
    }

    [HttpPost("load")]
    public IActionResult LoadFile()
    {
        // сделать проверку на авторизацию и доступ к практике
        // можно вынести в отдельный метод эту проверку
        // if ()
        return Ok();
    }
}