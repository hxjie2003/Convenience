using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Services.DeliveryAddress
{
    public class Delivery
    {

        /// <summary>
        ///     流水号
        /// </summary>
        public string DelivId { get; set; }

        /// <summary>
        ///     收货人真实姓名
        /// </summary>
        public string TrueName { get; set; }

        /// <summary>
        ///     收货地址id路径
        /// </summary>
        public string LocationPath { get; set; }

        /// <summary>
        ///     地址详细
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     邮编
        /// </summary>
        public int? Post { get; set; }

        /// <summary>
        ///     联系手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        ///     固定电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        ///     是否默认
        /// </summary>
        public int IsDefault { get; set; }

        /// <summary>
        ///     会员id
        /// </summary>
        public string MemberId { get; set; }

        /// <summary>
        ///     国家
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///     省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        ///     市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///     县、区
        /// </summary>
        public string District { get; set; }
    }
}
