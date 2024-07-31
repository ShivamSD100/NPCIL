using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblPublicationType
    {
        public int PtSno { get; set; }
        public string PtName { get; set; }
        public string PtCreatedBy { get; set; }
        public DateTime? PtCreatedDate { get; set; }
        public string PtUpdatedBy { get; set; }
        public DateTime? PtUpdatedDate { get; set; }
    }
}
