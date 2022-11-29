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
    public async Task<IActionResult> SendApplication(UsersDirectionsfkModel model)
    {
        model.Users = new UserModel()
        {
            Email = "a",
            Password = "a",
        };
        var result = await _applicationService.Add(model);
        return Ok(new SuccessResponse(true));
    }
    
}