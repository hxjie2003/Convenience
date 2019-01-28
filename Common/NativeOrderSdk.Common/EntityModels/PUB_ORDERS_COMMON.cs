//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NativeOrderSdk.Common.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class PUB_ORDERS_COMMON
    {
        [Key]
        public string ORDER_ID { get; set; }
        public string ORDER_GROUP_ID { get; set; }
        public short IS_DELETE { get; set; }
        public Nullable<short> IS_CREDIT { get; set; }
        public short ORDER_STATUS { get; set; }
        public Nullable<short> SHIPPING_STATUS { get; set; }
        public Nullable<short> REFUND_MONEY_STATUS { get; set; }
        public Nullable<short> REFUND_GOODSMONEY_STATUS { get; set; }
        public Nullable<short> REFUND_CHANGGOODS_STATUS { get; set; }
        public Nullable<short> REFUND_REPAIR_STATUS { get; set; }
        public Nullable<short> TRANSFOR_STATUS { get; set; }
        public short ORDER_FROM { get; set; }
        public short ORDER_TYPE { get; set; }
        public short ORDER_CLASSIFY { get; set; }
        public short ITEM_TYPE { get; set; }
        public Nullable<short> OPERATE_STATUS { get; set; }
        public string PRODUCT_ID { get; set; }
        public string PRODUCT_NAME { get; set; }
        public Nullable<decimal> PRODUCT_PRICE { get; set; }
        public int PRODUCT_QUANTITY { get; set; }
        public string GOODS_ID { get; set; }
        public string GOODS_NAME { get; set; }
        public string GOODSCATEGORYSET_ID { get; set; }
        public string BRAND_NAME { get; set; }
        public decimal TOTAL_AMOUNT { get; set; }
        public short PAYMENT_STATUS { get; set; }
        public Nullable<System.DateTime> PAYMENT_DATE { get; set; }
        public string ORDER_ETM { get; set; }
        public string PAY_ETM { get; set; }
        public string MEMBER_ID { get; set; }
        public string CREATOR { get; set; }
        public string CREATOR_IP { get; set; }
        public System.DateTime CREATE_DATE { get; set; }
        public System.DateTime MODIFY_DATE { get; set; }
        public string STORE_ID { get; set; }
        public string STORE_NAME { get; set; }
        public string DELIVERY_SN { get; set; }
        public string DELIVERY_NAME { get; set; }
        public string SHIP_PROVINCES { get; set; }
        public string SHIP_CITY { get; set; }
        public string SHIP_REGION { get; set; }
        public string SHIP_ADDR { get; set; }
        public Nullable<System.DateTime> VERIFY_DELIVERY_DATE { get; set; }
        public string INST_ID { get; set; }
        public string DELIVERYTYPE_ID { get; set; }
        public string DELIVERYTYPENAME { get; set; }
        public Nullable<short> ISCOMMENTED { get; set; }
        public string IMGURL { get; set; }
        public string PRODUCT_DESCRIPTION { get; set; }
        public decimal TOTAL_COST { get; set; }
        public short ALLOCATION_STATUS { get; set; }
        public Nullable<short> PAYMENT_CHANNEL { get; set; }

        //public virtual PUB_ORDERS_EXTENDED PUB_ORDERS_EXTENDED { get; set; }
        [ForeignKey("ORDER_GROUP_ID")]
        public virtual PUB_ORDERS_GROUP PUB_ORDERS_GROUP { get; set; }
    }
}
