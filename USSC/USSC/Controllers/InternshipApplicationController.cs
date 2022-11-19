using Microsoft.AspNetCore.Mvc;
using USSC;
using USSC.Dto;
using USSC.Services;

namespace USSC.Controllers;

[ApiController]
[Route("[controller]")]
public class InternshipApplicationController : ControllerBase
{
    private readonly IApplicationService _applicationService;
    public InternshipApplicationController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }
    
    [HttpPost("createApplication")]
    public IActionResult CreateApplication(ApplicationModel application)
    {
        try
        {
            //вот это проверка на существование application, но там не работает из-за long
            //не захотел полностью переделывать, поэтому оставил на подумать
            //var id = _applicationService.GetById(int.Parse(application.Id));
            var response = _applicationService.SubmitApplicationAsync(application);
            return response.Result;
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpGet("GetApplication")]
    public IActionResult GetApplication()
    {
        // проверка на доступ пользователя к заявкам role == Tutor || Admin
        // if ()
        //по-моему тут вот так, и ничего более
        return Ok(_applicationService.GetAll());
    }
}