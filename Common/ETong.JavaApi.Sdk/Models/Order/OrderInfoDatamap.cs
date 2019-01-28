using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.JavaApi.Sdk
{
    public class OrderInfoDatamap
    {
        public OrderInfo result_VO { get; set; }
        public DetailInfo result_detail { get; set; }
    }

    public class OrderInfo
    {
        public string orderId { get; set; }
        public int isDelete { get; set; }
        public int isCredit { get; set; }
        public int orderStatus { get; set; }
        public string orderStatusEnum { get; set; }
        public string orderSubStatus { get; set; }
        public string orderDraftStatusEnum { get; set; }
        public string orderFinishStatusEnum { get; set; }
        public int orderFrom { get; set; }
        public string orderFromEnum { get; set; }
        public int orderType { get; set; }
        public string orderTypeEnum { get; set; }
        public int orderClassify { get; set; }
        public string orderClassifyEnum { get; set; }
        public float totalAmount { get; set; }
        public int paymentStatus { get; set; }
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
        public int allocationStatus { get; set; }
        public string allocationStatusEnum { get; set; }
        public float orderAmount { get; set; }
        public float deliveryFee { get; set; }
        public long createDate { get; set; }
        public long modifyDate { get; set; }
        public string instId { get; set; }
        public string detialJsonText { get; set; }
        public string orderProperties { get; set; }
        public string providerId { get; set; }
        public string orderDesc { get; set; }
        public string rateId { get; set; }
        public string orderFinishDate { get; set; }
        public OrderItemVO orderItemVO { get; set; }
        public string freightTemplateId { get; set; }
        public string freightTypeId { get; set; }
        public string freightTypeName { get; set; }
        public OrderItemVO[] orderItemVOs { get; set; }
        public OrderDeliveryVO orderDeliveryVO { get; set; }
        public object[] mChargeOrderDetailVOs { get; set; }
        public object[] mFlowOrderDetailVOs { get; set; }
        public object[] trafficOrderDetailVOs { get; set; }
        public object[] transferOrderDetailVOs { get; set; }
        public object[] creditOrderDetailVOs { get; set; }
        public object[] oilOrderDetailVOs { get; set; }
        public object[] collectionDetailsVOs { get; set; }
        public MovieDetailVO[] movieDetailsVOs { get; set; }
        public string millisecond { get; set; }
        public string[] productDescFormat { get; set; }
        public string fmtPaymentDate { get; set; }
        public string fmtCreateDate { get; set; }
        public string orderStatusName { get; set; }
        public string orderDraftStatusName { get; set; }
        public string orderFinishStatusName { get; set; }
        public string orderFromName { get; set; }
        public string orderTypeName { get; set; }
        public string paymentStatusName { get; set; }
        public string paymentTypeName { get; set; }
        public string orderFinishDateText { get; set; }
    }

    public class DetailInfo
    {
        public string orderId { get; set; }
        public int isDelete { get; set; }
        public int isCredit { get; set; }
        public int orderStatus { get; set; }
        public string orderStatusEnum { get; set; }
        public string orderSubStatus { get; set; }
        public string orderDraftStatusEnum { get; set; }
        public string orderFinishStatusEnum { get; set; }
        public int orderFrom { get; set; }
        public string orderFromEnum { get; set; }
        public int orderType { get; set; }
        public string orderTypeEnum { get; set; }
        public int orderClassify { get; set; }
        public string orderClassifyEnum { get; set; }
        public float totalAmount { get; set; }
        public int paymentStatus { get; set; }
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
        public int allocationStatus { get; set; }
        public string allocationStatusEnum { get; set; }
        public float orderAmount { get; set; }
        public float deliveryFee { get; set; }
        public long createDate { get; set; }
        public long modifyDate { get; set; }
        public string instId { get; set; }
        public string detialJsonText { get; set; }
        public string orderProperties { get; set; }
        public string providerId { get; set; }
        public string orderDesc { get; set; }
        public string rateId { get; set; }
        public string orderFinishDate { get; set; }
        public OrderItemVO orderItemVO { get; set; }
        public string freightTemplateId { get; set; }
        public string freightTypeId { get; set; }
        public string freightTypeName { get; set; }
        public OrderItemVO[] orderItemVOs { get; set; }
        public OrderDeliveryVO orderDeliveryVO { get; set; }
        public object[] mChargeOrderDetailVOs { get; set; }
        public object[] mFlowOrderDetailVOs { get; set; }
        public object[] trafficOrderDetailVOs { get; set; }
        public object[] transferOrderDetailVOs { get; set; }
        public object[] creditOrderDetailVOs { get; set; }
        public object[] oilOrderDetailVOs { get; set; }
        public object[] collectionDetailsVOs { get; set; }
        public MovieDetailVO[] movieDetailsVOs { get; set; }
        public string millisecond { get; set; }
        public string[] productDescFormat { get; set; }
        public string fmtPaymentDate { get; set; }
        public string fmtCreateDate { get; set; }
        public string orderStatusName { get; set; }
        public string orderDraftStatusName { get; set; }
        public string orderFinishStatusName { get; set; }
        public string orderFromName { get; set; }
        public string orderTypeName { get; set; }
        public string paymentStatusName { get; set; }
        public string paymentTypeName { get; set; }
        public string orderFinishDateText { get; set; }
    }

    public class OrderDeliveryVO
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

    public class OrderItemVO
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

    public class MovieDetailVO
    {
        public string recId { get; set; }
        public string orderId { get; set; }
        public string movieDimension { get; set; }
        public string movieLanguage { get; set; }
        public string movieRunningTime { get; set; }
        public string ticketType { get; set; }
        public string ticketId { get; set; }
        public string linkTel { get; set; }
        public string thirdOrderId { get; set; }
        public string orderDescription { get; set; }
        public string ticketCode { get; set; }
        public string updateTime { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public long createDate { get; set; }
        public string memberId { get; set; }
        public string memberName { get; set; }
        public string exchangeType { get; set; }
        public string exchangeCredentials { get; set; }
        public string exchangeMobile { get; set; }
        public string acceptAddress { get; set; }
        public string acceptEmail { get; set; }
        public string movieId { get; set; }
        public string movieName { get; set; }
        public string showDate { get; set; }//long
        public string showNumber { get; set; }
        public string cinemaId { get; set; }
        public string cinemaName { get; set; }
        public string cinemaHallId { get; set; }
        public string cinemaHallName { get; set; }
        public string showStartTime { get; set; }
        public string showEndTime { get; set; }
        public int ticketQty { get; set; }
        public float ticketPay { get; set; }
        public float proxyPay { get; set; }
        public float orderTotal { get; set; }
        public string ticketSeats { get; set; }
        public string movieExplantion { get; set; }
        public string exchangPassword { get; set; }
        public string warnExplantion { get; set; }
        public string invalidState { get; set; }
        public long bookTime { get; set; }
        public string cancelState { get; set; }
        public string cancelType { get; set; }
        public string cancelExplantion { get; set; }
        public string proxyState { get; set; }//int
        public string apiThirdOrderId { get; set; }
        public string apiMark { get; set; }//int
        public string ticketPrice { get; set; }
    }

}
