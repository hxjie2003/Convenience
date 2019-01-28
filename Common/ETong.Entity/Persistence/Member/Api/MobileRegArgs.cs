using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence
{
    /// <summary>
    /// 普通注册信息
    /// </summary>
    public class MobileRegArgs
    {
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string IP { get; set; }
    }
}
