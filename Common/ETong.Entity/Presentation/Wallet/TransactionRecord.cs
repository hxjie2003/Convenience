using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETong.Entity.Presentation.Wallet
{
    /// <summary>
    /// 钱包交易记录
    /// </summary>
    public class TransactionRecord
    {
        /// <summary>
        /// 记录ID
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }

        private int _orderType = -1;
        /// <summary>
        /// 订单类型
        /// 0: 充值
        /// 1: 转帐
        /// 2: 提现
        /// 3: 退款
        /// 4: 购物
        /// 5: 便民服务
        /// 6: 金融理财
        /// 7: 购买保险
        /// 8: 代收货款
        /// </summary>
        public int OrderType
        {
            get
            {
                return _orderType;
            }

            set
            {
                if (value != _orderType)
                {
                    _orderType = value;
                    string typeName = string.Empty;
                    switch (_orderType)
                    {
                        case 0: typeName = "充值";
                            break;
                        case 1: typeName = "转帐";
                            break;
                        case 2: typeName = "提现";
                            break;
                        case 3: typeName = "退款";
                            break;
                        case 4: typeName = "购物";
                            break;
                        case 5: typeName = "便民服务";
                            break;
                        case 6: typeName = "金融理财";
                            break;
                        case 7: typeName = "购买保险";
                            break;
                        case 8: typeName = "代收货款";
                            break;

                    }

                    OrderTypeName = typeName;

                }
            }
        }

        /// <summary>
        /// 订单类型名称
        /// </summary>
        public string OrderTypeName { get; set; }

        private int _payType = -1;
        /// <summary>
        /// 收支类别
        /// 0: 收入 1: 支出
        /// </summary>
        public int PayType
        {
            get
            {
                return _payType;
            }

            set
            {
                if (value != _payType)
                {
                    _payType = value;
                    string typeName = string.Empty;
                    switch (_payType)
                    {
                        case 0: typeName = "收入";
                            break;
                        case 1: typeName = "支出";
                            break;

                    }

                    PayTypeName = typeName;

                }
            }
        }

        /// <summary>
        /// 收支类别名称
        /// </summary>
        public string PayTypeName { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal Amount { get; set; }

        private int _tradeStatus = -1;
        /// <summary>
        /// 交易状态
        /// 0: 等待付款
        /// 1: 交易中
        /// 2: 交易完成
        /// 3: 交易失败
        /// 4: 等待退款
        /// 5: 退款完成
        /// 6: 退款失败
        /// </summary>
        public int TradeStatus
        {
            get
            {
                return _tradeStatus;
            }

            set
            {
                if (value != _tradeStatus)
                {
                    _tradeStatus = value;
                    string typeName = string.Empty;
                    switch (_tradeStatus)
                    {
                        case 0: typeName = "等待付款";
                            break;
                        case 1: typeName = "交易中";
                            break;
                        case 2: typeName = "交易完成";
                            break;
                        case 3: typeName = "交易失败";
                            break;
                        case 4: typeName = "等待退款";
                            break;
                        case 5: typeName = "退款完成";
                            break;
                        case 6: typeName = "退款失败";
                            break;

                    }

                    TradeStatusName = typeName;

                }
            }
        }

        /// <summary>
        /// 交易状态描述
        /// </summary>
        public string TradeStatusName { get; set; }

        /// <summary>
        /// 交易时间(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        public string TxnTime { get; set; }

        /// <summary>
        /// 创建时间(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        public string CreateDate { get; set; }

        /// <summary>
        /// 帐户名称
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Remark { get; set; }

        private int _tradeType = -1;
        /// <summary>
        /// 交易方类型
        /// 0: 表示交易方是电子钱包帐户
        /// 1: 表示商城
        /// 2: 表示ETM
        /// 3: 表示APP
        /// 4: 表示其它第三方
        /// </summary>
        public int TradeType
        {
            get
            {
                return _tradeType;
            }

            set
            {
                if (value != _tradeType)
                {
                    _tradeType = value;
                    string typeName = string.Empty;
                    switch (_tradeType)
                    {
                        case 0: typeName = "电子钱包帐户";
                            break;
                        case 1: typeName = "商城";
                            break;
                        case 2: typeName = "ETM";
                            break;
                        case 3: typeName = "APP";
                            break;
                        case 4: typeName = "第三方";
                            break;

                    }

                    TradeTypeName = typeName;

                }
            }
        }

        /// <summary>
        /// 交易方类型名称
        /// </summary>
        public string TradeTypeName { get; set; }

        /// <summary>
        /// 交易对方名称
        /// </summary>
        public string TradeName { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public double FreeAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 实际金额
        /// </summary>
        public double TotalAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 支付方式编号
        /// </summary>
        public string PayChannel { get; set; }

        /// <summary>
        /// 支付方式名称
        /// </summary>
        public string PayChannelName { get; set; }

    }

}