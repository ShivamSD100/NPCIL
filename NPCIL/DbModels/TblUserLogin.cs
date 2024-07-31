using System;
using System.Collections.Generic;

namespace NPCIL.DbModels
{
    public partial class TblUserLogin
    {
        public int LoginSno { get; set; }
        public string LoginId { get; set; }
        public string LoginName { get; set; }
        public string LoginUserName { get; set; }
        public string LoginPassword { get; set; }
        public bool? LoginStatus { get; set; }
    }
}
