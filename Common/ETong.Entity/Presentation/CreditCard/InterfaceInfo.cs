using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.CreditCard
{
    /// <summary>
    /// 信用卡还款接口信息
    /// </summary>
    public class InterfaceInfo
    {
        /// <summary>
        /// 是否支持
        /// </summary>
        public bool IsSupported { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public InterfaceProvider ProviderName { get; set; }
 
    }


    /// <summary>
    /// 接口供应商名称
    /// </summary>
    public enum InterfaceProvider
    {
        /// <summary>
        /// 银联POS
        /// </summary>
        BankPos = 1,
        /// <summary>
        /// 高汇通
        /// </summary>
        GHT = 2,
    }
}
