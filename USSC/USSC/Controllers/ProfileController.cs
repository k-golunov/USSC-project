using Microsoft.AspNetCore.Mvc;
using USSC.Dto;
using USSC.Entities;
using USSC.Helpers;
using USSC.Services;

namespace USSC.Controllers;

[ApiController]
[Route("profile")]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }
    
    [HttpGet("getByUserId")]
    public IActionResult GetProfileInfo(Guid userId)
    {
        var profile = _profileService.GetByUserId(userId);
        if (profile == null)
            return BadRequest(new { message = "Профиль не найден" });
        // Вытаскивает все поля юзера, в том числе пароль, требует фикса!!!
        profile.Users = null;
        return Ok(profile);
    }

    [HttpPost("fillInfo")]
    public async Task<IActionResult> FillProfileInfo(ProfileModel profileModel)
    {
        // profileModel.UserId = Guid.Parse(HttpContext.Items["Users"].ToString());
        var result = await _profileService.Add(profileModel);
        return Ok(new SuccessResponse(true));
        
    }

    [Authorize]
    [HttpPut("updateInfo")]
    public IActionResult UpdateProfileInfo(ProfileModel profileModel)
    {
        try
        {
            var id = _profileService.Update(profileModel);
            return Ok(new SuccessResponse(profileModel.Id == id.Result));
        }
        catch
        {
            return BadRequest(new {Message = "Не удалось обновить профиль", StatusCode=StatusCode(400)});
        }
    }
}