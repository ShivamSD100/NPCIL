using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblMenuPosition
    {
        public long MpSno { get; set; }
        public string MpName { get; set; }
        public string MpCreatedBy { get; set; }
        public DateTime? MpCreatedDate { get; set; }
        public string MpUpdatedBy { get; set; }
        public DateTime? MpUpdatedDate { get; set; }
    }
}
