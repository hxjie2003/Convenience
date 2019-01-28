using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Coffee
{
    /// <summary>
    /// 咖啡机初始化调用返回实体类
    /// </summary>
    public class CoffeeInit
    {
        /// <summary>
        /// 咖啡机状态 0：正常  1：未开机 2：其它故障
        /// </summary>
        public string StateCode { get; set; }
        /// <summary>
        /// ETM机编号
        /// </summary>
        public string EtmID { get; set; }
        /// <summary>
        /// 当前剩余咖啡杯数
        /// </summary>
        public int CupNumber { get; set; }
        /// <summary>
        /// 是否已发短信
        /// </summary>
        public string SendSMS { get; set; }
        /// <summary>
        /// 饮料集
        /// </summary>
        public List<Drink> DrinkList { get; set; }  
    }
}
