using Microsoft.AspNetCore.Mvc;
using USSC.Dto;
using USSC.Services;

namespace USSC.Controllers;

[ApiController]
[Route("application")]
public class ApplicationController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public ApplicationController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendApplication(Guid userId)
    {
        var model = new UsersDirectionsfkModel()
        {
            UserId = userId,
            Allow = true,
            DirectionsId = Guid.Parse("23f10d61-a1c9-4de8-880d-dbe754b7e863"),
            Users = new UserModel()
            {
                Id = userId,
                Email = "1",
                Password = "1",
                RefreshToken = "1",
                Role = "User"
            }
        };
        var result = await _applicationService.Add(model);
        return Ok(new SuccessResponse(true));
    }
    
}