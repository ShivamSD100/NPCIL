using Microsoft.AspNetCore.Http;
using NPCIL.Models;

namespace NPCIL.Helper
{
    public interface IFileHelper
    {
        public string UploadAndGetFileName(IFormFile file,string fileName);
    }
}
