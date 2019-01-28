using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ETong.Common.Enum
{
    /// <summary>
    /// 应用类型
    /// </summary>
    public enum AppType
    {
        /// <summary>
        /// .NET WCF 服务
        /// </summary>
        NET_WCF_SERVICE = 1,
        /// <summary>
        /// .NET WCF 服务工厂
        /// </summary>
        NET_WCF_SERVICE_FACTORY = 2,
        /// <summary>
        /// .NET Web 服务
        /// </summary>
        NET_WEB_SERVICE = 3,
        /// <summary>
        /// .NET ETM WPF客户端程序
        /// </summary>
        NET_ETM_WPF = 4,
        /// <summary>
        ///.NET ETM Web应用程序
        /// </summary>
        NET_ETM_Web = 5,
        /// <summary>
        /// .NET 易通综合运营管理平台
        /// </summary>
        NET_ET_PLATFROM = 6,
        /// <summary>
        /// 移动WEB程序
        /// </summary>
        NET_MOBILE_WEB = 7,
        /// <summary>
        /// 苹果手机程序
        /// </summary>
        NET_MOBILE_IOS = 8,
        /// <summary>
        /// 安卓手机程序
        /// </summary>
        NET_MOBILE_Andriod = 9,
        /// <summary>
        /// JAVA商城
        /// </summary>
        JAVA_WEB_SHOP = 10,
        /// <summary>
        /// JAVA WEB 服务
        /// </summary>
        JAVA_WEB_SERVICE = 11,
        /// <summary>
        /// 杂项(各种小程序)
        /// </summary>
        MISC = 12
    }

    /// <summary>
    /// 错误严重程序类型
    /// </summary>
    [DataContract]
    public enum ErrorType
    {
        /// <summary>
        /// 致命的
        /// </summary>
        [EnumMember]
        PESTILENT = 1,
        /// <summary>
        /// 严重的
        /// </summary>
        [EnumMember]
        SERIOUS = 2,
        /// <summary>
        /// 一般的
        /// </summary>
        [EnumMember]
        COMMON = 3,
        /// <summary>
        /// 可忽略的
        /// </summary>
        [EnumMember]
        NEGLIGIBLE = 4
    }

    /// <summary>
    /// 数据库连接类型
    /// </summary>
    public enum ConnectionKeys
    {
        ETM_Architecture,
        ETM_Business,
        ET_Orders,
        ET_Member,
        ET_Products,
        ET_Pay,
        ET_Sync,
        ET_Products_V2

    }

    /// <summary>
    /// 服务插件任务类型
    /// </summary>
    [DataContract]
    public enum ServiceTaskType
    {
        /// <summary>
        /// 服务接口
        /// </summary>
        [EnumMember]
        JK_Interface = 1,
        /// <summary>
        /// 服务计划任务
        /// </summary>
        [EnumMember]
        JH_Schedule = 2,
        /// <summary>
        /// 服务回调
        /// </summary>
        [EnumMember]
        HD_Callback = 3,
        /// <summary>
        /// 其它杂项调用
        /// </summary>
        [EnumMember]
        ZX_Misc = 4
    }

    /// <summary>
    /// 服务插件回调类型
    /// </summary>
    [DataContract]
    public enum ServiceCallbackTaskType
    {
        /// <summary>
        /// 下单
        /// </summary>
        [EnumMember]
        SumbitOrder = 1,
        /// <summary>
        /// 撤单
        /// </summary>
        [EnumMember]
        CancelOrder = 2,
        /// <summary>
        /// 退款
        /// </summary>
        [EnumMember]
        MoneyBack = 3,
        /// <summary>
        /// 其它
        /// </summary>
        [EnumMember]
        Misc = 4
    }

    /// <summary>
    /// 服务调用返回错误类型
    /// </summary>
    [DataContract]
    public enum ServiceErrorType
    {
        /// <summary>
        /// 远程服务超时（服务关闭或者网络故障）
        /// </summary>
        [EnumMember]
        RequestTimeout = 1,
        /// <summary>
        /// 远程服务返回调用错误（由于数据格式或者其它原因引起）
        /// </summary>
        [EnumMember]
        RequestReturnError = 2,
        /// <summary>
        /// 本地数据关联更新或者读取失败
        /// </summary>
        [EnumMember]
        LocalDataFailed = 3,
        /// <summary>
        /// 找不到任务
        /// </summary>
        [EnumMember]
        NotFindTask=4,
        /// <summary>
        /// 没有错误
        /// </summary>
        [EnumMember]
        NoError=0
    }
}
