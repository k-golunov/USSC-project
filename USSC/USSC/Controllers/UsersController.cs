using Microsoft.AspNetCore.Mvc;
using USSC.Dto;
using USSC.Helpers;
using USSC.Services;

namespace USSC.Controllers;

[ApiController]
[Route("user")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("signin")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserModel userModel)
    {
        var response = await _userService.Register(userModel);

        if (response == null)
        {
            return BadRequest(new {message = "Didn't register!"});
        }

        return Ok(response);
    }

    [Authorize(Roles="Admin")]
    [HttpGet("getAll")]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    // Если все хорошо, возвращает ФИО, возможно надо перенести в profile
    [Authorize]
    [HttpGet]
    public IActionResult CheckToken()
    {
        return Ok();
    }
}