using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.PaymentCollection
{
    /// <summary>
    /// 代收代付款类型
    /// </summary>
    public class PaymentCollectionType
    {
        /// <summary>
        /// 代收代付编号
        /// </summary>
        public string PaymentCollectionTypeCode
        {
            get;
            set;
        }
        /// <summary>
        /// 类型ID为数字
        /// </summary>
        public int PaymentCollectionTypeID
        {
            get;
            set;
        }
        /// <summary>
        /// 代收代付名称
        /// </summary>
        public string PaymentCollectionName
        {
            get;
            set;
        }
        /// <summary>
        /// 代收代付备注
        /// </summary>
        public string Remark
        {
            get;
            set;
        }     
    }
}
