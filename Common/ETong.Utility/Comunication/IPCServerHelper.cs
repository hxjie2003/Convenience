using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.Remoting.Channels.Ipc;
using System.Security.Permissions;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Runtime.Remoting.Channels;

namespace ETong.Utility
{
    /// <summary>
    /// IPC服务
    /// </summary>
    public class IPCServerHelper
    {
        #region IPC服务

        /// <summary>
        /// 服务端(受控端)信道名称
        /// </summary>
        private string ServerIPCChannelName { set; get; }

        /// <summary>
        /// 客户端(控制端)信道名称
        /// </summary>
        private string ClientIPCChannelName { set; get; }

        ///// <summary>
        ///// 远程对象访问uri
        ///// </summary>
        //private string RemoteObjectUri { set; get; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sname">IPC服务名称</param>
        /// <param name="cname">客户端IPC服务名称</param>
        public IPCServerHelper(string sname, string cname)
        {
            ServerIPCChannelName = sname;
            ClientIPCChannelName = cname;
        }

        /// <summary>
        /// IPC服务信道
        /// </summary>
        private IpcChannel ServerChannel { set; get; }

        /// <summary>
        /// 启动IPC服务
        /// </summary>
        /// <returns></returns>
        public bool StartIPC()
        {
            // 创建一个IPC信道，不同于TCP或HTTP，信道通过名称来访问
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht["portName"] = ServerIPCChannelName;
            ht["name"] = "ipc";
            ht["authorizedGroup"] = "Everyone";

            BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
            serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            ServerChannel = new IpcChannel(ht, null, serverProvider);

            // 注册这个IPC信道.
            System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(ServerChannel, false);
            // 向信道暴露一个远程对象.
            System.Runtime.Remoting.RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObject), "RemoteObject.Upgrade", System.Runtime.Remoting.WellKnownObjectMode.Singleton);

            return true;
        }

        /// <summary>
        /// 停止IPC服务
        /// </summary>
        /// <returns></returns>
        public bool StopIPC()
        {
            if (ServerChannel != null)
            {
                ServerChannel.StopListening(null);

                System.Runtime.Remoting.Channels.ChannelServices.UnregisterChannel(ServerChannel);
                ServerChannel = null;
            }
            return true;

        }

        /// <summary>
        /// 调用文件下载服务
        /// </summary>
        /// <returns></returns>
        public void DownloadFile()
        {
            RemoteObject service = (RemoteObject)Activator.GetObject(typeof(RemoteObject), "Ipc://" + ClientIPCChannelName + "/RemoteObject.Upgrade");
            service.DownloadFile();
            service = null;

        }

        /// <summary>
        /// 调用文件升级服务
        /// </summary>
        /// <returns></returns>
        public void UpgradeFile()
        {
            RemoteObject service = (RemoteObject)Activator.GetObject(typeof(RemoteObject), "Ipc://" + ClientIPCChannelName + "/RemoteObject.Upgrade");
            service.UpgradeFile();
            service = null;

        }

        #endregion
    }

    /// <summary>
    /// 远程对象
    /// </summary>
    public class RemoteObject : MarshalByRefObject
    {
        /// <summary>
        ///下载文件
        /// </summary>
        public static Action DownloadAction { set; get; }

        /// <summary>
        ///文件升级
        /// </summary>
        public static Action UpgradeAction { set; get; }

        /// <summary>
        /// 下载文件调用
        /// </summary>     
        public void DownloadFile()
        {
            if (DownloadAction != null)
            {
                DownloadAction.Invoke();
            }
        }

        /// <summary>
        /// 文件升级调用
        /// </summary>     
        public void UpgradeFile()
        {
            if (UpgradeAction != null)
            {
                UpgradeAction.Invoke();
            }
        }

    }
}
