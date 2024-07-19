using System.ComponentModel.DataAnnotations;

namespace NPCIL.Models
{
    public class TenderPositionModel
    {
        public int TPid { get; set; } = 0;

        [Required(ErrorMessage = "Tender Position Name is required. Please Enter Tender Position Name.")]
        public string TPtitle { get; set; } = "";
    }
}
