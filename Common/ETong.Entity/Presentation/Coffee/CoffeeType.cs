using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Coffee
{   

    /// <summary>
    /// 饮料
    /// </summary>
    [Serializable]
    public class CoDrink
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 对应值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 物料属性集
        /// </summary>
        public List<Material> Materials { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 单杯价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 单杯咖啡容量(单位 ml)
        /// </summary>
        public int Capacity { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Intro { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class MakeDrinkReq {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 饮品
        /// </summary>
        public Drink Drink { get; set; }
    }
}
