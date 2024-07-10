using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ContentManagerModel
    {
        public int CM_Id { get; set; }
        public int Menu_Id { get; set; }

        [Required(ErrorMessage = "Name in English is required. Please Enter Name in English.")]
        public string CM_Name_eng { get; set; } = "";

        [Required(ErrorMessage = "Name in Hindi is required. Please Enter Name in Hindi.")]
        public string CM_Name_hind { get; set; } = "";

        [Required(ErrorMessage = "Position is required. Please Select Position.")]
        public int CM_MenuPosition { get; set; } = 0;

        [Required(ErrorMessage = "Type is required. Please Select Type.")]
        public int CM_MenuType { get; set; } = 0;

        [Required(ErrorMessage = "Page Content in English is required. Please Enter Page Content in English.")]
        [BindProperty]
        public string CM_PageContent_eng { get; set; } = "";

        [Required(ErrorMessage = "Page Content in Hindi is required. Please Enter Page Content in Hindi.")]
        [BindProperty]
        public string CM_PageContent_hind { get; set; } = "";

        [Required(ErrorMessage = "Start Date is required. Please Enter Start Date.")]
        public string CM_StartDate { get; set; } = "";

        [Required(ErrorMessage = "End Date is required. Please Enter End Date.")]
        public string CM_EndDate { get; set; } = "";

        [Required(ErrorMessage = "Start Date is required. Please Enter Start Date.")]
        public DateTime CM_StartDate_Display { get; set; }

        [Required(ErrorMessage = "End Date is required. Please Enter End Date.")]
        public DateTime CM_EndDate_Display { get; set; }

        [Required(ErrorMessage = "Image is required. Please Enter Image.")]
        public IFormFile CM_Img { get; set; } = null;

        [Required(ErrorMessage = "Description in English is required. Please Enter Description in English.")]
        public string CM_Desc_eng { get; set; } = "";

        [Required(ErrorMessage = "Description in Hindi is required. Please Enter Description in Hindi.")]
        public string CM_Desc_hind { get; set; } = "";
        public string ImagePath { get; set; } = "";

        public int CM_MenuPositionId { get; set; }
        public string CM_MenuPosition_Name { get; set; } = "";

        public int CM_MenuTypeId { get; set; }
        public string CM_MenuType_Name { get; set; } = "";
        public DateTime date1{ get; set; }
        public DateTime date2 { get; set; }
    }
}
