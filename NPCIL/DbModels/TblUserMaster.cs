using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblUserMaster
    {
        public long UsrSno { get; set; }
        public string UsrUserId { get; set; }
        public string UsrName { get; set; }
        public string UsrPass { get; set; }
        public string UsrEmail { get; set; }
        public string UsrPhone { get; set; }
        public string UsrUsertype { get; set; }
        public int? UseStatus { get; set; }
        public string UsrCreatedBy { get; set; }
        public DateTime? UsrCreatedDate { get; set; }
        public string UsrUpdatedBy { get; set; }
        public DateTime? UsrUpdatedDate { get; set; }
    }
}
