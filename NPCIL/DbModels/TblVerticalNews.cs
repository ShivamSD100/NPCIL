using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblVerticalNews
    {
        public int VnSno { get; set; }
        public int? VnLang { get; set; }
        public int? VnContent { get; set; }
        public string VnTitle { get; set; }
        public string VnDescription { get; set; }
        public DateTime? VnStartDate { get; set; }
        public DateTime? VnEndDate { get; set; }
        public string VnCreatedBy { get; set; }
        public DateTime? VnCreatedDate { get; set; }
        public string VnUpdatedBy { get; set; }
        public DateTime? VnUpdatedDate { get; set; }
        public bool? VNIsArchived { get; set; }
        public DateTime? VnArchivedDate { get; set; }
    }
}
