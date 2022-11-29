using Microsoft.AspNetCore.Authorization;
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
    public IActionResult GetProfileInfo()
    {
        return Ok();
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
        return Ok();
    }
}