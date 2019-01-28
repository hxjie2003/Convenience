using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Utility.Monitor
{
    /// <summary>
    /// 监控IPC管理器
    /// </summary>
    public class MonitorIpcManage
    {
        /// <summary>
        /// 获取监控Ipc服务端
        /// </summary>
        /// <returns></returns>
        public static MonitorIpc GetMonitorIpcService()
        {
            MonitorIpc monitorIpc = new MonitorIpc("MonitorIpcService");
            monitorIpc.RunIpcService();
            return monitorIpc;
        }

        /// <summary>
        /// 获取监控Ipc客户端
        /// </summary>
        /// <returns></returns>
        public static MonitorIpc GetMonitorIpcClient()
        {
            MonitorIpc monitorIpc = new MonitorIpc("MonitorIpcService");
            return monitorIpc;
        }

        /// <summary>
        /// 获取升级Ipc服务端
        /// </summary>
        /// <returns></returns>
        public static MonitorIpc GetUpgradeIpcService()
        {
            MonitorIpc monitorIpc = new MonitorIpc("MonitorUpgradeIpcService");
            monitorIpc.RunIpcService();
            return monitorIpc;
        }

        /// <summary>
        /// 获取监控Ipc客户端
        /// </summary>
        /// <returns></returns>
        public static MonitorIpc GetUpgradeIpcClient()
        {
            MonitorIpc monitorIpc = new MonitorIpc("MonitorUpgradeIpcService");
            return monitorIpc;
        }

        /// <summary>
        /// 获取广告Ipc服务端
        /// </summary>
        /// <returns></returns>
        public static MonitorIpc GetAdIpcService()
        {
            MonitorIpc monitorIpc = new MonitorIpc("MonitorAdIpcService");
            monitorIpc.RunIpcService();
            return monitorIpc;
        }

        /// <summary>
        /// 获取广告Ipc客户端
        /// </summary>
        /// <returns></returns>
        public static MonitorIpc GetAdIpcClient()
        {
            MonitorIpc monitorIpc = new MonitorIpc("MonitorAdIpcService");
            return monitorIpc;
        }


        /// <summary>
        /// 获取ETMIpc服务端
        /// </summary>
        /// <returns></returns>
        public static MonitorIpc GetEtmIpcService()
        {
            MonitorIpc monitorIpc = new MonitorIpc("MonitorEtmIpcService");
            monitorIpc.RunIpcService();
            return monitorIpc;
        }

        /// <summary>
        /// 获取ETMIpc客户端
        /// </summary>
        /// <returns></returns>
        public static MonitorIpc GetEtmIpcClient()
        {
            MonitorIpc monitorIpc = new MonitorIpc("MonitorEtmIpcService");
            return monitorIpc;
        }
    }
}
