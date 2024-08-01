using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class Logs
    {
        public int LogId { get; set; }
        public DateTime? LogDate { get; set; }
        public string LogMessage { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }
        public string UserId { get; set; }
    }
}
