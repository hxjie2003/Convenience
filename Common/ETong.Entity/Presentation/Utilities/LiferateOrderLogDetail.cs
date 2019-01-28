using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Utilities
{
    /// <summary>
    /// 生活费用代缴明细表
    /// </summary>
    public class LiferateOrderLogDetail
    {
        /// <summary>
        /// 业务分类,0:水费，1:电费，2:燃气费
        /// </summary>
        public int? RATE_TYPE { get; set; }

        /// <summary>
        /// 下单日期
        /// </summary>
        public DateTime? BOOK_TIME { get; set; }

        /// <summary>
        /// 订订单号
        /// </summary>
        public string ORDER_ID { get; set; }

        /// <summary>
        /// 费用用户编号
        /// </summary>
        public string RATE_USERCODE { get; set; }

        /// <summary>
        /// 订单总金额
        /// </summary>
        public decimal? RATE_TOTAL { get; set; }

    }
}
