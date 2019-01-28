namespace ETong.Entity.Framework
{
    /// <summary>
    /// 银行终端号配置信息
    /// </summary>
    public class BankTerminalInfo
    {
        /// <summary>
        /// ETMID
        /// </summary>
        public string ETMID { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MerchantNo { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        public string TerminalNo { get; set; }

        /// <summary>
        /// 银行机构代码，可以多个
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 帐单号码类型
        /// </summary>
        public string AccountType { get; set; }

        /// <summary>
        /// 是否要入账，0否 1是
        /// </summary>
        public int IsBooked { get; set; }

        /// <summary>
        /// 入账用机构代码
        /// </summary>
        public string BookOrganCode { get; set; }

        /// <summary>
        /// 主密钥保存在密码键盘的位置，0其它 1易通 2光大 3招行 4广发
        /// </summary>
        public int KeypadIndex { get; set; }

        /// <summary>
        /// 主密钥是否已下载,0否,1是
        /// </summary>
        public int IsKeyDownloaded { get; set; }

        /// <summary>
        /// 主密钥
        /// </summary>
        public string MainKey { get; set; }

        /// <summary>
        /// ETM终端号配置流水号
        /// </summary>
        public string ETM_TerminalSettingId { get; set; }
    }
}