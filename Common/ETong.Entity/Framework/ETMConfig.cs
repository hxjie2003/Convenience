// <copyright file="ETMConfig.cs" company="ETong">
//     Copyright (c) ETong. All rights reserved.
// </copyright>
// <author>wind</author>
using System;
using System.Configuration;

namespace ETong.Entity.Framework
{
    /// <summary>
    /// 配置的修改与保存
    /// </summary>
    public class ETMConfig
    {
        /// <summary>
        /// 密码键盘串口
        /// </summary>
        public string KeyboardComPoint { get; set; }

        /// <summary>
        /// 程序已确认的密码键盘串口，只在当前程序有效
        /// </summary>
        public string ConfirmKeyboardComPoint { get; set; }

        /// <summary>
        /// 密码键盘波特率
        /// </summary>
        public string KeyboardBaudRate { get; set; }

        /// <summary>
        /// 银行卡读卡器串口
        /// </summary>
        public string BankCardComPoint { get; set; }

        /// <summary>
        /// 程序已确认的银行卡读卡器串口，只在当前程序有效
        /// </summary>
        public string ConfirmBankCardComPoint { get; set; }

        /// <summary>
        /// 是否使用1角支付(测试用)
        /// </summary>
        public bool IsUserOneJiaoPay { get; set; }

        /// <summary>
        /// 支付终端号--从数据库读取
        /// </summary>
        [DefaultSettingValue("")]
        public string EndPointNum
        {
            get;
            set;
        }

        /// <summary>
        /// 支付商户号--从数据库读取
        /// </summary>
        [DefaultSettingValue("")]
        public string MerchantNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 银联易通服务器密钥
        /// </summary>
        public string UnionPayDesKey { get; set; }

        /// <summary>
        /// 银联易通服务器ip
        /// </summary>
        public string UnionPayServerIP { get; set; }

        /// <summary>
        /// 银联易通服务器端口
        /// </summary>
        public string UnionPayServerPort { get; set; }

        /// <summary>
        /// 银联终端服务webapi
        /// </summary>
        public string BankTerminalServiceUri { get; set; }

        /// <summary>
        /// 验证码超时的时间,操作超时注销登录配置需CancelLoginTime要大于此配置时间
        /// </summary>
        public TimeSpan AuthCodeTimeOut { get; set; }

        /// <summary>
        /// ETM设备ID
        /// </summary>
        public string ETMId { get; set; }

        /// <summary>
        /// 定时注销用户的时间
        /// </summary>
        [DefaultSettingValue("180")]
        public string CancelLoginTime { get; set; }

        /// <summary>
        /// 定时升级间隔时间（分钟）
        /// </summary>
        [DefaultSettingValue("60")]
        public string AutoUpdateTime { get; set; }

        /// <summary>
        /// ETM是否开机启动
        /// </summary>
        public bool IsETMAutoRun { get; set; }
    }
}