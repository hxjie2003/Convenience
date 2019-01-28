using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.Order.Core.Repository.Models
{
    /// <summary>
    /// 订单状态：
    /// 1=待付款
    /// 2=已支付待发货
    /// 3=审核处理(商城订单流程暂时没有审核，直接跳到已发货)
    /// 4=已发货
    /// 5=已完成
    /// 6=退款协议待商家确认
    /// 7=退款中
    /// 8=商家不同意退款
    /// 9=客服介入退款
    /// 10=退款退货协议待商家确认
    /// 11=商家同意退货退款
    /// 12=退货退款中
    /// 13=商家不同意退货退款
    /// 14=客服介入退货退款
    /// 99=订单关闭(订单作废)
    /// </summary>
    public enum OrderStatus
    {
        New =1,
        Payed=2, 
        Audit=3,
        Shipped=4,
        Finished=5,
        RefundReplying=6,
        Refunding=7,
        RefundRefused=8,
        RefundByPlatform=9,
        ReturnGoodsReplaying=10,
        ReturnGoodsAccept=11,
        RetunningGoods=12,
        ReturnGoodsRefused=13,
        ReturnGoodsByPlatform=14,
        Closed=99
    }
}
