using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Payment
{
    /// <summary>
    /// 平台刷卡支付返回结果
    /// </summary>
    public class OpenPlatPosPayResult
    {
        /// <summary>
        /// 平台刷卡支付结果的具体数据集合
        /// </summary>
        public OpenPlatPosPayResultData[] result_list { get; set; }
        //[{"paymentBatchId":"20151012135942102513","orderNo":"ET201510091726592591","paymentOrderId":"20151012135942131330"},
        // {"paymentBatchId":"20151012135942102513","orderNo":"ET201510091720008109","paymentOrderId":"20151012135942148090"}],

        /// <summary>
        /// 会员id
        /// </summary>
        public string memberId { get; set; }

    }

    /// <summary>
    /// 平台刷卡支付结果的具体数据
    /// </summary>
    public class OpenPlatPosPayResultData
    {
        /// <summary>
        /// 平台支付批次号
        /// </summary>
        public string paymentBatchId { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string orderNo { get; set; }

        /// <summary>
        /// 支付记录号
        /// </summary>
        public string paymentOrderId { get; set; }

        /// <summary>
        /// 订单总金额（元）
        /// </summary>
        public decimal totalAmount { get; set; }

        /// <summary>
        /// "预计到账时间"(格式 yyyy-MM-dd HH:mm:ss)
        /// </summary>
        public string expectedAccountDate { get; set; }
    }
}
