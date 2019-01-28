using System;

namespace ETong.Entity.Presentation.Monitor
{
    /// <summary>
    /// 命令的枚举类型
    /// </summary>
    [Serializable]
    public enum Operate
    {
        /// <summary>
        /// 关闭系统
        /// </summary>
        ShutdownWindows = 1,

        /// <summary>
        /// 重启系统
        /// </summary>
        RestartWindows = 2,

        /// <summary>
        /// 重启软件
        /// </summary>
        RestartProgram = 3,

        /// <summary>
        /// 读取日志
        /// </summary>
        ReadLog = 4,

        /// <summary>
        /// 上传文件
        /// </summary>
        UploadFiles = 5,

        /// <summary>
        /// 下载文件
        /// </summary>
        DownLoadFile = 6,

        /// <summary>
        /// 提醒升级
        /// </summary>
        PushUpgrade = 7,

        /// <summary>
        /// 硬盘信息
        /// </summary>
        HardDiskInfo = 8,

        /// <summary>
        /// 银行卡读卡器状态
        /// </summary>
        BankCardStatus = 9,

        /// <summary>
        /// 密码键盘状态
        /// </summary>
        PasswordKeyboardStatus = 10,

        /// <summary>
        /// 身份证读卡器状态
        /// </summary>
        IdentityCardStatus = 11,

        /// <summary>
        /// CPU状态
        /// </summary>
        CpuStatus = 12,

        /// <summary>
        /// 内存状态
        /// </summary>
        MemoryStatus = 13,

        /// <summary>
        /// 网络状态
        /// </summary>
        NetworkStatus = 14,

        /// <summary>
        /// 操作系统状态
        /// </summary>
        OsVersion = 15,

        /// <summary>
        /// 远程控制
        /// </summary>
        RemoteControl = 16,

        /// <summary>
        /// 广告更新提醒
        /// </summary>
        PushAd = 17,

        /// <summary>
        /// 所有状态
        /// </summary>
        AllStatus = 18,

        /// <summary>
        /// IC卡读卡器状态
        /// </summary>
        ICCardStatus = 19,


    }
}
