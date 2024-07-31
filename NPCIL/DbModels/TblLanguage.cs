using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblLanguage
    {
        public long LangSno { get; set; }
        public string LangName { get; set; }
        public string LangCreatedBy { get; set; }
        public DateTime? LangCreatedDate { get; set; }
        public string LangUpdatedBy { get; set; }
        public DateTime? LangUpdatedDate { get; set; }
    }
}
