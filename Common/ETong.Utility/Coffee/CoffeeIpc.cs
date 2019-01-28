using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using ETong.Entity.Presentation.Coffee;

namespace ETong.Utility.Coffee
{
    /// <summary>
    /// 咖啡机IPC管理
    /// </summary>
    public class CoffeeIpc
    {
        /// <summary>
        /// 服务端(受控端)信道名称
        /// </summary>
        private string ServerIPCChannelName { set; get; }

        /// <summary>
        /// IPC服务信道
        /// </summary>
        private IpcChannel ServerChannel { set; get; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sname"></param>
        public CoffeeIpc(string sname)
        {
            ServerIPCChannelName = sname;
        }

        /// <summary>
        /// 远程模块名字
        /// </summary>
        /// <param name="remoteObjectName"></param>
        /// <returns></returns>
        public bool RunIPCService()
        {
            // 创建一个IPC信道，不同于TCP或HTTP，信道通过名称来访问
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht["portName"] = ServerIPCChannelName;
            ht["name"] = ServerIPCChannelName;
            ht["authorizedGroup"] = "Everyone";

            BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
            serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            ServerChannel = new IpcChannel(ht, null, serverProvider);

            // 注册这个IPC信道.
            System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(ServerChannel, false);
            // 向信道暴露一个远程对象.
            System.Runtime.Remoting.RemotingConfiguration.RegisterWellKnownServiceType(typeof(CoffeeRemoteObject), "RemoteObject.Coffee", System.Runtime.Remoting.WellKnownObjectMode.Singleton);

            return true;
        }

        /// <summary>
        /// 停止IPC服务
        /// </summary>
        /// <returns></returns>
        public bool StopIPCService()
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
        public bool GetDrinkConnectStatus()
        {
            CoffeeRemoteObject service = (CoffeeRemoteObject)Activator.GetObject(typeof(CoffeeRemoteObject), "Ipc://" + ServerIPCChannelName + "/RemoteObject.Coffee");
            return service.GetDrinkConnectStatus();
        }

        /// <summary>
        /// 获取Drink列表
        /// </summary>
        /// <returns></returns>
        public List<Drink> GetDrinkList()
        {
            CoffeeRemoteObject service = (CoffeeRemoteObject)Activator.GetObject(typeof(CoffeeRemoteObject), "Ipc://" + ServerIPCChannelName + "/RemoteObject.Coffee");
            return service.GetDrinkList();
        }


        /// <summary>
        /// 获取Drinks状态
        /// </summary>
        /// <returns></returns>
        public List<Drink> GetCurDrinks()
        {
            CoffeeRemoteObject service = (CoffeeRemoteObject)Activator.GetObject(typeof(CoffeeRemoteObject), "Ipc://" + ServerIPCChannelName + "/RemoteObject.Coffee");
            return service.GetCurDrinks();
        }



        /// <summary>
        /// 重置DrinkClient客户端
        /// </summary>
        public void ResetDrinkClient()
        {
            CoffeeRemoteObject service = (CoffeeRemoteObject)Activator.GetObject(typeof(CoffeeRemoteObject), "Ipc://" + ServerIPCChannelName + "/RemoteObject.Coffee");
            service.ResetDrinkClient();
        }


        /// <summary>
        /// 冲饮料
        /// </summary>
        /// <param name="drinks"></param>
        public void MadeDrinks(WebInputArgs webInputArgs)
        {
            CoffeeRemoteObject service = (CoffeeRemoteObject)Activator.GetObject(typeof(CoffeeRemoteObject), "Ipc://" + ServerIPCChannelName + "/RemoteObject.Coffee");
            service.MadeDrinks(webInputArgs);
        }


        /// <summary>
        /// 回调给客户端
        /// </summary>
        /// <param name="drink"></param>
        public void PushCallBack(Drink drink)
        {
            CoffeeRemoteObject service = (CoffeeRemoteObject)Activator.GetObject(typeof(CoffeeRemoteObject), "Ipc://" + ServerIPCChannelName + "/RemoteObject.Coffee");
            service.PushCallBack(drink);
        }

        /// <summary>
        /// 回调客户端开门
        /// </summary>
        /// <param name="drink"></param>
        public void OpenDoor(Drink drink)
        {
            CoffeeRemoteObject service = (CoffeeRemoteObject)Activator.GetObject(typeof(CoffeeRemoteObject), "Ipc://" + ServerIPCChannelName + "/RemoteObject.Coffee");
            service.OpenDoor(drink);
        }
    }
}
