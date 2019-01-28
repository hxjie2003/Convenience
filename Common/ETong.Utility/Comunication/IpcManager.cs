using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETong.Utility.Log;

namespace ETong.Utility.Comunication
{
    public static class IpcManager
    {
        /// <summary>
        /// EtmClient的IPC客户端
        /// </summary>
        private static IpcService _etmInstance { set; get; }

        /// <summary>
        /// 更新程序的IPC客户端
        /// </summary>
        private static IpcService _upgradeInstance { set; get; }


        /// <summary>
        /// 广告
        /// </summary>
        private static IpcService _mediaPlayerInstance { set; get; }


        /// <summary>
        /// 监控服务端
        /// </summary>
        private static IpcService _monitorInstance { set; get; }


        /// <summary>
        /// 咖啡机
        /// </summary>
        private static IpcService _coffeeInstance { set; get; }


        /// <summary>
        /// 获取Ipc客户端
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns></returns>
        private static IpcService GetIpcInstance(string channelName)
        {
            try
            {
                return new IpcService(channelName);
            }
            catch (Exception ex)
            {
                Logger.Write(Common.Enum.Log.Log_Type.Error, string.Format("创建Ipc{0}客户端失败.{1}", channelName, ex));
                return null;
            }
        }

        /// <summary>
        /// 获取ETMClient的IPC客户端
        /// </summary>
        /// <returns></returns>
        public static IpcService GetEtmClient()
        {
            return _etmInstance ?? (_etmInstance = GetIpcInstance(IpcService.ChannelType.EtmClient.ToString()));
        }


        /// <summary>
        /// 获取UpgradeClient的IPC客户端
        /// </summary>
        /// <returns></returns>
        public static IpcService GetUpgradeClient()
        {
            return _upgradeInstance ?? (_upgradeInstance = GetIpcInstance(IpcService.ChannelType.UpgradeClient.ToString()));
        }


        /// <summary>
        /// 获取广告的IPC客户端
        /// </summary>
        /// <returns></returns>
        public static IpcService GetMediaPlayerClient()
        {
            return _mediaPlayerInstance ?? (_mediaPlayerInstance = GetIpcInstance(IpcService.ChannelType.MediaPlayerClient.ToString()));
        }


        /// <summary>
        /// 监控服务端
        /// </summary>
        /// <returns></returns>
        public static IpcService GetMonitorService()
        {
            return _monitorInstance ?? (_monitorInstance = GetIpcInstance(IpcService.ChannelType.MonitorService.ToString()));
        }
    }
}
