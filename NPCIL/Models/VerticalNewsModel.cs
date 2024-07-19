using System.ComponentModel.DataAnnotations;
using System;

namespace NPCIL.Models
{
    public class VerticalNewsModel
    {
        public int VN_id { get; set; }

        [Required(ErrorMessage = "Language is required. Please Select Language.")]
        public int VN_Language { get; set; } = 0;

        [Required(ErrorMessage = "Type of Content is required. Please Select Type of Content.")]
        public int VN_Content { get; set; } = 0;

        [Required(ErrorMessage = "Title is required. Please Enter Title.")]

        public string VN_Title { get; set; } = "";

        [Required(ErrorMessage = "Description is required. Please Enter Description.")]

        public string VN_Description { get; set; } = "";

        [Required(ErrorMessage = "Start Date is required. Please Enter Start Date.")]
        public string VN_StartDate { get; set; } = "";

        [Required(ErrorMessage = "End Date is required. Please Enter End Date.")]
        public string VN_EndDate { get; set; } = "";

        [Required(ErrorMessage = "Start Date is required. Please Enter Start Date.")]
        public DateTime VN_StartDate_Display { get; set; }

        [Required(ErrorMessage = "End Date is required. Please Enter End Date.")]
        public DateTime VN_EndDate_Display { get; set; }

        public int VN_LangId { get; set; }
        public string VN_LangName { get; set; } = "";

        public int VN_ContentId { get; set; }
        public string VN_ContentName { get; set; } = "";

        public Boolean? VN_IsArchived { get; set; }
    }
}
