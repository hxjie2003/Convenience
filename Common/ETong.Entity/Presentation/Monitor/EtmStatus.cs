using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Monitor
{
    /// <summary>
    /// ETM状态
    /// </summary>
    [Serializable]
    public class EtmStatus
    {
        /// <summary>
        /// ETMID
        /// </summary>
        public string EtmId { get; set; }

        /// <summary>
        /// 银行卡读卡器状态，如“正常”、“异常”、“未知”
        /// </summary>
        public string BankCardReader { get; set; }

        /// <summary>
        /// 密码键盘状态，如“正常”、“异常”、“未知”
        /// </summary>
        public string PasswordKeyboard { get; set; }

        /// <summary>
        /// 身份证读卡器状态，如“正常”、“异常”、“未知”
        /// </summary>
        public string IdentityCardReader { get; set; }

        /// <summary>
        /// IC卡读卡器状态，如“正常”、“异常”、“未知”
        /// </summary>
        public string ICCardReader { get; set; }

        /// <summary>
        /// 硬盘最少可用空间，如“剩余xM”。
        /// 最好是可以取到ETM所在程序的磁盘的可用空间，获取其他磁盘都没意义。
        /// </summary>
        public string HardDisk { get; set; }

        /// <summary>
        /// 内存使用状态，如“50%”
        /// </summary>
        public string Memory { get; set; }


        public string CPU
        {
            get;
            set;
        }

        public string Network
        {
            get;
            set;
        }

        /// <summary>
        /// ETM主程序当前版本
        /// </summary>
        public string EtmVersion { get; set; }

        /// <summary>
        /// 信息更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

    }
}
