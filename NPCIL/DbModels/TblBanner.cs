using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblBanner
    {
        public int BanSno { get; set; }
        public string BanTitle { get; set; }
        public string BanTitleLang { get; set; }
        public string BanUploadImg { get; set; }
        public string BanLinkUrl { get; set; }
        public string BanAltTag { get; set; }
        public string BanAltTagLang { get; set; }
        public string BanCreatedBy { get; set; }
        public DateTime? BanCreatedDate { get; set; }
        public string BanUpdatedBy { get; set; }
        public DateTime? BanUpdatedDate { get; set; }
    }
}
