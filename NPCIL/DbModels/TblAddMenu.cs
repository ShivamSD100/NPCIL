using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblAddMenu
    {
        public int MenuSno { get; set; }
        public string MenuNameEng { get; set; }
        public string MenuNameHind { get; set; }
        public int? MenuPosition { get; set; }
        public int? MenuType { get; set; }
        public string MenuImg { get; set; }
        public string MenuDescEng { get; set; }
        public string MenuDescHind { get; set; }
        public string ContentEng { get; set; }
        public string ContentHind { get; set; }
        public string FileImage { get; set; }
        public DateTime? FileStartdate { get; set; }
        public DateTime? FileEnddate { get; set; }
        public string LinkUrlname { get; set; }
        public int? LinkType { get; set; }
        public string Eventyear { get; set; }
        public string MenuCreatedby { get; set; }
        public DateTime? MenuCreateddate { get; set; }
        public string MenuUpdatedby { get; set; }
        public DateTime? MenuUpdateddate { get; set; }
        public int? TabActive { get; set; }
        public int? ParentId { get; set; }
        public string DataListBind { get; set; }
        public int? MenuOrder { get; set; }
    }
}
