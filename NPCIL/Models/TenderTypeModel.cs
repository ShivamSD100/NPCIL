using System.ComponentModel.DataAnnotations;

namespace NPCIL.Models
{
    public class TenderTypeModel
    {
        public int TTid { get; set; } = 0;

        [Required(ErrorMessage = "Tender Type Name is required. Please Enter Tender Type Name.")]
        public string TTtitle { get; set; } = "";
    }
}
