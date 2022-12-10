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

    public ApplicationController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
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

    [HttpPost("getAllow")]
    public async Task<IActionResult> ProcessApplication(RequestModel requestModel)
    {
        var response = await _applicationService.ProcessRequest(requestModel);
        var emailSender = new EmailSender();
        emailSender.SendEmail("Ваша заявка проверена", "kostya.golunov2015@yandex.ru");
        return Ok(response);
    }
    
}