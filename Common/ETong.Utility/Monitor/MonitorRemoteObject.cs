using ETong.Utility.Log;
using System;

namespace ETong.Utility.Monitor
{
    /// <summary>
    /// 监控系统的远程通信
    /// </summary>
    public class MonitorRemoteObject : MarshalByRefObject
    {
        /// <summary>
        /// 获取硬件状态
        /// </summary>
        public static Func<ETong.Entity.Presentation.Monitor.Operate, Entity.Presentation.Monitor.EtmStatus> GetHardwareStateFunc { set; get; }

        /// <summary>
        /// 获取ETM版本信息
        /// </summary>
        public static Func<Entity.Presentation.Monitor.EtmStatus> GetEtmVersionFunc { set; get; }

        /// <summary>
        /// 推送
        /// </summary>
        public static Func<bool> PushUpgradeFunc { set; get; }

        /// <summary>
        /// 推送广告
        /// </summary>
        public static Func<bool> PushAdFunc { set; get; }

        /// <summary>
        /// 获取硬件状态
        /// </summary>
        /// <returns></returns>
        public Entity.Presentation.Monitor.EtmStatus GetHardwareState(ETong.Entity.Presentation.Monitor.Operate operate)
        {
            Logger.Write(Common.Enum.Log.Log_Type.Info, "准备硬件状态:" + ETong.Utility.Converts.Json.Encode(operate));

            Entity.Presentation.Monitor.EtmStatus result = new Entity.Presentation.Monitor.EtmStatus();

            try
            {
                if (GetHardwareStateFunc != null)
                {
                    result = GetHardwareStateFunc.Invoke(operate);
                }
            }
            catch (Exception ex)
            {
                Logger.Write(Common.Enum.Log.Log_Type.Error, ex.ToString());
            }

            Logger.Write(Common.Enum.Log.Log_Type.Info, "获取硬件状态完成:" + Utility.Converts.Json.Serialize(result));

            return result;
        }

        /// <summary>
        /// 获取ETM版本信息
        /// </summary>
        /// <returns></returns>
        public Entity.Presentation.Monitor.EtmStatus GetEtmVersion()
        {
            Logger.Write(Common.Enum.Log.Log_Type.Info, "准备获取ETM版本信息");

            Entity.Presentation.Monitor.EtmStatus result = new Entity.Presentation.Monitor.EtmStatus();

            try
            {
                if (GetEtmVersionFunc != null)
                {
                    result = GetEtmVersionFunc.Invoke();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(Common.Enum.Log.Log_Type.Error, ex.ToString());
            }

            Logger.Write(Common.Enum.Log.Log_Type.Info, "获取ETM版本信息完成:" + Utility.Converts.Json.Serialize(result));

            return result;
        }

        /// <summary>
        /// 推送升级
        /// </summary>
        /// <returns></returns>
        public bool PushUpgrade()
        {
            Logger.Write(Common.Enum.Log.Log_Type.Info, "准备推送升级");

            bool result = false;

            try
            {
                if (PushUpgradeFunc != null)
                {
                    result = PushUpgradeFunc.Invoke();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(Common.Enum.Log.Log_Type.Error, ex.ToString());
            }

            Logger.Write(Common.Enum.Log.Log_Type.Info, "推送升级完成:" + result);

            return result;
        }

        /// <summary>
        /// 推送广告
        /// </summary>
        /// <returns></returns>
        public bool PushAd()
        {
            Logger.Write(Common.Enum.Log.Log_Type.Info, "准备推送广告");

            bool result = false;

            try
            {
                if (PushAdFunc != null)
                {
                    result = PushAdFunc.Invoke();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(Common.Enum.Log.Log_Type.Error, ex.ToString());
            }

            Logger.Write(Common.Enum.Log.Log_Type.Info, "推送广告完成:" + result);

            return result;
        }

    }
}
