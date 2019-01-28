using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Payment
{
    public class BankCardOutPutArgs
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 可用于前端显示的错误信息
        /// </summary>
        public string DisplayErrorMessage { get; set; }

        /// <summary>
        /// 卡号码
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 是否支持的信用卡
        /// </summary>
        public bool IsSupportedCreditCard { get; set; }


    }
}
