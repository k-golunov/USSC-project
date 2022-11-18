using Microsoft.AspNetCore.Mvc;
using USSC.Entities;
using USSC.Dto;
namespace USSC.Services;

public interface IApplicationService: IService<Application>
{
    Task<IActionResult> SubmitApplicationAsync(ApplicationModel applicationModel);
}