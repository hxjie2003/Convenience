using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.Monitor
{
    [Serializable]
    public class HarddiskInfo
    {
        // 摘要: 
        //     指示驱动器上的可用空闲空间量。
        //
        // 返回结果: 
        //     驱动器上的可用空闲空间量（以字节为单位）。
        //
        // 异常: 
        //   System.UnauthorizedAccessException:
        //     拒绝访问驱动器信息。
        //
        //   System.IO.IOException:
        //     发生了 I/O 错误（例如，磁盘错误或驱动器未准备好）。
        public long AvailableFreeSpace { get; set; }

        //
        // 摘要: 
        //     获取文件系统的名称，例如 NTFS 或 FAT32。
        //
        // 返回结果: 
        //     指定驱动器上文件系统的名称。
        //
        // 异常: 
        //   System.UnauthorizedAccessException:
        //     拒绝访问驱动器信息。
        //
        //   System.IO.DriveNotFoundException:
        //     该驱动器不存在或未映射。
        //
        //   System.IO.IOException:
        //     发生了 I/O 错误（例如，磁盘错误或驱动器未准备好）。
        public string DriveFormat { get; set; }
        //
        // 摘要: 
        //     获取驱动器类型。
        //
        // 返回结果: 
        //     System.IO.DriveType 值之一。
        public DriveType DriveType { get; set; }
        //
        // 摘要: 
        //     获取一个指示驱动器是否已准备好的值。
        //
        // 返回结果: 
        //     如果驱动器已准备好，则为 true；如果驱动器未准备好，则为 false。
        public bool IsReady { get; set; }
        //
        // 摘要: 
        //     获取驱动器的名称。
        //
        // 返回结果: 
        //     驱动器的名称。
        public string Name { get; set; }

        //
        // 摘要: 
        //     获取驱动器上的可用空闲空间总量。
        //
        // 返回结果: 
        //     驱动器上的可用空闲空间总量（以字节为单位）。
        //
        // 异常: 
        //   System.UnauthorizedAccessException:
        //     拒绝访问驱动器信息。
        //
        //   System.IO.DriveNotFoundException:
        //     该驱动器未映射或不存在。
        //
        //   System.IO.IOException:
        //     发生了 I/O 错误（例如，磁盘错误或驱动器未准备好）。
        public long TotalFreeSpace { get; set; }
        //
        // 摘要: 
        //     获取驱动器上存储空间的总大小。
        //
        // 返回结果: 
        //     驱动器的总大小（以字节为单位）。
        //
        // 异常: 
        //   System.UnauthorizedAccessException:
        //     拒绝访问驱动器信息。
        //
        //   System.IO.DriveNotFoundException:
        //     该驱动器未映射或不存在。
        //
        //   System.IO.IOException:
        //     发生了 I/O 错误（例如，磁盘错误或驱动器未准备好）。
        public long TotalSize { get; set; }
        //
        // 摘要: 
        //     获取或设置驱动器的卷标。
        //
        // 返回结果: 
        //     卷标。
        //
        // 异常: 
        //   System.IO.IOException:
        //     发生了 I/O 错误（例如，磁盘错误或驱动器未准备好）。
        //
        //   System.IO.DriveNotFoundException:
        //     该驱动器未映射或不存在。
        //
        //   System.Security.SecurityException:
        //     调用方没有所要求的权限。
        //
        //   System.UnauthorizedAccessException:
        //     正在网络或 CD-ROM 驱动器上设置卷标。 - 或 - 拒绝访问驱动器信息。
        public string VolumeLabel { get; set; }
    }
}
