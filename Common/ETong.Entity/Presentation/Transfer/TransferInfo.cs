using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Transfer
{
    /// <summary>
    /// 转账信息
    /// </summary>
    public class TransferInfo
    {
        /// <summary>
        /// 银行转账订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 银行转账订单组号
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// 支付状态：未支付=0，部分支付=1，已支付=2，部分退款=3，全额退款=4，联合支付=5，无需支付=6
        /// </summary>
        public int PaymentStatus { get; set; }

        /// <summary>
        /// 转入账号
        /// </summary>
        public string ToAccountNo { get; set; }


        /// <summary>
        /// 转入账户名
        /// </summary>
        public string ToAccountName { get; set; }


        /// <summary>
        /// 转入账户省份名称
        /// </summary>
        public string ToAccountProvince { get; set; }


        /// <summary>
        /// 转入账户城市名
        /// </summary>
        public string ToAccountCity { get; set; }


        /// <summary>
        /// 转入银行名称
        /// </summary>
        public string ToBankName { get; set; }


        /// <summary>
        /// 转出账号
        /// </summary>
        public string FromAccountNo { get; set; }


        /// <summary>
        /// 转出账户名
        /// </summary>
        public string FromAccountName { get; set; }


        /// <summary>
        /// 转出账户省份名称
        /// </summary>
        public string FromAccountProvince { get; set; }


        /// <summary>
        /// 转出账户城市名
        /// </summary>
        public string FromAccountCity { get; set; }


        /// <summary>
        /// 转出银行名称
        /// </summary>
        public string FromBankName { get; set; }


        /// <summary>
        /// 转账金额
        /// </summary>
        public decimal TransferAmount { get; set; }


        /// <summary>
        /// 转账手续费
        /// </summary>
        public decimal TransferFee { get; set; }


        /// <summary>
        /// 交易状态：0 待处理，1 已支付，2 已转账，3 已到账，4 转账失败
        /// </summary>
        public int Status { get; set; }

        private string _depositTime = "24小时内";
        /// <summary>
        /// 到账时间，格式yyyy-MM-dd HH:mm:ss
        /// 如无法从接口获取数据，则统一显示为24小时内
        /// </summary>
        public string DepositTime
        {
            get { return this._depositTime; }
            set { if (this._depositTime != value) this._depositTime = value; }
        }


        /// <summary>
        /// 收款人手机号
        /// </summary>
        public string ReceiverMobile { get; set; }


        /// <summary>
        /// 付款人手机号
        /// </summary>
        public string PayerMobile { get; set; }


        /// <summary>
        /// 执行时机：0 立即执行，1 预约执行
        /// </summary>
        public int TradeClass { get; set; }


        /// <summary>
        /// 预约时间，格式yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string BookDate { get; set; }


        /// <summary>
        /// 支付流水号：银联参考号或代收单号
        /// </summary>
        public string PayRecordId { get; set; }


        /// <summary>
        /// 入账流水号：银联参考号或代付单号
        /// </summary>
        public string DepositRecordId { get; set; }


        /// <summary>
        /// 是否要通知结果：0 不要，1 要
        /// </summary>
        public int IsNeedNotify { get; set; }


        /// <summary>
        /// 附带信息
        /// </summary>
        public string AttachedMessage { get; set; }


        /// <summary>
        /// 转账方式：对应于转账方式表
        /// </summary>
        public int TransferType { get; set; }


        /// <summary>
        /// 银行支付商户号
        /// </summary>
        public string MerchantNo { get; set; }


        /// <summary>
        /// 银行支付终端号
        /// </summary>
        public string TerminalNo { get; set; }


        /// <summary>
        /// 是否已通知，0 未通知，1 已通知
        /// </summary>
        public int IsNotified { get; set; }


        /// <summary>
        /// 通知标志：0 短信，1 邮箱
        /// </summary>
        public int NotifyFlag { get; set; }

        private int _toBankCardType = 0;
        /// <summary>
        /// 转入卡类型（1：借记卡，2：贷记卡，3预付卡，4准贷记卡）
        /// </summary>
        public int ToBankCardType
        {
            get { return this._toBankCardType; }
            set
            {
                if (this._toBankCardType != value)
                {
                    this._toBankCardType = value;
                    switch (this._toBankCardType)
                    {
                        case 1: ToBankCardTypeName = "储蓄卡"; break;
                        case 2: ToBankCardTypeName = "信用卡"; break;
                        case 3: ToBankCardTypeName = "预付卡"; break;
                        case 4: ToBankCardTypeName = "准贷记卡"; break;
                        default: ToBankCardTypeName = "无法识别的卡"; break;
                    }
                }
            }
        }

        private string _toBankCardTypeName = string.Empty;
        /// <summary>
        /// 转入卡类型名称
        /// </summary>
        public string ToBankCardTypeName
        {
            get { return this._toBankCardTypeName; }
            set { if (this._toBankCardTypeName != value) this._toBankCardTypeName = value; }
        }

        /// <summary>
        /// 订单来源(旧库)：商城=0，ETM=1，进销存=2，B2C=3，APP=4
        /// 订单来源(新库)：etm=1，app=2，商城=3，进销存=4，b2c=5
        /// </summary>
        public int OrderFrom { get; set; }

        ///// <summary>
        ///// 实名认证信息
        ///// </summary>
        //public RealNameAuthInfo RealNameInfo { get; set; }

    }

    ///// <summary>
    ///// 身份认证信息
    ///// </summary>
    //public class RealNameAuthInfo
    //{
    //    /// <summary>
    //    /// 真实姓名
    //    /// </summary>
    //    public string Name { get; set; }

    //    /// <summary>
    //    /// 身份证号
    //    /// </summary>
    //    public string IdCardNum { get; set; }

    //}
}