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

    /// <summary>
    /// Вход в аккаунт
    /// </summary>
    /// <param name="model">Модель для входа в аккаунт (Почта, пароль)</param>
    /// <returns></returns>
    [HttpPost("signin")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);

        if (response == null)
        {
            return BadRequest(new { message = "Username or password is incorrect" });
        }

        return Ok(response);
    }

    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    /// <param name="userModel">Основная модель данных для пользователя</param>
    /// <returns></returns>
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

    /// <summary>
    /// Возвращает всех пользователей, которые зарегистрированы
    /// </summary>
    /// <returns></returns>
    [Authorize(Roles="Admin")]
    [HttpGet("getAll")]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        if (users.Count() == 0)
        {
            HttpContext.Response.StatusCode = 204;
            return BadRequest(new { message = "Пользователи отсутсвуют" });
        }
        
        return Ok(users);
    }

    // Если все хорошо, возвращает ФИО, возможно надо перенести в profile
    [Authorize]
    [HttpGet]
    public IActionResult CheckToken()
    {
        return Ok();
    }

    /// <summary>
    /// Создает новый рефреш и аксес токены и отдает их, рефреш токен сохраняется в бд
    /// </summary>
    /// <param name="userId">Идентификатор пользователя, Guid</param>
    /// <param name="refreshToken">Старый рефреш токен пользователя</param>
    /// <returns></returns>
    // [Authorize]
    [HttpPut("refresh")]
    public IActionResult UpdateRefreshToken(Guid userId, string refreshToken)
    {
        var user = _userService.GetById(userId);
        if (user.RefreshToken != refreshToken)
            return BadRequest(new { message = "Token not valid" });
        var response = _userService.UpdateTokens(user, refreshToken);
        return Ok(response);
    }
}