using System;
using System.ComponentModel.DataAnnotations;

namespace NPCIL.Models
{
    public class TenderModel
    {
        public int id { get; set; } = 0;

        [Required(ErrorMessage = "Tender No. is required. Please Enter Tender No.")]
        public string TendorNo { get; set; } = "";

        [Required(ErrorMessage = "Tender Issuing Authority is required. Please Enter Tender Issuing Authority.")]
        public string TendorAuthEng { get; set; } = "";
        public string TendorAuthHindi { get; set; } = "";
        public string StartDate_Selling { get; set; } = "";
        public string EndDate_Selling { get; set; } = "";

        [Required(ErrorMessage = "Tender Opening Date is required. Please Enter Tender Opening Date.")]
        public string DateOpening { get; set; } = "";

        [Required(ErrorMessage = "Tender Receiving Start Date is required. Please Enter Tender Receiving Start Date.")]
        public string StartDate_Receiving { get; set; } = "";

        [Required(ErrorMessage = "Tender Receiving End Date is required. Please Enter Tender Receiving End Date.")]
        public string EndDate_Receiving { get; set; } = "";
        public string Prebid_Date { get; set; } = "";
        public DateTime? StartDate_Selling_Display { get; set; }
        public DateTime? EndDate_Selling_Display { get; set; }

        [Required(ErrorMessage = "The date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        //[Range(typeof(DateTime), "1/1/2000", "31/12/2099", ErrorMessage = "Date must be between 01/01/2000 and 12/31/2099")]
        public DateTime? DateOpening_Display { get; set; }

        [Required(ErrorMessage = "The date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        //[Range(typeof(DateTime), "1-1-2000", "31/12/2099", ErrorMessage = "Date must be between 01/01/2000 and 12/31/2099")]
        public DateTime? StartDate_Receiving_Display { get; set; }

        [Required(ErrorMessage = "The date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        //[Range(typeof(DateTime), "1-1-2000", "31-12-2099", ErrorMessage = "Date must be between 01/01/2000 and 12/31/2099")]
        public DateTime? EndDate_Receiving_Display { get; set; }
        public DateTime? Prebid_Date_Display { get; set; }
        public string Scope_eng { get; set; } = "";
        public string Scope_hindi { get; set; } = "";
        public string body_eng { get; set; } = "";
        public string body_hindi { get; set; } = "";
        public bool markImportant { get; set; }
        public string cost { get; set; } = "";
        public string EMD { get; set; } = "";
        public bool IsArchived { get; set; }
        public string archived_date { get; set; } = "";
    }
}
