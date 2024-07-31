using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblTenderPosition
    {
        public int TpId { get; set; }
        public string TpTitle { get; set; }
        public string TpCreatedBy { get; set; }
        public DateTime? TpCreatedDate { get; set; }
        public string TpUpdatedBy { get; set; }
        public DateTime? TpUpdatedDate { get; set; }
    }
}
