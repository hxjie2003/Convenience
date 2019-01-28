using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Persistence.Hospital
{
    /// <summary>
    /// 预约订单
    /// </summary>
    public class HospitalOrderEntity
    {
        /// <summary>
        /// 订单明细json
        /// </summary>
        public HospitalOrderExtent content { get; set; }

        /// <summary>
        /// 订单ID
        /// </summary>
        public string order_id { get; set; }
    }
}
