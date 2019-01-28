using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Payment
{
    /// <summary>
    /// 银行卡信息
    /// </summary>
    public class BankCardInfo
    {
        /// <summary>
        /// 第二磁道
        /// </summary>
        public string SecondNum { get; set; }
        /// <summary>
        /// 第三磁道
        /// </summary>
        public string ThirdNum { get; set; }

        /// <summary>
        /// 是否IC卡
        /// </summary>
        public bool IsICCard;

        /// <summary>
        /// 读取IC卡出现的错误信息
        /// </summary>
        public string ICCardErrorMessage { get; set; }

        ///// <summary>
        ///// 交易金额（分）
        ///// </summary>
        //public int PayAmount { get; set; }

        /// <summary>
        /// IC卡标签信息
        /// </summary>
        public ICCardTagInfo ICCardTags { get; set; }

        /// <summary>
        /// 卡属银行机构代码，用于查询支付渠道id
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 支付卡类型（1：借记卡，2：贷记卡，3预付卡，4准贷记卡）
        /// </summary>
        public int BankCardType { get; set; }

        /// <summary>
        /// 卡属银行名称
        /// </summary>
        public string BankName { get; set; }
    }
}
