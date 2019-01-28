using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ETong.Entity.Presentation.EtmEnvironment
{
    /// <summary>
    /// ETM设备信息类
    /// </summary>
    public class ETMDeviceInfo
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public string DriverID { get; set; }

        /// <summary>
        /// 设备类型（1、大机（带广告屏），2、小机（纯消费机））
        /// </summary>
        public string DriverType { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string DriverIP { get; set; }

        /// <summary>
        /// 远程维护系统管理员账号（创建新的管理员账户），这个有用到吗？
        /// </summary>
        public string DriverAdminAccount { get; set; }

        /// <summary>
        /// 远程维护系统管理员密码，这个有用到吗？
        /// </summary>
        public string DriverAdminPassword { get; set; }

        /// <summary>
        /// 网卡地址
        /// </summary>
        public string MacAddress { get; set; }

        /// <summary>
        /// CPU编号
        /// </summary>
        public string ProcessorId { get; set; }

        /// <summary>
        /// 安装位置
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 安装位置
        /// </summary>
        public string MapGis { get; set; }

        /// <summary>
        /// 安装人
        /// </summary>
        public string SetupBy { get; set; }

        /// <summary>
        /// 安装位置
        /// </summary>
        public string Remark { get; set; }

        //其它客户端要用到的信息

        /// <summary>
        /// 激活状态，0未激活，1已激活
        /// </summary>
        public int ActiveState { get; set; }

        /// <summary>
        /// 产权期限（空白为长期）
        /// </summary>
        public string PropertyDate { get; set; }

    }
}