using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace NPCIL.Models
{
    public class PublicationCategoriesModel
    {
        public int CategoriesId { get; set; }

        [Required(ErrorMessage = "Title is required. Please Enter Title.")]

        public string CategoriesTitle { get; set; } = "";

        [Required(ErrorMessage = "Title in Regional Language is required. Please Enter Title.")]
        public string CategoriesTitleRegLang { get; set; } = "";

        //[Required(ErrorMessage = "Publication Categories Image is required. Please Enter Publication Categories Image.")]
        public IFormFile CategoriesImg { get; set; } = null;

        [Required(ErrorMessage = "Publication Categories Link is required. Please Enter Publication Categories Link.")]
        public string CategoriesLinkURL { get; set; } = "";

        [Required(ErrorMessage = "Alt Tag is required. Please Enter Alt Tag.")]
        public string CategoriesAltTag { get; set; } = "";

        [Required(ErrorMessage = "Alt Tag is required. Please Enter Alt Tag.")]
        public string CategoriesTagRegLang { get; set; } = "";

        public string ImagePath { get; set; } = "";
    }
}
