using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Common.Enum
{
    /// <summary>
    /// 转账用到的枚举
    /// </summary>
    public class Transfer
    {
        /// <summary>
        /// 转账方式
        /// </summary>
        public enum TransferType
        {
            /// <summary>
            /// 消费收款—代付付款	3元—80元	转账金额*0.4%+2元，最低3元，最高82元；
            /// 用户转出银行—易通银行账户—用户收款银行	支持所有银联银行
            /// </summary>
            Pos_AgentPay = 0,

            /// <summary>
            /// 银联代收代付接口	2元—20元	根据转账金额梯度计算：
            /// 50元—1000元：2元；
            /// 1000元—5000元：3元；
            /// 5000元—10000元：5元；
            /// 10000元—20000元：10元；
            /// 用户转出银行—易通银行账户—用户收款银行	个别银行不支持代收通过消费通道收款，代付通道付款
            /// </summary>
            AgentReceive_AgentPay = 1,

            /// <summary>
            /// 银联银行转账接口	2元—50元	接口返回手续费+1元	用户转出银行直接到用户收款银行
            /// </summary>
            Pos_Only = 2,

            /// <summary>
            /// 建设银行银行转账接口	5元—100元	接口返回手续费+1元	用户转出银行直接到用户收款银行
            /// </summary>
            CBC_Api = 3

        }
    }
}
