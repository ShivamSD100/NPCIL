using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace NPCIL.Models
{
    public class PhotoGalleryModel
    {
        public int Ph_id { get; set; }

        [Required(ErrorMessage = "Photo Category is required. Please Select Photo Category.")]
        public int Ph_cat { get; set; } = 0;
        public int Ph_CatId { get; set; } = 0;
        public string Ph_CatName { get; set; } = "";

        [Required(ErrorMessage = "Title is required. Please Enter Title.")]
        public int Ph_title { get; set; } = 0;

        [Required(ErrorMessage = "Title in Regional Language is required. Please Enter Title in Regional Language.")]
        public string Ph_TitleReg { get; set; } = "";

        [Required(ErrorMessage = "Description is required. Please Enter Description.")]
        public string Ph_Des { get; set; } = "";

        [Required(ErrorMessage = "Description in Regional Language is required. Please Enter Description in Regional Language.")]
        public string Ph_DesReg { get; set; } = "";

        [Required(ErrorMessage = "Alt is required. Please Enter Alt.")]
        public string Ph_Alt { get; set; } = "";

        [Required(ErrorMessage = "Alt in Regional Language is required. Please Enter Alt in Regional Language.")]
        public string Ph_AltReg { get; set; } = "";

        [Required(ErrorMessage = "Upload Image is required. Please Upload Image.")]
        public string Ph_Img { get; set; } = "";
        public string ImagePath { get; set; } = "";
    }
}
