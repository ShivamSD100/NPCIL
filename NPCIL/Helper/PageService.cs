using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NPCIL.Helper
{
    public class PageService:IPageService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PageService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public List<string> GetPages()
        {
            string pagesFilePath = Path.Combine(_hostingEnvironment.ContentRootPath, "", "WebPages.txt");

            if (File.Exists(pagesFilePath))
            {
                return File.ReadAllLines(pagesFilePath).ToList();
            }

            return new List<string>();
        }
    }
}
