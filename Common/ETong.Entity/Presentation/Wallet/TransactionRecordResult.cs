using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Wallet
{
    /// <summary>
    /// 钱包交易结果
    /// </summary>
    public class TransactionRecordResult
    {
        public IList<TransactionRecord> TransactionRecords { get; set; }

        public int RecordCount { get; set; }
    }
}