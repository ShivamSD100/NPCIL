using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblPublicationCategories
    {
        public int PcSno { get; set; }
        public string PcTitle { get; set; }
        public string PcTitleLang { get; set; }
        public string PcUploadImg { get; set; }
        public string PcLinkUrl { get; set; }
        public string PcAltTag { get; set; }
        public string PcAltTagLang { get; set; }
        public string PcCreatedBy { get; set; }
        public DateTime? PcCreatedDate { get; set; }
        public string PcUpdatedBy { get; set; }
        public DateTime? PcUpdatedDate { get; set; }
    }
}
