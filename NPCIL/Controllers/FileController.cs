using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPCIL.Helper;
using System.IO;
using System.Threading.Tasks;

namespace NPCIL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : Controller
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;
        public FileController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        // Example in ASP.NET Core
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var filePath = Path.Combine(hostingEnvironment.WebRootPath, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Return a URL to access the file
            var fileUrl = Url.Action("GetFile", new { fileName = file.FileName });
            return Ok(new { fileUrl });
        }

        [HttpGet("get-file")]
        public IActionResult GetFile(string fileName)
        {
            var filePath = Path.Combine(hostingEnvironment.WebRootPath, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return File(fileStream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }

    }
}
