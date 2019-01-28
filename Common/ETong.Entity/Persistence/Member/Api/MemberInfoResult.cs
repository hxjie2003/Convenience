using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence
{
    /// <summary>
    /// 这个类已作废
    /// </summary>
    [Obsolete]
    public class MemberInfoResult
    {
        public string MemberId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string Levelid { get; set; }
        public string LevelName { get; set; }
        public int Score { get; set; }
        public string CardID { get; set; }
    }
}
