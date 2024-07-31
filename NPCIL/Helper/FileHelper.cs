using NPCIL.Models;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;

namespace NPCIL.Helper
{
    public class FileHelper : IFileHelper
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public FileHelper(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public string UploadAndGetFileName(IFormFile file, string fileName)
        {
                var uniqueFileName = GetUniqueFileName(fileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "MenuImages");
                var filePath = Path.Combine(uploads, uniqueFileName);
                file.CopyTo(new FileStream(filePath, FileMode.Create));
                return  "/MenuImages/" + uniqueFileName;
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }


    }
}
