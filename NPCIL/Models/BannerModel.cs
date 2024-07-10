using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class BannerModel
    {
        public int BannerId { get; set; }

        [Required(ErrorMessage = "Title is required. Please Enter Title.")]
        
        public string BannerTitle { get; set; } = "";

        [Required(ErrorMessage = "Title in Regional Language is required. Please Enter Title.")]
        public string BannerTitleRegLang { get; set; } = "";

        //[Required(ErrorMessage = "Banner Image is required. Please Enter Banner Image.")]
        public IFormFile BannerImg { get; set; } = null;

        [Required(ErrorMessage = "Banner Link is required. Please Enter Banner Link.")]
        public string BannerLinkURL { get; set; } = "";

        [Required(ErrorMessage = "Alt Tag is required. Please Enter Alt Tag.")]
        public string BannerAltTag { get; set; } = "";

        [Required(ErrorMessage = "Alt Tag is required. Please Enter Alt Tag.")]
        public string BannerTagRegLang { get; set; } = "";

        public string ImagePath { get; set; } = "";
    }
}
