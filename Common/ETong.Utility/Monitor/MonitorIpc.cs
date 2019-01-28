using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

namespace ETong.Utility.Monitor
{
    /// <summary>
    /// 监控IPC
    /// </summary>
    public class MonitorIpc
    {
        /// <summary>
        /// 服务端(受控端)信道名称
        /// </summary>
        private string ServerIpcChannelName { set; get; }

        /// <summary>
        /// IPC服务信道
        /// </summary>
        private IpcChannel ServerChannel { set; get; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sname"></param>
        public MonitorIpc(string sname)
        {
            ServerIpcChannelName = sname;
        }

        /// <summary>
        /// 远程模块名字
        /// </summary>
        /// <returns></returns>
        public bool RunIpcService()
        {
            // 创建一个IPC信道，不同于TCP或HTTP，信道通过名称来访问
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht["portName"] = ServerIpcChannelName;
            ht["name"] = ServerIpcChannelName;
            ht["authorizedGroup"] = "Everyone";

            BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
            serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            ServerChannel = new IpcChannel(ht, null, serverProvider);

            // 注册这个IPC信道.
            System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(ServerChannel, false);
            // 向信道暴露一个远程对象.
            System.Runtime.Remoting.RemotingConfiguration.RegisterWellKnownServiceType(typeof(MonitorRemoteObject), "RemoteObject.Monitor", System.Runtime.Remoting.WellKnownObjectMode.Singleton);

            return true;
        }

        /// <summary>
        /// 停止IPC服务
        /// </summary>
        /// <returns></returns>
        public bool StopIpcService()
        {
            if (ServerChannel != null)
            {
                ServerChannel.StopListening(null);

                ChannelServices.UnregisterChannel(ServerChannel);
                ServerChannel = null;
            }
            return true;

        }


        /// <summary>
        /// 获取连接状态
        /// </summary>
        /// <returns></returns>
        public Entity.Presentation.Monitor.EtmStatus GetHardwareState(ETong.Entity.Presentation.Monitor.Operate operate)
        {
            MonitorRemoteObject service = (MonitorRemoteObject)Activator.GetObject(typeof(MonitorRemoteObject), "Ipc://" + ServerIpcChannelName + "/RemoteObject.Monitor");
            return service.GetHardwareState(operate);
        }

        /// <summary>
        /// 获取ETM版本信息
        /// </summary>
        /// <returns></returns>
        public Entity.Presentation.Monitor.EtmStatus GetEtmVersion()
        {
            MonitorRemoteObject service = (MonitorRemoteObject)Activator.GetObject(typeof(MonitorRemoteObject), "Ipc://" + ServerIpcChannelName + "/RemoteObject.Monitor");
            return service.GetEtmVersion();
        }

        /// <summary>
        /// 推送升级
        /// </summary>
        /// <returns></returns>
        public bool PushUpgrade()
        {
            MonitorRemoteObject service = (MonitorRemoteObject)Activator.GetObject(typeof(MonitorRemoteObject), "Ipc://" + ServerIpcChannelName + "/RemoteObject.Monitor");
            return service.PushUpgrade();
        }

        /// <summary>
        /// 推送广告
        /// </summary>
        /// <returns></returns>
        public bool PushAd()
        {
            MonitorRemoteObject service = (MonitorRemoteObject)Activator.GetObject(typeof(MonitorRemoteObject), "Ipc://" + ServerIpcChannelName + "/RemoteObject.Monitor");
            return service.PushAd();
        }

    }
}
