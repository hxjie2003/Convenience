using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence.Message
{
    public class SmsMessageArgs
    {
        public string Mobiles { get; set; }
        public string Content { get; set; }
        public DateTime? SendTime { get; set; }
    }
}
