using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace ETong.Entity.Presentation.Monitor
{
    public class EtmInfo
    {
        /// <summary>
        /// ETM ID
        /// </summary>
        public string ETMId { get; set; }

        /// <summary>
        /// ETM设备类型，1大机，2小机
        /// </summary>

        public int DeviceType { get; set; }


        /// <summary>
        /// 激活状态，0未激活，1已激活
        /// </summary>
        public int ActiveState { get; set; }


        /// <summary>
        /// 产权期限（空白为长期）
        /// </summary>

        public string PropertyDate { get; set; }

        /// <summary>
        /// 设备状态（1、未启用，2、正常，3、离线，4、故障，5、停用，6、注销）
        /// </summary>
        public int DeviceState { get; set; }

        public string AGENT_ID
        {
            get;
            set;
        }

        public string DEALER_ID
        {
            get;
            set;
        }

        public string DRIVER_IP
        {
            get;
            set;
        }

        public string ADDRESS_LOCATION
        {
            get;
            set;
        }

        public EtmStatus ETMStatus
        {
            get;
            set;
        }
    }
}
