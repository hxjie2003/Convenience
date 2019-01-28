using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Wallet.Input
{
    /// <summary>
    /// webapi输入参数-身份认证类
    /// </summary>
    public class InputAuth : InputBase
    {
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNo { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 性别 0：男，1：女
        /// </summary>
        public int Sex { get; set; }

    }
}