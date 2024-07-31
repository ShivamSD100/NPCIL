using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblMenuType
    {
        public int MtSno { get; set; }
        public string MtName { get; set; }
        public string MtCreatedBy { get; set; }
        public DateTime? MtCreatedDate { get; set; }
        public string MtUpdatedBy { get; set; }
        public DateTime? MtUpdatedDate { get; set; }
    }
}
