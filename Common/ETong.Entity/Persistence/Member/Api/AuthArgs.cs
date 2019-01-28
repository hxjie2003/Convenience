using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence
{
    /// <summary>
    /// 普通登录信息，用户名，手机号，邮箱号
    /// </summary>
    public class AuthArgs
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string IP { get; set; }
    }
}
