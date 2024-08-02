using Microsoft.AspNetCore.Http;
using System;

namespace NPCIL.Models
{
    public class ArticleModel
    {
        public int id { get; set; } = 0;
        public string title { get; set; } = null;
        public string description { get; set; } = null;
        public IFormFile ArticleImg { get; set; }
        public string ImagePath { get; set; } = null;
        public string link { get; set; } = null;
        public string StartDate { get; set; } = "";
        public string EndDate { get; set; } = "";
        public DateTime? StartDate_Display { get; set; }
        public DateTime? EndDate_Display { get; set; }

        public int lang { get; set; } = 0;
        public int langId { get; set; } = 0;
        public string langName { get; set; } = "";

        public int content { get; set; } = 0;
        public int contentId { get; set; } = 0;
        public string contentName { get; set; } = "";
    }
}
