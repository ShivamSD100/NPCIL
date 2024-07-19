using System.ComponentModel.DataAnnotations;

namespace NPCIL.Models
{
    public class VideoCategoryModel
    {
        public int VCid { get; set; } = 0;

        [Required(ErrorMessage = "Video Category Name is required. Please Enter Video Category Name.")]
        public string VCtitle { get; set; } = "";
    }
}
