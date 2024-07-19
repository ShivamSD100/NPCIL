using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System;

namespace NPCIL.Models
{
    public class HorizontalNewsModel
    {
        public int HN_id { get; set; }

        [Required(ErrorMessage = "Language is required. Please Select Language.")]
        public int HN_Language { get; set; } = 0;

        [Required(ErrorMessage = "Type of Content is required. Please Select Type of Content.")]
        public int HN_Content { get; set; } = 0;

        [Required(ErrorMessage = "Title is required. Please Enter Title.")]
     
        public string HN_Title { get; set; } = "";

        [Required(ErrorMessage = "Description is required. Please Enter Description.")]
        
        public string HN_Description { get; set; } = "";

        [Required(ErrorMessage = "Start Date is required. Please Enter Start Date.")]
        public string HN_StartDate { get; set; } = "";

        [Required(ErrorMessage = "End Date is required. Please Enter End Date.")]
        public string HN_EndDate { get; set; } = "";

        [Required(ErrorMessage = "Start Date is required. Please Enter Start Date.")]
        public DateTime HN_StartDate_Display { get; set; }

        [Required(ErrorMessage = "End Date is required. Please Enter End Date.")]
        public DateTime HN_EndDate_Display { get; set; }

        public int HN_LangId { get; set; }
        public string HN_LangName { get; set; } = "";

        public int HN_ContentId { get; set; }
        public string HN_ContentName { get; set; } = "";

        public Boolean? HN_IsArchived { get; set; }
    }
}
