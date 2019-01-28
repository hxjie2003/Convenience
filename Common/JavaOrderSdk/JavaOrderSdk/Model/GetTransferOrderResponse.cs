using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaOrderSdk.Model
{


    public class GetTransferOrderResponse
    {
        public string sign { get; set; }
        public string reqTime { get; set; }
        public TransferorderDatamap dataMap { get; set; }
        public string respCode { get; set; }
        public string respMsg { get; set; }
        public string respTime { get; set; }
    }

    public class TransferorderDatamap
    {
        public TransferorderResult_VO result_VO { get; set; }
        public TransferorderResult_Detail result_detail { get; set; }
        public string memberId { get; set; }
    }

    public class TransferorderResult_VO
    {
        public string orderId { get; set; }
        public int isDelete { get; set; }
        public int isCredit { get; set; }
        public int orderStatus { get; set; }
        public string orderStatusEnum { get; set; }
        public int orderSubStatus { get; set; }
        public string orderDraftStatusEnum { get; set; }
        public string orderFinishStatusEnum { get; set; }
        public int orderFrom { get; set; }
        public string orderFromEnum { get; set; }
        public int orderType { get; set; }
        public string orderTypeEnum { get; set; }
        public int orderClassify { get; set; }
        public float totalAmount { get; set; }
        public int paymentStatus { get; set; }
        public string paymentStatusEnum { get; set; }
        public int paymentType { get; set; }
        public string paymentTypeEnum { get; set; }
        public string paymentOrderId { get; set; }
        public string paymentAccountId { get; set; }
        public string paymentBatchNo { get; set; }
        public long paymentDate { get; set; }
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
        public float orderAmount { get; set; }
        public float deliveryFee { get; set; }
        public long createDate { get; set; }
        public long modifyDate { get; set; }
        public string instId { get; set; }
        public string detialJsonText { get; set; }
        public string providerId { get; set; }
        public string orderDesc { get; set; }
        public string orderItemVO { get; set; }
        public string fmtPaymentDate { get; set; }
        public string fmtCreateDate { get; set; }
        public string orderStatusName { get; set; }
        public string orderDraftStatusName { get; set; }
        public string orderFinishStatusName { get; set; }
        public string orderFromName { get; set; }
        public string orderTypeName { get; set; }
        public string paymentStatusName { get; set; }
        public string paymentTypeName { get; set; }
        public string millisecond { get; set; }
    }

    public class TransferorderResult_Detail
    {
        public string orderId { get; set; }
        public int isDelete { get; set; }
        public int isCredit { get; set; }
        public int orderStatus { get; set; }
        public string orderStatusEnum { get; set; }
        public int orderSubStatus { get; set; }
        public string orderDraftStatusEnum { get; set; }
        public string orderFinishStatusEnum { get; set; }
        public int orderFrom { get; set; }
        public string orderFromEnum { get; set; }
        public int orderType { get; set; }
        public string orderTypeEnum { get; set; }
        public int orderClassify { get; set; }
        public float totalAmount { get; set; }
        public int paymentStatus { get; set; }
        public string paymentStatusEnum { get; set; }
        public int paymentType { get; set; }
        public string paymentTypeEnum { get; set; }
        public string paymentOrderId { get; set; }
        public string paymentAccountId { get; set; }
        public string paymentBatchNo { get; set; }
        public long paymentDate { get; set; }
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
        public float orderAmount { get; set; }
        public float deliveryFee { get; set; }
        public long createDate { get; set; }
        public long modifyDate { get; set; }
        public string instId { get; set; }
        public string detialJsonText { get; set; }
        public string providerId { get; set; }
        public string orderDesc { get; set; }
        public string orderItemVO { get; set; }
        public string orderItemVOs { get; set; }
        public string orderDeliveryVO { get; set; }
        public string mChargeOrderDetailVOs { get; set; }
        public string mFlowOrderDetailVOs { get; set; }
        public string trafficOrderDetailVOs { get; set; }
        public Transferorderdetailvo[] transferOrderDetailVOs { get; set; }
        public string creditOrderDetailVOs { get; set; }
        public string fmtPaymentDate { get; set; }
        public string fmtCreateDate { get; set; }
        public string orderStatusName { get; set; }
        public string orderDraftStatusName { get; set; }
        public string orderFinishStatusName { get; set; }
        public string orderFromName { get; set; }
        public string orderTypeName { get; set; }
        public string paymentStatusName { get; set; }
        public string paymentTypeName { get; set; }
        public string millisecond { get; set; }
    }

    public class Transferorderdetailvo
    {
        public string recId { get; set; }
        public string orderId { get; set; }
        public int line { get; set; }
        public long createDate { get; set; }
        public string instId { get; set; }
        public string content { get; set; }
        public string transferInCardNo { get; set; }
        public float transferAmount { get; set; }
        public float transferFee { get; set; }
        public string contactPhone { get; set; }
        public string debitCardNo { get; set; }
        public string bankReference { get; set; }
        public string transferType { get; set; }
        public string terminalNo { get; set; }
        public string bankName { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string payeeName { get; set; }
        public string payeeMobile { get; set; }
    }

}
