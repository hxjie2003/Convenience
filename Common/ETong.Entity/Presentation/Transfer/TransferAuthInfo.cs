using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Transfer
{
    /// <summary>
    /// 转账认证信息
    /// </summary>
    public class TransferAuthInfo
    {
        /// <summary>
        /// 授权id
        /// </summary>
        public string AuthorizationId { get; set; }

        /// <summary>
        /// 主订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdcardNum { get; set; }

        /// <summary>
        /// 身份证姓名
        /// </summary>
        public string IdcardName { get; set; }

        /// <summary>
        /// 付款账号
        /// </summary>
        public string PayerAccountNo { get; set; }

        /// <summary>
        /// 付款账户名
        /// </summary>
        public string PayerAccountName { get; set; }

        /// <summary>
        /// 支付密码验证结果
        /// </summary>
        public string PayPasswordAuth { get; set; }

        /// <summary>
        /// 授权时间
        /// </summary>
        public string AuthorizationTime { get; set; }

    }
}
