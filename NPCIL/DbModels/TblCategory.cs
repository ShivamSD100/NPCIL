using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblCategory
    {
        public int CtSno { get; set; }
        public string CtName { get; set; }
        public string CtCreatedBy { get; set; }
        public DateTime? CtCreatedDate { get; set; }
        public string CtUpdatedBy { get; set; }
        public DateTime? CtUpdateDate { get; set; }
    }
}
