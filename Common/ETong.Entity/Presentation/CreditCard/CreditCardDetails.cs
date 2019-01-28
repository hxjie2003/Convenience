using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.CreditCard
{
    /// <summary>
    /// 信用卡订单明细
    /// </summary>
    public class CreditCardDetails
    {
        /// <summary>
        /// 会员ID,必填
        /// </summary>
        public string memberId { get; set; }

        /// <summary>
        /// 会员名称
        /// </summary>
        public string memberName { get; set; }

        /// <summary>
        /// 创建IP
        /// </summary>
        public string reqIp { get; set; }

        /// <summary>
        /// 付款银行卡号
        /// </summary>
        public string payBankCard { get; set; }

        /// <summary>
        /// 付款银行名称
        /// </summary>
        public string payBankName { get; set; }

        /// <summary>
        /// 付款人姓名
        /// </summary>
        public string payName { get; set; }

        /// <summary>
        /// 信用卡卡号
        /// </summary>
        public string cardNo { get; set; }

        /// <summary>
        /// 还款金额
        /// </summary>
        public string amount { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public string feeAmount { get; set; }

        /// <summary>
        /// 信用卡开户银行
        /// </summary>
        public string bankName { get; set; }

        /// <summary>
        /// 开户省份
        /// </summary>
        public string province { get; set; }

        /// <summary>
        /// 开户城市
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// 信用卡开户姓名
        /// </summary>
        public string payeeName { get; set; }

        /// <summary>
        /// 联系人手机号
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        /// 付款通道1：银联,2：高汇通
        /// </summary>
        public string payType { get; set; }

        /// <summary>
        /// 订单来源
        /// </summary>
        public string orderFrom { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public string lat { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public string lon { get; set; }

        /// <summary>
        /// ETM编号
        /// </summary>
        public string etmCode { get; set; }
    }

}
