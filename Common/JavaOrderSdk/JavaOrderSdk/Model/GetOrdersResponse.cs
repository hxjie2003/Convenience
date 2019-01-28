using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaOrderSdk.Model
{


    public class GetOrdersResponse
    {
        public string sign { get; set; }
        public string reqTime { get; set; }
        public GetOrdersDatamap dataMap { get; set; }
        public string respCode { get; set; }
        public string respMsg { get; set; }
        public string respTime { get; set; }
    }

    public class GetOrdersDatamap
    {
        public GetOrdersResult_List[] result_list { get; set; }
        public GetOrdersResult_Page result_page { get; set; }
        public string memberId { get; set; }
    }

    public class GetOrdersResult_Page
    {
        public int pageSize { get; set; }
        public int curPage { get; set; }
        public int itemNum { get; set; }
        public bool prePage { get; set; }
        public bool nextPage { get; set; }
        public int totalPage { get; set; }
        public int startRow { get; set; }
        public int endRow { get; set; }
    }

    public class GetOrdersResult_List
    {
        public string orderId { get; set; }
        public int isDelete { get; set; }
        public int isCredit { get; set; }
        public string orderStatus { get; set; }
        public string orderStatusEnum { get; set; }

        public string productDesc { get; set; }
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
        public string allocationStatus { get; set; }
        public float orderAmount { get; set; }
        public float deliveryFee { get; set; }
        public long createDate { get; set; }
        public long modifyDate { get; set; }
        public string instId { get; set; }
        public string detialJsonText { get; set; }
        public string providerId { get; set; }
        public GetOrdersOrderitemvo[] orderItemVO { get; set; }
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

    public class GetOrdersOrderitemvo
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
        public int? fromType { get; set; }
        public string fromTypeEnum { get; set; }
        public int? channType { get; set; }
        public string channTypeEnum { get; set; }
        public string skuText { get; set; }
        public string remark { get; set; }
    }


}
