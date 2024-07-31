using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblPressRelease
    {
        public int PrSno { get; set; }
        public int? PrLanguage { get; set; }
        public int? PrContent { get; set; }
        public string PrTitle { get; set; }
        public string PrPageDescription { get; set; }
        public string PrFileUpload { get; set; }
        public string PrLinkUrl { get; set; }
        public DateTime? PrStartDate { get; set; }
        public DateTime? PrEndDate { get; set; }
        public string PrCreatedBy { get; set; }
        public DateTime? PrCreatedDate { get; set; }
        public string PrUpdatedBy { get; set; }
        public DateTime? PrUpdatedDate { get; set; }
    }
}
