using Microsoft.AspNetCore.Mvc;
using USSC.Dto;
using USSC.Services;

namespace USSC.Controllers;

[ApiController]
[Route("direction")]
public class DirectionController : ControllerBase
{
    private readonly IDirectionService _directionService;

    public DirectionController(IDirectionService directionService)
    {
        _directionService = directionService;
    }
    
    // почему-то работает только без асинхронности, надо разобраться
    [HttpPost("add")]
    public void AddNewDirection(IFormFile file, string direction)
    { 
        var uploadPath = $".\\Files\\{direction}.zip";
        var directionsModel = new DirectionsModel
        {
            Directions = direction,
            Path = $".\\Files\\{file.FileName}"
        };
        var response = HttpContext.Response;
        var name = file.FileName.Split("."); 
        if (name.Length != 2 || name[1] != "zip") 
        {
            // throw new Exception("Invalid format file");
            response.WriteAsync("Invalid format file or file name");
            return;
        }
        
        using (var fileStream = new FileStream(uploadPath, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }

        // response.WriteAsync("Файлы успешно загружены");
        var result =  _directionService.Add(directionsModel);
    }
}