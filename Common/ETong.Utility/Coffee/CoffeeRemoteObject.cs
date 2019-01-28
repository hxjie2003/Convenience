using ETong.Utility.Log;
using System;
using System.Collections.Generic;
using ETong.Entity.Presentation.Coffee;

namespace ETong.Utility.Coffee
{
    /// <summary>
    /// 咖啡机远程通信
    /// </summary>
    public class CoffeeRemoteObject : MarshalByRefObject
    {
        /// <summary>
        /// 获取连接状态的函数
        /// </summary>
        public static Func<bool> GetDrinkConnectStatusFunc { set; get; }

        /// <summary>
        /// 获取Drink列表函数
        /// </summary>
        public static Func<List<Drink>> GetDrinkListFunc { set; get; }


        /// <summary>
        /// 获取当前Drinks状态
        /// </summary>
        public static Func<List<Drink>> GetCurDrinksFunc { set; get; }

        /// <summary>
        /// 重置DrinkClient客户端
        /// </summary>
        public static Action ResetDrinkClientAction { set; get; }

        /// <summary>
        /// 冲饮料
        /// </summary>
        public static Action<WebInputArgs> MadeDrinksAction { set; get; }

        /// <summary>
        /// 回调通知客户端
        /// </summary>
        public static Action<Drink> PushCallBackAction { set; get; }

        /// <summary>
        /// 开门的回调
        /// </summary>
        public static Action<Drink> OpenDoorAction { set; get; }

        /// <summary>
        /// 获取Drink连接状态
        /// </summary>
        /// <returns></returns>
        public bool GetDrinkConnectStatus()
        {
            Logger.Write(Common.Enum.Log.Log_Type.Info, "准备获取饮料机状态");

            bool result = false;

            try
            {
                if (GetDrinkConnectStatusFunc != null)
                {
                    result = GetDrinkConnectStatusFunc.Invoke();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(Common.Enum.Log.Log_Type.Error, ex.ToString());
            }

            Logger.Write(Common.Enum.Log.Log_Type.Info,"获取饮料机状态完成:" + result);

            return result;
        }

        /// <summary>
        /// 获取Drink列表
        /// </summary>
        /// <returns></returns>
        public List<Drink> GetDrinkList()
        {
            Logger.Write(Common.Enum.Log.Log_Type.Info, "准备获取饮料机列表");

            List<Drink> result = null;

            try
            {
                if (GetDrinkListFunc != null)
                {
                    result = GetDrinkListFunc.Invoke();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(Common.Enum.Log.Log_Type.Info, ex.ToString());
            }

            Logger.Write(Common.Enum.Log.Log_Type.Info, "准备获取饮料机列表完成:" + ETong.Utility.Converts.Json.Encode(result));

            return result;
        }


        /// <summary>
        /// 获取饮料状态列表
        /// </summary>
        /// <returns></returns>
        public List<Drink> GetCurDrinks()
        {
            Logger.Write(Common.Enum.Log.Log_Type.Info, "准备获取饮料机状态列表");

            List<Drink> result = null;

            try
            {
                if (GetCurDrinksFunc != null)
                {
                    result = GetCurDrinksFunc.Invoke();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(Common.Enum.Log.Log_Type.Info, ex.ToString());
            }

            Logger.Write(Common.Enum.Log.Log_Type.Info, "准备获取饮料机状态列表完成:" + ETong.Utility.Converts.Json.Encode(result));

            return result;
        }



        /// <summary>
        /// 重置DrinkClient客户端
        /// </summary>
        public void ResetDrinkClient()
        {
            Logger.Write(Common.Enum.Log.Log_Type.Info, "准备重置饮料机客户端");

            try
            {
                if (ResetDrinkClientAction != null)
                {
                    ResetDrinkClientAction.Invoke();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(Common.Enum.Log.Log_Type.Info, ex.ToString());
            }

            Logger.Write(Common.Enum.Log.Log_Type.Info, "重置饮料机客户端完成");
        }

        /// <summary>
        /// 冲饮料
        /// </summary>
        /// <param name="webInputArgs"></param>
        public void MadeDrinks(WebInputArgs webInputArgs)
        {
            Logger.Write(Common.Enum.Log.Log_Type.Info, "准备冲饮料,参数为:" + ETong.Utility.Converts.Json.Encode(webInputArgs));

            try
            {
                if (MadeDrinksAction != null)
                {
                    MadeDrinksAction.Invoke(webInputArgs);
                }
            }
            catch (Exception ex)
            {
                Logger.Write(Common.Enum.Log.Log_Type.Info, ex.ToString());
            }

            Logger.Write(Common.Enum.Log.Log_Type.Info, "冲饮料执行完毕.");
        }


        /// <summary>
        /// 回调给客户端
        /// </summary>
        /// <param name="drink"></param>
        public void PushCallBack(Drink drink)
        {
            Logger.Write(Common.Enum.Log.Log_Type.Info, "准备回调给客户端,参数为:" + ETong.Utility.Converts.Json.Encode(drink));

            try
            {
                if (PushCallBackAction != null)
                {
                    PushCallBackAction.Invoke(drink);
                }
            }
            catch (Exception ex)
            {
                Logger.Write(Common.Enum.Log.Log_Type.Info, ex.ToString());
            }

            Logger.Write(Common.Enum.Log.Log_Type.Info, "回调给客户端执行完毕.");
        }


        /// <summary>
        /// 开门回调
        /// </summary>
        /// <param name="drink"></param>
        public void OpenDoor(Drink drink)
        {
            Logger.Write(Common.Enum.Log.Log_Type.Info, "准备开门回调给客户端,参数为:" + ETong.Utility.Converts.Json.Encode(drink));

            try
            {
                if (OpenDoorAction != null)
                {
                    OpenDoorAction.Invoke(drink);
                }
            }
            catch (Exception ex)
            {
                Logger.Write(Common.Enum.Log.Log_Type.Info, ex.ToString());
            }

            Logger.Write(Common.Enum.Log.Log_Type.Info, "开门回调给客户端执行完毕.");
        }
    }
}
