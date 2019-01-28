using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Payment
{
    public interface IKeyboardManager
    {
        #region 事件处理

        /// <summary>
        /// 键盘操作错误事件
        /// </summary>
        event Action<string> KeyboardOperateError;

        /// <summary>
        /// 获取密码成功事件
        /// </summary>
        event Action<string> InputPasswordCompleted;

        ///// <summary>
        ///// 输入密码错误事件，如输入错误字符、未达到指定长度等
        ///// </summary>
        //event Action<string> InputPasswordError;

        /// <summary>
        /// 按下退出键事件，提示是否真的退出
        /// </summary>
        event Func<bool> KeyboardExitEvent;

        /// <summary>
        /// 输入密码字符变更通知
        /// </summary>
        event Action<string> InputPasswordChangeEvent;

        #endregion 事件处理

        /// <summary>
        /// 错误信息
        /// </summary>
        string ErrorMessage { get; set; }

        /// <summary>
        /// 输入中的密码
        /// </summary>
        string Pwd { get; set; }

        /// <summary>
        /// 打开端口及必要的初始化操作
        /// </summary>
        /// <returns></returns>
        bool InitPort();

        ///// <summary>
        ///// 关闭端口
        ///// </summary>
        ///// <returns></returns>
        //bool ClosePort();

        /// <summary>
        /// 关闭串口、停止线程等
        /// </summary>
        void ReleaseResourse();

        /// <summary>
        /// 激活工作密钥，工作密钥不为空的话则灌工作密钥
        /// </summary>
        /// <param name="mainKeyIndex">主密钥索引</param>
        /// <param name="workCode">pin工作密钥</param>
        /// <param name="macCode">mac工作密钥</param>
        /// <param name="cardNumber">卡号</param>
        /// <returns></returns>
        bool ReadPasswordBefore(int mainKeyIndex, string workCode, string macCode, string cardNumber);

        /// <summary>
        /// 获取输入的密码
        /// </summary>
        void GetPassword();

        /// <summary>
        /// 灌主密钥（下载主密钥）
        /// </summary>
        /// <param name="mainKeyIndex">主密钥位置索引，范围0-15</param>
        /// <param name="ucKey">主密钥</param>
        /// <returns></returns>
        bool LoadMainKey(int mainKeyIndex, string ucKey);

        /// <summary>
        /// 灌工作密钥（下载工作密钥）
        /// </summary>
        /// <param name="mainKeyIndex">主密钥位置索引</param>
        /// <param name="workKeyIndex">工作密钥位置索引</param>
        /// <param name="ucKey">工作密钥</param>
        /// <returns></returns>
        bool LoadWorkKey(int mainKeyIndex, int workKeyIndex, string ucKey);

        /// <summary>
        /// 数据MAC运算，失败返回空值
        /// </summary>
        /// <param name="mainKeyIndex">主密钥位置索引</param>
        /// <param name="mab">供计算MAC的数据</param>
        /// <returns></returns>
        string GenerateMacxxx(int mainKeyIndex, string mab);

        // <summary>
        /// 数据MAC运算，失败返回空值 - 不通过密码键盘
        /// </summary>
        /// <param name="macKey">mac工作密钥</param>
        /// <param name="mab">供计算MAC的数据</param>
        /// <returns></returns>
        string GenerateMacDirectly(string macKey, string mab);

        /// <summary>
        /// 测试连接是否成功
        /// </summary>
        /// <returns></returns>
        bool TestConnection();
    }
}
