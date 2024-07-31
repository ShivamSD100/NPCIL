using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblHorizontalNews
    {
        public int HnSno { get; set; }
        public int? HnLang { get; set; }
        public int? HnContent { get; set; }
        public string HnTitle { get; set; }
        public string HnDescription { get; set; }
        public DateTime? HnStartDate { get; set; }
        public DateTime? HnEndDate { get; set; }
        public string HnCreatedBy { get; set; }
        public DateTime? HnCreatedDate { get; set; }
        public string HnUpdatedBy { get; set; }
        public DateTime? HnUpdatedDate { get; set; }
        public bool? HnIsArchived { get; set; }
        public DateTime? HnArchivedDate { get; set; }
    }
}
