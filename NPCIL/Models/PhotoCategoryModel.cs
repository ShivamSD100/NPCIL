using System.ComponentModel.DataAnnotations;

namespace NPCIL.Models
{
    public class PhotoCategoryModel
    {
        public int PCid { get; set; } = 0;

        [Required(ErrorMessage = "Photo Category Name is required. Please Enter Photo Category Name.")]
        public string title { get; set; } = "";
    }
}
