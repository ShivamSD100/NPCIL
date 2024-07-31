using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblPageName
    {
        public long PgnSno { get; set; }
        public string PgnName { get; set; }
        public string PgnCreatedBy { get; set; }
        public DateTime? PgnCreatedDate { get; set; }
        public string PgnUpdatedBy { get; set; }
        public DateTime? PgnUpdatedDate { get; set; }
    }
}
