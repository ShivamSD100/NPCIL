using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblVideoCategory
    {
        public int VcId { get; set; }
        public string VcTitle { get; set; }
        public string VcCreatedBy { get; set; }
        public DateTime? VcCreatedDate { get; set; }
        public string VcUpdatedBy { get; set; }
        public DateTime? VcUpdatedDate { get; set; }
    }
}
