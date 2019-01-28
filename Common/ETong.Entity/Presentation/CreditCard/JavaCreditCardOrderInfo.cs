using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Entity.Presentation.CreditCard
{

    public class JavaCreditCardOrderInfo
    {
        public Result_Detail result_detail { get; set; }
        public Result_VO result_VO { get; set; }
        public string memberId { get; set; }
    }

    public class Result_Detail
    {
        public string orderId { get; set; }
        public string isDelete { get; set; }
        public string isCredit { get; set; }
        public string orderStatus { get; set; }
        public string orderStatusEnum { get; set; }
        public string orderSubStatus { get; set; }
        public string orderDraftStatusEnum { get; set; }
        public string orderFinishStatusEnum { get; set; }
        public string orderFrom { get; set; }
        public string orderFromEnum { get; set; }
        public string orderType { get; set; }
        public string orderTypeEnum { get; set; }
        public string orderClassify { get; set; }
        public string totalAmount { get; set; }
        public string paymentStatus { get; set; }
        public string paymentStatusEnum { get; set; }
        public string paymentType { get; set; }
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
        public string orderAmount { get; set; }
        public string deliveryFee { get; set; }
        public string createDate { get; set; }
        public string modifyDate { get; set; }
        public string instId { get; set; }
        public string detialJsonText { get; set; }
        public string providerId { get; set; }
        public string orderDesc { get; set; }
        public string rateId { get; set; }
        public string orderFinishDate { get; set; }
        public string orderItemVO { get; set; }
        public string orderItemVOs { get; set; }
        public string orderDeliveryVO { get; set; }
        public string mChargeOrderDetailVOs { get; set; }
        public string mFlowOrderDetailVOs { get; set; }
        public string trafficOrderDetailVOs { get; set; }
        public string transferOrderDetailVOs { get; set; }
        public Creditorderdetailvo[] creditOrderDetailVOs { get; set; }
        public string oilOrderDetailVOs { get; set; }
        public string collectionDetailsVOs { get; set; }
        public string millisecond { get; set; }
        public string orderFinishDateText { get; set; }
        public string[] productDescFormat { get; set; }
        public string fmtPaymentDate { get; set; }
        public string fmtCreateDate { get; set; }
        public string orderDraftStatusName { get; set; }
        public string orderFinishStatusName { get; set; }
        public string paymentStatusName { get; set; }
        public string paymentTypeName { get; set; }
        public string orderFromName { get; set; }
        public string orderStatusName { get; set; }
        public string orderTypeName { get; set; }
    }

    public class Creditorderdetailvo
    {
        public string recId { get; set; }
        public string orderId { get; set; }
        public string createDate { get; set; }
        public string content { get; set; }
        public string issuer { get; set; }
        public string creditCardNumber { get; set; }
        public string phoneNumber { get; set; }
        public string debitCardNumber { get; set; }
        public string refrenceNumber { get; set; }
        public string payType { get; set; }
        public string terminalNumber { get; set; }
        public string creditCardAccount { get; set; }
        public string payBankName { get; set; }
        public string repaymentFee { get; set; }
        public string repaymentAmount { get; set; }
        public string customerName { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string bankBranch { get; set; }
        public string remark { get; set; }
    }

    public class Result_VO
    {
        public string orderId { get; set; }
        public string isDelete { get; set; }
        public string isCredit { get; set; }
        public string orderStatus { get; set; }
        public string orderStatusEnum { get; set; }
        public string orderSubStatus { get; set; }
        public string orderDraftStatusEnum { get; set; }
        public string orderFinishStatusEnum { get; set; }
        public string orderFrom { get; set; }
        public string orderFromEnum { get; set; }
        public string orderType { get; set; }
        public string orderTypeEnum { get; set; }
        public string orderClassify { get; set; }
        public string totalAmount { get; set; }
        public string paymentStatus { get; set; }
        public string paymentStatusEnum { get; set; }
        public string paymentType { get; set; }
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
        public string orderAmount { get; set; }
        public string deliveryFee { get; set; }
        public string createDate { get; set; }
        public string modifyDate { get; set; }
        public string instId { get; set; }
        public string detialJsonText { get; set; }
        public string providerId { get; set; }
        public string orderDesc { get; set; }
        public string rateId { get; set; }
        public string orderFinishDate { get; set; }
        public string orderItemVO { get; set; }
        public string millisecond { get; set; }
        public string orderFinishDateText { get; set; }
        public string[] productDescFormat { get; set; }
        public string fmtPaymentDate { get; set; }
        public string fmtCreateDate { get; set; }
        public string orderDraftStatusName { get; set; }
        public string orderFinishStatusName { get; set; }
        public string paymentStatusName { get; set; }
        public string paymentTypeName { get; set; }
        public string orderFromName { get; set; }
        public string orderStatusName { get; set; }
        public string orderTypeName { get; set; }
    }

}
