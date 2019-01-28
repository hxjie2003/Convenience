using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence
{
    /// <summary>
    /// 会员更改密码参数
    /// </summary>
    public class ChangePasswordArgs
    {
        /// <summary>
        /// 会员ID/会员实名/会员手机
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 原密码
        /// </summary>
        public string OldPassword { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPassword { get; set; }
    }

}
