using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

namespace ETong.Utility.Comunication
{
    /// <summary>
    /// IPC服务
    /// </summary>
    public class IpcService
    {
        /// <summary>
        /// 频道类型
        /// </summary>
        public enum ChannelType
        {
            /// <summary>
            /// ETM主程序客户端
            /// </summary>
            EtmClient,

            /// <summary>
            /// 更新程序客户端
            /// </summary>
            UpgradeClient,

            /// <summary>
            /// 监控客户端
            /// </summary>
            MonitorClient,

            /// <summary>
            /// 广告客户端
            /// </summary>
            MediaPlayerClient,

            /// <summary>
            /// 监控服务端
            /// </summary>
            MonitorService,

        }

        #region IPC服务

        /// <summary>
        /// 服务端(受控端)信道名称
        /// </summary>
        private string ChannelName { set; get; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sname">IPC服务名称</param>
        public IpcService(string sname)
        {
            ChannelName = sname;
        }

        /// <summary>
        /// IPC服务信道
        /// </summary>
        private IpcChannel ServerChannel { set; get; }

        /// <summary>
        /// 启动IPC服务
        /// </summary>
        /// <returns></returns>
        public bool StartIpc()
        {
            // 创建一个IPC信道，不同于TCP或HTTP，信道通过名称来访问
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht["portName"] = ChannelName;
            ht["name"] = "ipc";
            ht["authorizedGroup"] = "Everyone";

            BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
            serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            ServerChannel = new IpcChannel(ht, null, serverProvider);

            // 注册这个IPC信道.
            ChannelServices.RegisterChannel(ServerChannel, false);
            // 向信道暴露一个远程对象.
            System.Runtime.Remoting.RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObject), "RemoteObject.Monitor", System.Runtime.Remoting.WellKnownObjectMode.Singleton);

            return true;
        }

        /// <summary>
        /// 停止IPC服务
        /// </summary>
        /// <returns></returns>
        public bool StopIpc()
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
        /// 执行远程命令
        /// </summary>
        /// <param name="josnParams">josn类型参数</param>
        /// <returns></returns>
        public string DoCommand(string josnParams)
        {
            RemoteObject service = (RemoteObject)Activator.GetObject(typeof(RemoteObject), "Ipc://" + ChannelName + "/RemoteObject.Monitor");
            return service.DoCommand(josnParams);
        }

        #endregion
    }


    /// <summary>
    /// 远程对象
    /// </summary>
    public class RemoteObject : MarshalByRefObject
    {
        /// <summary>
        /// 执行远程命令
        /// </summary>
        public static Func<string, string> DoFunc { set; get; }

        /// <summary>
        /// 根据参数返回结果
        /// </summary>
        /// <param name="josnParams"></param>
        /// <returns></returns>
        public string DoCommand(string josnParams)
        {
            string josnresult = string.Empty;

            if (DoFunc != null)
            {
                josnresult = DoFunc.Invoke(josnParams);
            }

            return josnresult;
        }
    }
}
