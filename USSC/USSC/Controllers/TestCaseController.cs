using Microsoft.AspNetCore.Mvc;
using USSC.Dto;


namespace USSC.Controllers;

[ApiController]
[Route("[controller]")]
public class TestCaseController : ControllerBase
{
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
    /// </summary>
    /// <param name="file"></param>
    [HttpPost("upload")]
    public async void UploadFile(IFormFile file)
    {
        
        var response = HttpContext.Response;
        var name = file.FileName.Split(".");
        if (name.Length != 2 || name[1] != "zip")
        {
           // throw new Exception("Invalid format file");
           await response.WriteAsync("Invalid format file or file name");
           return;
        }
        // здесь вместо file.FileName должно быть {user.Id}.zip 
        var uploadPath = $"G:\\USSC project\\USSC-project\\USSC\\USSC\\Upload\\{file.FileName}";
        
        using (var fileStream = new FileStream(uploadPath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }
        
        await response.WriteAsync("Файлы успешно загружены");
    }
}