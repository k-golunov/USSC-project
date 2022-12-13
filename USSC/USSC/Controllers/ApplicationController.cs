using Microsoft.AspNetCore.Mvc;
using USSC.Dto;
using USSC.Helpers;
using USSC.Services;

namespace USSC.Controllers;

[ApiController]
[Route("application")]
public class ApplicationController : ControllerBase
{
    private readonly IApplicationService _applicationService;
    private readonly IDirectionService _directionService;
    private readonly IUserService _userService;
    private readonly ILogger<EmailSender> _logger;

    public ApplicationController(IApplicationService applicationService, ILogger<EmailSender> logger, IDirectionService directionService, IUserService userService)
    {
        _applicationService = applicationService;
        _directionService = directionService;
        _userService = userService;
        _logger = logger;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendApplication(RequestModel model)
    {
        // var model = new RequestModel()
        // {
        //     Allow = true,
        //     DirectionId = Guid.Parse("23f10d61-a1c9-4de8-880d-dbe754b7e863"),
        // };
        var result = await _applicationService.Add(model);
        return Ok(new SuccessResponse(true));
    }
    
    [Authorize(Roles = "Admin")]
    [HttpGet("getAll")]
    public IActionResult GetAll()
    {
        var requests = _applicationService.GetAll().Where(x => x.Allow == null);
        if (requests.Any())
            return Ok(requests);
        return Ok(new { Message = "Нет необработанных заявок", StatusCode=StatusCode(200)});
    }

    [HttpPost("approve")]
    public async Task<IActionResult> ProcessApplication(RequestModel requestModel)
    {
        var user = _userService.GetById(requestModel.UserId);
        var direction = _directionService.GetById(requestModel.DirectionId);
        if (user is null && direction is null)
            return NoContent();
        var response = await _applicationService.ProcessRequest(requestModel);
        var emailSender = new EmailSender(_logger);
        emailSender.SendEmail("Ваша заявка проверена", "kostya.golunov2015@yandex.ru");
        return Ok(response);
    }
    
}