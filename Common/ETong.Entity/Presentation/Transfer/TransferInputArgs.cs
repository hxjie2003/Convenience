using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Transfer
{
    /// <summary>
    /// 转账用的输入参数
    /// </summary>
    public class TransferInputArgs
    {
        /// <summary>
        /// 会员id
        /// </summary>
        public string MemberId { get; set; }

        /// <summary>
        /// 会员名称
        /// </summary>
        public string MemberName { get; set; }

        #region 收款人信息

        /// <summary>
        /// 转入卡类型（1：借记卡，2：贷记卡，3预付卡，4准贷记卡）
        /// </summary>
        public int ToBankCardType { get; set; }

        /// <summary>
        /// 转入卡类型名称
        /// </summary>
        public string ToBankCardTypeName { get; set; }

        /// <summary>
        /// 转入银行名称
        /// </summary>
        public string ToBankName { get; set; }

        /// <summary>
        /// 收款账户（卡号）
        /// </summary>
        public string ToAccountNo { get; set; }

        /// <summary>
        /// 收款账户名
        /// </summary>
        public string ToAccountName { get; set; }

        /// <summary>
        /// 收款账户开户行省份名称
        /// </summary>
        public string ToAccountProvince { get; set; }

        /// <summary>
        /// 收款账户开户行城市名称
        /// </summary>
        public string ToAccountCity { get; set; }

        /// <summary>
        /// 收款人手机号
        /// </summary>
        public string ReceiverMobile { get; set; }

        #endregion 收款人信息

        /// <summary>
        /// 转账金额（元）
        /// </summary>
        public decimal TransferAmount { get; set; }

        /// <summary>
        /// 转账手续费（元）
        /// </summary>
        public decimal TransferFee { get; set; }
        
        /// <summary>
        /// 付款人身份证号
        /// </summary>
        public string IdCardNo { get; set; }

        /// <summary>
        /// 付款人真实姓名
        /// </summary>
        public string IdCardName { get; set; }

        /// <summary>
        /// ETM编号
        /// </summary>
        public string ETMId { get; set; }

        /// <summary>
        /// ETM所在IP
        /// </summary>
        public string ETMIp { get; set; }

        /// <summary>
        /// 附带信息
        /// </summary>
        public string AttachedMessage { get; set; }

        #region 付款人信息

        /// <summary>
        /// 付款人手机号
        /// </summary>
        public string PayerMobile { get; set; }

        /// <summary>
        /// 转出账号
        /// </summary>
        public string FromAccountNo { get; set; }
        
        /// <summary>
        /// 转出账户名
        /// </summary>
        public string FromAccountName { get; set; }

        /// <summary>
        /// 转出银行名称
        /// </summary>
        public string FromBankName { get; set; }

        #endregion 付款人信息

        /// <summary>
        /// 易通订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 银联参考号
        /// </summary>
        public string BankReferenceNo { get; set; }

        /// <summary>
        /// 订单来源(旧库)：商城=0，ETM=1，进销存=2，B2C=3，APP=4
        /// 订单来源(新库)：etm=1，app=2，商城=3，进销存=4，b2c=5
        /// </summary>
        public string OrderFrom { get; set; }

    }
}
