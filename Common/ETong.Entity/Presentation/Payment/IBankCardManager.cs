using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ETong.Entity.Presentation.Payment
{
    public interface IBankCardManager
    {
        /// <summary>
        /// 非读卡错误信息
        /// </summary>
        string ErrorMessage { get; set; }

        /// <summary>
        /// 读卡错误事件
        /// </summary>
        event Action<string> ReadCardError;

        /// <summary>
        /// 读卡成功事件
        /// </summary>
        event Action<BankCardInfo> ReadBankCardInfoCompleted;

        /// <summary>
        /// 读卡号成功事件
        /// </summary>
        event Action<string> ReadBankCardNumberCompleted;

        /// <summary>
        /// 打开读卡器
        /// </summary>
        /// <returns></returns>
        bool InitReader();

        /// <summary>
        /// 关闭读卡器
        /// </summary>
        /// <returns></returns>
        bool CloseReader();

        /// <summary>
        /// 读卡信息
        /// </summary>
        /// <param name="payAmount">交易金额（分），IC卡需要</param>
        /// <param name="endPoint">终端号，IC卡需要</param>
        void ReadBankCardInfo(int payAmount, string endPoint);

        /// <summary>
        /// 读取卡号
        /// </summary>
        void ReadBankCardNumber();

        /// <summary>
        /// 退卡
        /// </summary>
        /// <returns></returns>
        bool ExitCard();

    }
}
