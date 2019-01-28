using System;

namespace ETong.Entity.Framework
{
    [Serializable]
    /// <summary>
    /// ETM机配置信息接口
    /// </summary>
    ///
    public class ETMGlobalInfo
    {
        /// <summary>
        /// ETM机配置信息
        /// </summary>
        public MachineInfo EtmMachineInfo { get; set; }

        /// <summary>
        /// ETM是否正在支付过程中
        /// </summary>
        public bool IsInPaying { get; set; }

        /// <summary>
        /// 支付监控用计时器
        /// </summary>
        public System.Windows.Threading.DispatcherTimer PayMoniteTimer { get; set; }
    }
}