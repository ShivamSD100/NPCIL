using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace NPCIL.Models
{
    public class PublicationModel
    {
        public int PUB_id { get; set; }

        [Required(ErrorMessage = "Language is required. Please Select Language.")]
        public int PUB_Language { get; set; } = 0;

        [Required(ErrorMessage = "Type of Publication is required. Please Select Type of Publication.")]
        public int PUB_PublicationType { get; set; } = 0;

        [Required(ErrorMessage = "Title is required. Please Enter Title.")]

        public string PUB_Title { get; set; } = "";

        [Required(ErrorMessage = "Author Name is required. Please Enter Author Name.")]

        public string PUB_AutherName { get; set; } = "";

        [Required(ErrorMessage = "File Upload is required. Please Upload File.")]
        public IFormFile PUB_FileUpload { get; set; } = null;

        [Required(ErrorMessage = "Others is required. Please Enter Others.")]
        public string PUB_Others { get; set; } = "";

        public int PUB_LangId { get; set; }
        public string PUB_LangName { get; set; } = "";

        public int PUB_PubTypeId { get; set; }
        public string PUB_PubTypeName { get; set; } = "";

        public string ImagePath { get; set; } = "";
    }
}
