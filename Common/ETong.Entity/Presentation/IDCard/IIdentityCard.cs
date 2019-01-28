using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.IDCard
{
    /// <summary>
    /// 身份证读卡器接口
    /// </summary>
    public interface IIdentityCard
    {
        /// <summary>
        /// 读卡错误事件
        /// </summary>
        event Action<string> ReadCardError;

        /// <summary>
        /// 读卡成功事件
        /// </summary>
        event Action<CitizenInfo> ReadCardCompleted;

        /// <summary>
        /// 打开读卡器初始化
        /// </summary>
        /// <returns></returns>
        bool InitReader();

        /// <summary>
        /// 关闭读卡器
        /// </summary>
        /// <returns></returns>
        bool CloseReader();

        /// <summary>
        /// 读取身份证信息
        /// </summary>
        /// <returns></returns>
        bool ReadIDCard();

        /// <summary>
        /// 暂停读卡
        /// </summary>
        void PauseRead();

        /// <summary>
        /// 恢复读卡
        /// </summary>
        void ResumeRead();

        /// <summary>
        /// 测试连接是否成功
        /// </summary>
        /// <returns></returns>
        bool TestConnection();
    }
}
