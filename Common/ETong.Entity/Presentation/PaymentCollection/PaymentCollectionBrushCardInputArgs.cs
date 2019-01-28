using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.PaymentCollection
{
    /// <summary>
    /// 刷卡代付时输入参数
    /// </summary>
    public class PaymentCollectionBrushCardInputArgs
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        public string MemberID
        {
            get;
            set;
        }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo
        {
            get;
            set;
        }

        /// <summary>
        /// 收款帐户名称
        /// </summary>
        public string ReceiveAccountName
        {
            get;
            set;
        }

        /// <summary>
        /// 收款帐户真实名称
        /// </summary>
        public string ReceiveAccountRealName
        {
            get;
            set;
        }

        /// <summary>
        /// 付款金额
        /// </summary>
        public decimal Amount
        {
            get;
            set;
        }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName
        {
            get;
            set;
        }
        /// <summary>
        /// 类型ID
        /// </summary>
        public int TypeID
        {
            get;
            set;
        }
        /// <summary>
        /// 付款银行名称
        /// </summary>
        public string PayBankName
        {
            get;
            set;
        }

        /// <summary>
        /// 付款银行帐户
        /// </summary>
        public string PayBankAccount
        {
            get;
            set;
        }

        /// <summary>
        /// 银行卡名称  传空值
        /// </summary>
        public string PayName
        {
            get;
            set;
        }

        /// <summary>
        /// 银行卡刷卡流水编号
        /// </summary>
        public string QueryID
        {
            get;
            set;
        }

        /// <summary>
        /// ETM编号
        /// </summary>
        public string ETMId { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobileNo
        {
            get;
            set;
        }

    }
}
