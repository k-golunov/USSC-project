using System.Net;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using OkResult = System.Web.Http.Results.OkResult;

namespace USSC.Controllers;

// [ApiController]
// [Microsoft.AspNetCore.Mvc.Route("[controller]")]
public class TestCaseController : ApiController
{
    [System.Web.Http.AcceptVerbs("GET")]
    [Microsoft.AspNetCore.Mvc.HttpGet("DownoloadFile")]
    public OkResult DownoloadFile()
    {
        // сделать проверку на авторизацию и доступ к практике
        // if ()
        return Ok();
    }

    [System.Web.Http.AcceptVerbs("POST")]
    [Microsoft.AspNetCore.Mvc.HttpPost("UploadFile")]
    public async Task<IHttpActionResult> LoadFile()
    {
        // сделать проверку на авторизацию и доступ к практике
        // можно вынести в отдельный метод эту проверку
        // if ()
        try
        {
            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            if (provider.Contents is not { Count: > 0 }) return Ok(new { message = "Not found" });
            foreach (var providerContent in provider.Contents)
            {
                var fileName = providerContent.Headers.ContentDisposition.FileName;
                // Если нет имени файла, возвращаем ошибку
                if (!string.IsNullOrEmpty(fileName))
                {
                    // Создаем в проекте файл "Files" для сохранения загруженных файлов,
                    // Надо переделать эту логику, т.к. иначе будет конфликт названий файлов,
                    // В идеале для каждого пользователя создавать свою директорию или сохранять в БД
                    var saveDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");
                    if (!Directory.Exists(saveDir))
                        Directory.CreateDirectory(saveDir);

                    // Проверка, что нет файла с таким же именем, если есть, перезаписываем его 
                    var filePath = Path.Combine(saveDir, fileName);
                    if (File.Exists(filePath))
                        File.Delete(filePath);

                    // принимаем байты нашего файла
                    var bytes = await providerContent.ReadAsByteArrayAsync();
                    if (bytes.Length > 0)
                    {
                        // записываем мемори стрим 
                        using var streamMemory = new MemoryStream(bytes);
                        // читаем его
                        streamMemory.Seek(0, SeekOrigin.Begin);
                        // копируем в файл стрим байты (запись файла)
                        await using var fileStream = File.Create(filePath);
                        streamMemory.CopyTo(fileStream);
                    }
                    else
                        return Ok(new { message = "File is empty" });
                }
                else
                    return Ok(new { message = "No file name" });
            }

            return Ok(new { message = "Success" });

        }
        
        catch
        {
            return BadRequest("Error upload");
        }
    }
}