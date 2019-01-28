using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Services.Notify
{
    public class SmsMessageArgs
    {
        public string Mobiles { get; set; }
        public string Content { get; set; }
        public DateTime? SendTime { get; set; }
    }
}
