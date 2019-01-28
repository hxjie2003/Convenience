using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.PaymentCollection
{
    /// <summary>
    /// 易富通帐户
    /// </summary>
    public class PaymentCollectionWalletAccount
    {
        /// <summary>
        /// 帐户编号
        /// </summary>
        public string AccountID
        {
            get;
            set;
        }
        /// <summary>
        /// 帐户名称
        /// </summary>
        public string AccountName
        {
            get;
            set;
        }
        /// <summary>
        /// 真实名称
        /// </summary>
        public string RealName
        {
            get;
            set;
        }
        /// <summary>
        /// 代收代付类型
        /// </summary>
        public List<PaymentCollectionType> PCollectionType
        {
            get;
            set;
        }
    }
}
