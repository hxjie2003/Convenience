using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.CoreOrder.Client.Model 
{



    public class GetOrderResponse
    {
        public string sign { get; set; }
        public string reqTime { get; set; }
        public GetOrderDatamap dataMap { get; set; }
        public string respCode { get; set; }
        public string respMsg { get; set; }
        public string respTime { get; set; }
    }

    public class GetOrderDatamap
    {
        public GetOrderResult_VO result_VO { get; set; }
        public GetOrderResult_Detail result_detail { get; set; }
        public string memberId { get; set; }
    }

    public class GetOrderResult_VO
    {
        public string orderId { get; set; }
        public int isDelete { get; set; }
        public int isCredit { get; set; }
        public string orderStatus { get; set; }
        public string orderStatusEnum { get; set; }
        public string orderSubStatus { get; set; }
        public string orderDraftStatusEnum { get; set; }
        public string orderFinishStatusEnum { get; set; }
        public int orderFrom { get; set; }
        public string orderFromEnum { get; set; }
        public int orderType { get; set; }
        public string orderTypeEnum { get; set; }
        public int orderClassify { get; set; }
        public float totalAmount { get; set; }
        public string paymentStatus { get; set; }
        public string paymentStatusEnum { get; set; }
        public int paymentType { get; set; }
        public string paymentTypeEnum { get; set; }
        public string paymentOrderId { get; set; }
        public string paymentAccountId { get; set; }
        public string paymentBatchNo { get; set; }
        public string paymentDate { get; set; }
        public string message { get; set; }
        public string waitPayNum { get; set; }
        public string waitSendNum { get; set; }
        public string waitRreceiveNum { get; set; }
        public string drawBackNum { get; set; }
        public string payEtm { get; set; }
        public string orderEtm { get; set; }
        public string memberId { get; set; }
        public string memberName { get; set; }
        public string creatorIp { get; set; }
        public string storeId { get; set; }
        public string storeName { get; set; }
        public string storeTel { get; set; }
        public string imgUrl { get; set; }
        public string goodsUrl { get; set; }
        public string productDesc { get; set; }
        public string allocationStatus { get; set; }
        public float orderAmount { get; set; }
        public float deliveryFee { get; set; }
        public long createDate { get; set; }
        public long modifyDate { get; set; }
        public string instId { get; set; }
        public string detialJsonText { get; set; }
        public string providerId { get; set; }
        public string orderDesc { get; set; }
        public string rateId { get; set; }
        public string orderItemVO { get; set; }
        public string millisecond { get; set; }
        public string fmtPaymentDate { get; set; }
        public string fmtCreateDate { get; set; }
        public string orderStatusName { get; set; }
        public string paymentTypeName { get; set; }
        public string orderDraftStatusName { get; set; }
        public string orderFinishStatusName { get; set; }
        public string orderFromName { get; set; }
        public string paymentStatusName { get; set; }
        public string orderTypeName { get; set; }
    }

    public class GetOrderResult_Detail
    {
        public string orderId { get; set; }
        public int isDelete { get; set; }
        public int isCredit { get; set; }
        public string orderStatus { get; set; }
        public string orderStatusEnum { get; set; }
        public string orderSubStatus { get; set; }
        public string orderDraftStatusEnum { get; set; }
        public string orderFinishStatusEnum { get; set; }
        public int orderFrom { get; set; }
        public string orderFromEnum { get; set; }
        public int orderType { get; set; }
        public string orderTypeEnum { get; set; }
        public int orderClassify { get; set; }
        public float totalAmount { get; set; }
        public string paymentStatus { get; set; }
        public string paymentStatusEnum { get; set; }
        public int paymentType { get; set; }
        public string paymentTypeEnum { get; set; }
        public string paymentOrderId { get; set; }
        public string paymentAccountId { get; set; }
        public string paymentBatchNo { get; set; }
        public string paymentDate { get; set; }
        public string message { get; set; }
        public string waitPayNum { get; set; }
        public string waitSendNum { get; set; }
        public string waitRreceiveNum { get; set; }
        public string drawBackNum { get; set; }
        public string payEtm { get; set; }
        public string orderEtm { get; set; }
        public string memberId { get; set; }
        public string memberName { get; set; }
        public string creatorIp { get; set; }
        public string storeId { get; set; }
        public string storeName { get; set; }
        public string storeTel { get; set; }
        public string imgUrl { get; set; }
        public string goodsUrl { get; set; }
        public string productDesc { get; set; }
        public string allocationStatus { get; set; }
        public float orderAmount { get; set; }
        public float deliveryFee { get; set; }
        public long createDate { get; set; }
        public long modifyDate { get; set; }
        public string instId { get; set; }
        public string detialJsonText { get; set; }
        public string providerId { get; set; }
        public string orderDesc { get; set; }
        public string rateId { get; set; }
        public string orderItemVO { get; set; }
        public GetOrderitemvo[] orderItemVOs { get; set; }
        public GetOrderdeliveryvo orderDeliveryVO { get; set; }
        public string mChargeOrderDetailVOs { get; set; }
        public string mFlowOrderDetailVOs { get; set; }
        public string trafficOrderDetailVOs { get; set; }
        public string transferOrderDetailVOs { get; set; }
        public string creditOrderDetailVOs { get; set; }
        public string oilOrderDetailVOs { get; set; }
        public string millisecond { get; set; }
        public string fmtPaymentDate { get; set; }
        public string fmtCreateDate { get; set; }
        public string orderStatusName { get; set; }
        public string paymentTypeName { get; set; }
        public string orderDraftStatusName { get; set; }
        public string orderFinishStatusName { get; set; }
        public string orderFromName { get; set; }
        public string paymentStatusName { get; set; }
        public string orderTypeName { get; set; }
    }

    public class GetOrderdeliveryvo
    {
        public string id { get; set; }
        public string orderId { get; set; }
        public string trueName { get; set; }
        public string locationPath { get; set; }
        public string address { get; set; }
        public string zipcode { get; set; }
        public string tel { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public int state { get; set; }
        public int isDefault { get; set; }
        public long createDate { get; set; }
    }

    public class GetOrderitemvo
    {
        public string orderItemId { get; set; }
        public string orderId { get; set; }
        public int idDelete { get; set; }
        public string goodsId { get; set; }
        public string goodsName { get; set; }
        public string productId { get; set; }
        public string productName { get; set; }
        public float productPrice { get; set; }
        public int productQuantity { get; set; }
        public string productSn { get; set; }
        public string goodsImagePath { get; set; }
        public string goodsUrl { get; set; }
        public long createDate { get; set; }
        public long modifyDate { get; set; }
        public string cartId { get; set; }
        public string cartFromType { get; set; }
        public string etProduct { get; set; }
        public string jdProduct { get; set; }
        public string fromType { get; set; }
        public string fromTypeEnum { get; set; }
        public string channType { get; set; }
        public string channTypeEnum { get; set; }
        public string skuText { get; set; }
        public string remark { get; set; }
    }

}
