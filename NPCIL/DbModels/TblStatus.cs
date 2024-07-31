using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblStatus
    {
        public int StSno { get; set; }
        public string StName { get; set; }
        public string StCreatedBy { get; set; }
        public DateTime? StCreatedDate { get; set; }
        public string StUpdatedBy { get; set; }
        public DateTime? StUpdatedDate { get; set; }
    }
}
