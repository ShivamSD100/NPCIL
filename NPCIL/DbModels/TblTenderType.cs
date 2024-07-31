using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblTenderType
    {
        public int TtId { get; set; }
        public string TtTitle { get; set; }
        public string TtCreatedBy { get; set; }
        public DateTime? TtCreatedDate { get; set; }
        public string TtUpdatedBy { get; set; }
        public DateTime? TtUpdatedDate { get; set; }
    }
}
