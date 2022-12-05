using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using USSC.Dto;
using USSC.Services;


namespace USSC.Controllers;

[ApiController]
[Route("testcase")]
public class TestCaseController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ITestCaseService _testCaseService;
    public TestCaseController(ITestCaseService testCaseService, IUserService userService)
    {
        _testCaseService = testCaseService;
        _userService = userService;
    }
    
    [HttpGet("download")]
    public FileStreamResult DownloadFile(string namePractices)
    {
        var path = $"G:\\USSC project\\USSC-project\\USSC\\USSC\\Files\\{namePractices}.zip";
        var fileType="application/octet-stream";
        var fileStream = new FileStream(path, FileMode.Open);
        var fileName = $"{namePractices}.zip";
        return File(fileStream, fileType, fileName);
    }

    /// <summary>
    /// Требуется добавить юзера, чтобы создавать папку отдельно для каждого юзера, или называть файл id юзера
    /// также добавить [Authorize]
    /// Еще возможно сделать обработку сценария, когда файл с таким именем уже есть на сервере
    /// придумать уникальное название файла для каждой практики и каждого юзера
    /// </summary>
    [HttpPost("upload")]
    public void UploadFile(IFormFile file, Guid userId, Guid directionId)
    {
        var model = new TestCaseModel();
        model.UserId = userId;
        model.DirectionId = directionId;
        var response = HttpContext.Response;
        var name = file.FileName.Split("."); 
        if (name.Length != 2 || name[1] != "zip") 
        {
            // throw new Exception("Invalid format file");
            response.WriteAsync("Invalid format file or file name");
            return;
        }
        // здесь вместо file.FileName должно быть {user.Id}.zip 
        var uploadPath = $".\\Uploads\\{model.UserId.ToString()}.zip";
        
        // var uploadPath = $"G:\\USSC project\\USSC-project\\USSC\\USSC\\Upload\\{file.FileName}";
        model.Path = uploadPath;
        using (var fileStream = new FileStream(uploadPath, FileMode.Create))
        {
            file.CopyToAsync(fileStream);
        }
        
        var response2 = _testCaseService.Upload(model);

        // await response.WriteAsync("Файлы успешно загружены");
    }

    // [HttpPost("addTest")]
    // public IActionResult AddTestCase(/*AddedTestCase testCase*/ TestCaseModel model)
    // {
    //     //var user = _userService.GetById(model.UserId);
    //     //var response = _testCaseService.Upload(user, model.DirectionId, model.Path);
    //     // model.Users.Email = "string";
    //     // model.Users.Password = "string";
    //     // model.Users.RefreshToken = "1";
    //     // model.Users.Role = "User";
    //     var response = _testCaseService.Upload(model);
    //     return Ok(new SuccessResponse(true));
    // }
    
    [Authorize(Roles="Admin")]
    [HttpGet("getAll")]
     public IActionResult GetAll()
     {
         var testCases = _testCaseService.GetAll();
         return Ok(testCases);
     }

     /// <summary>
     /// возвращает файл решения пользователя
     /// </summary>
     // [Authorize(Roles = "Admin")]
     [HttpGet("downloadPractices")]
     public FileStreamResult DownLoadPractice(Guid userId, Guid directionId)
     {
         // try
         // {
             var testCasePath = _testCaseService.DownLoad(userId, directionId);            
             var fileType="application/octet-stream";
             var fileStream = new FileStream(testCasePath, FileMode.Open);
             var fileName = $"{userId}.zip";
             return File(fileStream, fileType, fileName);
             // return Ok(testCasePath);
         // }
         // catch
         // {
         //     return BadRequest(new { Message = "Пользователь не предоставил решения" });
         // }
     }

     /// <summary>
     /// проверка практики куратором
     /// </summary>
     [HttpPost("reviewPractice")]
     public IActionResult ReviewPractice(ReviewedTestCase reviewTestcase)
     {
         var response = _testCaseService.ReviewTestCaseAsync(reviewTestcase);
         if (response.Result.Success)
             return Ok(response.Result);
         else
             return BadRequest(response.Result); //здесь тоже логика с racticeService
     }
}