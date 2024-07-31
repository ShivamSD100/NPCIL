using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblContent
    {
        public int ConSno { get; set; }
        public string ConName { get; set; }
        public string ConCreatedBy { get; set; }
        public DateTime? ConCreatedDate { get; set; }
        public string ConUpdatedBy { get; set; }
        public DateTime? ConUpdatedDate { get; set; }
    }
}
