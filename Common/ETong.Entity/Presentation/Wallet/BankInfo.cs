using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Wallet
{
    /// <summary>
    /// 银行信息
    /// </summary>
    public class BankInfo
    {
        /// <summary>
        /// 银行代码
        /// </summary>
        public string BankCode 
        { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 银行排序
        /// </summary>
        public string BankSequence { get; set; }

        /// <summary>
        /// 银行图标路径
        /// </summary>
        public string IconUrl { get; set; }

    }
}