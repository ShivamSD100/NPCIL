using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblTender
    {
        public int TenderId { get; set; }
        public string TendorNo { get; set; }
        public string TendorIssuingAuthEng { get; set; }
        public string TendorIssuingAuthHindi { get; set; }
        public DateTime? TenderStartDateSellingTender { get; set; }
        public DateTime? TenderEndDateSellingTender { get; set; }
        public DateTime? TenderDateOpening { get; set; }
        public DateTime? TenderStartDateReceivingTender { get; set; }
        public DateTime? TenderEndDateReceivingTender { get; set; }
        public DateTime? TenderPrebidDate { get; set; }
        public string TenderScopeEng { get; set; }
        public string TenderScopeHindi { get; set; }
        public string TenderBodyEng { get; set; }
        public string TenderBodyHindi { get; set; }
        public bool? TenderMarkImportant { get; set; }
        public string TenderCost { get; set; }
        public string TenderEmd { get; set; }
        public bool? TenderIsArchived { get; set; }
        public DateTime? TenderArchivedDate { get; set; }
        public string TenderCreatedby { get; set; }
        public DateTime? TenderCreatedDate { get; set; }
        public string TenderUpdatedBy { get; set; }
        public DateTime? TenderUpdatedDate { get; set; }
        public int? TenderType { get; set; }
        public string TenderUrl { get; set; }
        public string TenderUpload { get; set; }
        public int? TenderPosition { get; set; }
    }
}
