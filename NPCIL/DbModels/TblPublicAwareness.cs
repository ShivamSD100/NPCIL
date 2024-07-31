using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblPublicAwareness
    {
        public int PaSno { get; set; }
        public int? PaLanguage { get; set; }
        public int? PaContent { get; set; }
        public string PaTitle { get; set; }
        public string PaPageDescription { get; set; }
        public string PaFileUpload { get; set; }
        public string PaLinkUrl { get; set; }
        public DateTime? PaStartDate { get; set; }
        public DateTime? PaEndDate { get; set; }
        public string PaCreatedBy { get; set; }
        public DateTime? PaCreatedDate { get; set; }
        public string PaUpdatedBy { get; set; }
        public DateTime? PaUpdatedDate { get; set; }
    }
}
