using Microsoft.AspNetCore.Mvc;
using USSC.Dto;


namespace USSC.Controllers;

[ApiController]
[Route("{controller}")]
public class TestCaseController : ControllerBase
{
    [HttpGet("download")]
    public FileStreamResult DownoloadFile(TestCaseFile file)
    {
        // Нужно решить проблему с передачей в аргументы TestCaseFile появление лишних полей
        // Возможно создать новую сущность, которая будет связана с TestCaseFile, но просить будет только id и practics id
        var path = $"G:\\USSC project\\USSC-project\\USSC\\USSC\\Files\\test.txt";
        var fileType="application/octet-stream";
        var fileStream = new FileStream(path, FileMode.Open);
        var fileName = "test.txt";
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