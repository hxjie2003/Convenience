using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Monitor
{
 
    /// <summary>
    /// 内存信息
    /// </summary>
    [Serializable]
    public class MemoryInfo
    {
        /// <summary>
        /// 内存长度
        /// </summary>
        public uint DwLength { get; set; }

        /// <summary>
        /// 正在使用内存大小
        /// </summary>
        public uint DwMemoryLoad { get; set; }

        /// <summary>
        /// 物理内存大小
        /// </summary>
        public uint DwTotalPhys { get; set; }

        /// <summary>
        /// 可使用的物理内存
        /// </summary>
        public uint DwAvailPhys { get; set; }

        /// <summary>
        /// 交换文件总大小
        /// </summary>
        public uint DwTotalPageFile { get; set; }

        /// <summary>
        /// 可使用文件总大小
        /// </summary>
        public uint DwAvailPageFile { get; set; }

        /// <summary>
        /// 总虚拟内存
        /// </summary>
        public uint DwTotalVirtual { get; set; }

        /// <summary>
        /// 可使用虚拟内存
        /// </summary>
        public uint DwAvailVirtual { get; set; } 
    }
}
