using Microsoft.AspNetCore.Mvc;
using USSC.Dto;
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
    
    [HttpGet("getInfo")]
    public IActionResult GetProfileInfo(Guid userId)
    {
        var profile = _profileService.GetByUserId(userId);
        return Ok(profile);
    }

    [HttpPost("fillInfo")]
    public async Task<IActionResult> FillProfileInfo(ProfileModel profileModel)
    {
        var result = await _profileService.Add(profileModel);
        return Ok(new SuccessResponse(true));
    }

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
            return BadRequest(new {Message = "Не удалось обновить профиль", StatusCode=StatusCode(123)});
        }
    }
}