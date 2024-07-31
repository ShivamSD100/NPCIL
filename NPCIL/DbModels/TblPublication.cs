using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblPublication
    {
        public int PubId { get; set; }
        public int? PubLanguage { get; set; }
        public int? PubType { get; set; }
        public string PubTitle { get; set; }
        public string PubAuthorName { get; set; }
        public string PubFileUpload { get; set; }
        public string PubOthers { get; set; }
        public string PubCreatedBy { get; set; }
        public DateTime? PubCreatedDate { get; set; }
        public string PubUpdatedBy { get; set; }
        public DateTime? PubUpdatedDate { get; set; }
    }
}
