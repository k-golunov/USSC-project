using Microsoft.AspNetCore.Mvc;
using USSC.Entities;
using USSC.Dto;
namespace USSC.Services;

public interface IApplicationService: IService<Application>
{
    Task<SuccessResponse> SubmitApplicationAsync(ApplicationModel applicationModel);
}