using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblPhotoCategory
    {
        public int PhCId { get; set; }
        public string PhCTitle { get; set; }
        public string PhCCreatedBy { get; set; }
        public DateTime? PhCCreatedDate { get; set; }
        public string PhCUpdatedBy { get; set; }
        public DateTime? PhCUpdatedDate { get; set; }
    }
}
