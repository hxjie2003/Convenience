using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.CreditCard
{
    /// <summary>
    /// 信用卡订单详情
    /// </summary>
    public class CreditCardOrderInfo
    {

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 下单会员名称
        /// </summary>
        public string CREATOR { get; set; }
        /// <summary>
        /// 下单会员IP地址
        /// </summary>
        public string CREATOR_IP { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public string GOODS_ID { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GOODS_NAME { get; set; }
        /// <summary>
        /// 订单购买会员ID
        /// </summary>
        public string MEMBER_ID { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? MODIFY_DATE { get; set; }
        /// <summary>
        /// 下订单时ETM机编号
        /// </summary>
        public string ORDER_ETM { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public int? ORDER_FROM { get; set; }
        /// <summary>
        /// 订单组编号
        /// </summary>
        public string ORDER_GROUP_ID { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string ORDER_ID { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int? ORDER_STATUS { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public int? ORDER_TYPE { get; set; }
        /// <summary>
        /// 订单支付时ETM机编号
        /// </summary>
        public string PAY_ETM { get; set; }
        /// <summary>
        /// 停用，支付渠道 (0：中国人民银行，1：中国工商银行,2:中国建设银行，3：中国农业银行，10：预付款支付，11：代金券支付，12：积分支付，……)
        /// </summary>
        public int? PAYMENT_CHANNEL { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime? PAYMENT_DATE { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public int? PAYMENT_STATUS { get; set; }
        /// <summary>
        /// 商品规格描述
        /// </summary>
        public string PRODUCT_DESCRIPTION { get; set; }
        /// <summary>
        /// 货品ID
        /// </summary>
        public string PRODUCT_ID { get; set; }
        /// <summary>
        /// 货品名称
        /// </summary>
        public string PRODUCT_NAME { get; set; }
        /// <summary>
        /// 货品价格
        /// </summary>
        public decimal? PRODUCT_PRICE { get; set; }
        /// <summary>
        /// 货品总数
        /// </summary>
        public int? PRODUCT_QUANTITY { get; set; }

        /// <summary>
        /// 商家ID
        /// </summary>
        public string STORE_ID { get; set; }

        /// <summary>
        /// 商家名称
        /// </summary>
        public string STORE_NAME { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal? TOTAL_AMOUNT { get; set; }

        /// <summary>
        /// 信用卡卡号
        /// </summary>
        public string CreditCardNo { get; set; }

        /// <summary>
        /// 信用卡对应银行
        /// </summary>
        public string CreditCardBank { get; set; }


        /// <summary>
        /// 开户地区
        /// </summary>
        public string CreditCardArea { get; set; }

        /// <summary>
        /// 持卡人姓名
        /// </summary>
        public string CreditCardUserName { get; set; }
        /// <summary>
        /// 还款金额
        /// </summary>
        public decimal? CreditCardAmount { get; set; }
        /// <summary>
        /// 到账时间
        /// </summary>
        public DateTime? CreditCardReceiptTime { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public float CreditCardFactorage { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string CreditCardMobile { get; set; }
    }




}
