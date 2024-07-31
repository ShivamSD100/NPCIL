using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblContentManager
    {
        public int CmSno { get; set; }
        public string CmNameEng { get; set; }
        public string CmNameHind { get; set; }
        public int? CmPosition { get; set; }
        public int? CmType { get; set; }
        public string CmPageContentEng { get; set; }
        public string CmPageContentHind { get; set; }
        public DateTime? CmStartdate { get; set; }
        public DateTime? CmEnddate { get; set; }
        public string CmImage { get; set; }
        public string CmShortDescEng { get; set; }
        public string CmShortDescHind { get; set; }
        public string CmCreatedby { get; set; }
        public DateTime? CmCreateddate { get; set; }
        public string CmUpdatedby { get; set; }
        public DateTime? CmUpdateddate { get; set; }
        public int? MenuId { get; set; }
    }
}
