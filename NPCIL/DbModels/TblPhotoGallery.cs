using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblPhotoGallery
    {
        public int PhSno { get; set; }
        public int? PhCategory { get; set; }
        public string PhTitle { get; set; }
        public string PhTitleReg { get; set; }
        public string PhDescription { get; set; }
        public string PhDescriptionReg { get; set; }
        public string PhTag { get; set; }
        public string PhTagReg { get; set; }
        public string PhImage { get; set; }
        public string PhCreatedBy { get; set; }
        public DateTime? PhCreatedDate { get; set; }
        public string PhUpdatedBy { get; set; }
        public DateTime? PhUpdatedDate { get; set; }
    }
}
