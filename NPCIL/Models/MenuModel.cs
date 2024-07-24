using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace NPCIL.Models
{
    public class MenuModel
    {
        public int MenuId { get; set; }

        [Required(ErrorMessage = "Name is required. Please Enter Name.")]
        public string MenuName_eng { get; set; } = "";

        [Required(ErrorMessage = "Name in Hindi is required. Please Enter Name in Hindi.")]
        public string MenuName_hind { get; set; } = "";

        [Required(ErrorMessage = "Menu Position is required. Please Enter Menu Position.")]
        public int MenuPosition { get; set; } = 0;

        [Required(ErrorMessage = "Menu Type is required. Please Enter Menu Type.")]
        public int MenuType { get; set; } = 0;

        //[Required(ErrorMessage = "Image is required. Please Upload Image.")]
        public IFormFile MenuImg { get; set; } = null;

        //[Required(ErrorMessage = "Description in English is required. Please Enter Description in English.")]
        public string MenuDesc_eng { get; set; } = "";

        //[Required(ErrorMessage = "Description in Hindi is required. Please Enter Description in Hindi.")]
        public string MenuDesc_hind { get; set; } = "";

        public string ImagePath { get; set; } = "";

        [Required(ErrorMessage = "Menu Position is required. Please Enter Menu Position.")]
        public int MenuPositionId { get; set; }
        public string MenuPosition_Name { get; set; } = "";

        [Required(ErrorMessage = "Menu Type is required. Please Enter Menu Type.")]
        public int MenuTypeId { get; set; }
        public string MenuType_Name { get; set; } = "";

        public int MenuListId { get; set; }
        public string MenuList_Name { get; set; } = "";

        public string Content_MenuName_eng { get; set; } = "";
        public string Content_MenuName_hindi { get; set; } = "";
        public IFormFile file_MenuImg { get; set; } = null;
        public string Imagepath2 { get; set; } = "";
        public string file_StartDate { get; set; } = "";

        public string file_EndDate { get; set; } = "";
        public DateTime? file_StartDate_Display { get; set; }
        public DateTime? file_EndDate_Display { get; set; }
        public string link_urlname { get; set; } = "";

        public int linkType { get; set; } = 0;
        public int linkTypeId { get; set; } = 0;
        public string LinkTypeName { get; set; } = "";
        public string event_year { get; set; } = "";
        public string tabActive { get; set; } = "1";
        public List<SelectListItem> TabActiveOptions { get; set; }
        public List<SelectListItem> MenuOptions { get; set; }
        public string? ParentId { get; set; } 
        public string ParentName { get; set; }

        public string? Controller { get; set; }

        public string Sequence { get; set; }


    }
}
