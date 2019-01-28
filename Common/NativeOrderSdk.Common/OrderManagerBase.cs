using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NativeOrderSdk.Common.Exceptions;
using NativeOrderSdk.Common.Utilities;
using NativeOrderSdk.Common.EntityModels;
using JavaOrderSdk;
using JavaOrderSdk.Model;
using System.Data.Entity.Validation;
using System.Text;

namespace NativeOrderSdk.Common
{
    /// <summary>
    /// 订单逻辑基类.
    /// </summary>
    /// <typeparam name="Context">EF生成的DbContext</typeparam>
    /// <typeparam name="CustomerOrderExtend">自定义的订单扩展字段，与PUB_ORDERS_EXTENDED表映射</typeparam>
    /// <typeparam name="CustomerOrderDetail">自定义的订单明细，与自定义表映射</typeparam>  
    /// <typeparam name="PUB_ORDERS_COMMON">EF生成的PUB_ORDERS_GROUP</typeparam>
    /// <typeparam name="PUB_ORDERS_COMMON">EF生成的PUB_ORDERS_COMMON</typeparam>
    /// <typeparam name="PUB_ORDERS_EXTENDED">EF生成的PUB_ORDERS_EXTENDED</typeparam>

    public abstract class OrderManagerBase<Context, OrderItem, OrderItemQuery>
        where Context : DbContext, new()
        where OrderItem : OrderItemInfo, new()
        where OrderItemQuery : OrderItemDetail, new()
    {
        #region 字段属性
        private Context _dbContext;
        /// <summary>
        /// 实体框架
        /// </summary>
        public Context DbContext
        {
            get { return _dbContext; }
        }

        public OrderManagerBase()
        {
            this._dbContext = new Context();
        }
        //public OrderManagerBase(Context context)
        //{
        //    _dbContext = context;
        //}
        #endregion

        #region 创建订单

        /// <summary>
        /// 创建店铺订单。
        /// </summary>
        /// <param name="orderitems">订单明细项。</param>
        /// <returns>订单结果。</returns>
        private OrderGroupResult CreateStoreOrder(List<OrderItem> orderitems)
        {
            if (orderitems.Count == 0)
                throw new Exception("不存在订单明细项（订单项为0），无法创建订单");
            var storeId = orderitems.Select(o => this.GetStoreInfo(o).StoreId).Distinct();
            if (storeId.Count() > 1)
                throw new Exception("所选的商品列表存在不同的商家，不充许创建订单！");
            PUB_ORDERS_GROUP groupentity = this.CreateOrderGroup(orderitems);
            dynamic groupdynamic = groupentity;
            //创建返回结果
            OrderGroupResult result = new OrderGroupResult();
            result.Items = new List<OrderItemResult>();
            dynamic dbcontext = this.DbContext;
            dbcontext.PUB_ORDERS_GROUP.Add(groupentity);
            foreach (var orderitem in orderitems)
            {
                PUB_ORDERS_COMMON commonentity = this.CreateOrderCommon(orderitem, groupdynamic);
                PUB_ORDERS_EXTENDED extendentity = this.CreateOrderItemExtendedEntity(orderitem, commonentity);
                this.AddEntitiesToContext(commonentity, extendentity);
                this.CreateAndAddOrderItemMoreDetail(orderitem, commonentity);
                dynamic commonentitydynamic = commonentity;
                OrderItemResult itemresult = new OrderItemResult();
                itemresult.OrderId = commonentitydynamic.ORDER_ID;
                itemresult.ItemName = commonentitydynamic.PRODUCT_NAME;
                itemresult.Amount = commonentitydynamic.TOTAL_AMOUNT;
                itemresult.Price = commonentitydynamic.PRODUCT_PRICE;
                itemresult.Qty = commonentitydynamic.PRODUCT_QUANTITY;
                itemresult.StoreId = commonentitydynamic.STORE_ID;
                itemresult.StoreName = commonentitydynamic.STORE_NAME;
                result.Items.Add(itemresult);
            }

            result.GroupId = groupdynamic.ORDER_GROUP_ID;
            result.TotalAmount = groupdynamic.TOTAL_AMOUNT;
            return result;

        }

        /// <summary>
        /// 创建本地订单，并保存数据库。（包含扩展表,公共订单表，自定义表。）
        /// </summary>
        /// <param name="orderitems">订单明细列表</param>
        /// <returns>订单创建结果。（包含组ID及订单明细ID等简要信息）</returns>
        public List<OrderGroupResult> CreateOrder(List<OrderItem> orderitems)
        {
            var stores = orderitems.Select(o => this.GetStoreInfo(o).StoreId).Distinct();
            List<OrderGroupResult> groups = new List<OrderGroupResult>();
            foreach (var store in stores)
            {
                var items = orderitems.Where(o => this.GetStoreInfo(o).StoreId == store).ToList();
                var group = this.CreateStoreOrder(items);
                groups.Add(group);
            }
            try
            {
                this.DbContext.SaveChanges();
            }
            catch (DbEntityValidationException excption)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(excption.Message);
                foreach (var c in excption.EntityValidationErrors)
                {
                    foreach (var m in c.ValidationErrors)
                    {
                        builder.Append(m.PropertyName);
                        builder.Append(":");
                        builder.Append(m.ErrorMessage);
                    }
                }
                throw new Exception(builder.ToString());
            }
            return groups;
        }

        /// <summary>
        /// 创建本地订单，并保存数据库。（包含扩展表,公共订单表，自定义表。）
        /// </summary>
        /// <param name="orderitem">单个订单明细</param>
        /// <returns>订单创建结果。（包含组ID及订单明细ID等简要信息）</returns>
        public OrderGroupResult CreateOrder(OrderItem orderitem)
        {
            List<OrderItem> items = new List<OrderItem>();
            items.Add(orderitem);
            return this.CreateOrder(items).FirstOrDefault();
        }

        /// <summary>
        /// 创建订单组
        /// </summary>
        /// <param name="orders">订单明细项</param>
        /// <returns>订单组实体</returns>
        private PUB_ORDERS_GROUP CreateOrderGroup(List<OrderItem> orders)
        {
            var orderItem = orders[0];
            string orergroupid = null;
            var s = new OrderManager();
            var result = s.CreateOrder(new OrderInfo
            {
                //orderId = orderItemResult.OrderId,
                memberId =
                    orderItem.MemberId == "etong_common_user"
                        ? null
                        : orderItem.MemberId,
                memberName =
                    orderItem.MemberName == "etong_anonymous"
                        ? null
                        : orderItem.MemberName,
                message = "",
                orderAmount = orderItem.TotalAmount.ToString(),
                orderDescribe = GenerateProductDescription(orderItem),
                orderFrom = orderItem.OrderFrom.ToString(),
                orderType = OrderType.ToString(),
                storeId = this.GetStoreInfo(orderItem).StoreId,
                storeName = this.GetStoreInfo(orderItem).StoreName,
                totalAmount = (orders.Sum(f => f.TotalAmount)).ToString(),
                orderEtm = orderItem.OrderETMID
            });

            orergroupid = result.dataMap.orderId;
            var order = orders.FirstOrDefault();
            dynamic group = new PUB_ORDERS_GROUP();
            group.ORDER_GROUP_ID = orergroupid;
            group.IS_CREDIT = 0;
            group.ORDER_TYPE = short.Parse(this.OrderType.ToString());
            group.TOTAL_ORDERS = orders.Count;
            group.TOTAL_AMOUNT = orders.Sum(o => o.TotalAmount);
            if (order != null)
            {
                @group.MEMBER_ID = order.MemberId;
                @group = AttachOrderInfo(@group, order);
            }
            group.ORDER_DATE = DateTime.Now;
            return group;
        }

        /// <summary>
        /// 附加信息.(为订单组补充信息，可重载。)
        /// </summary>
        /// <param name="groupentity"></param>
        /// <param name="orderitem"></param>
        /// <returns></returns>
        private PUB_ORDERS_GROUP AttachOrderInfo(dynamic groupentity, OrderItem orderitem)
        {
            var store = this.GetStoreInfo(orderitem);
            groupentity.STORE_ID = store.StoreId;
            groupentity.STORE_NAME = store.StoreName;
            return groupentity;
        }

        /// <summary>
        /// 必须重载的订单类型
        /// </summary>
        public abstract int OrderType
        { get; }

        /// <summary>
        /// 订单分类：一般订单=0，组合套餐=1，团购=2，促销=3
        /// </summary>
        /// <param name="item">订单明细</param>
        /// <returns></returns>
        protected virtual int GetOrderClassify(OrderItem item)
        {
            return 0;
        }

        protected abstract OrderProductInfo GetProductInfo(OrderItem item);

        protected abstract string GenerateProductDescription(OrderItem item);

        protected abstract OrderStoreInfo GetStoreInfo(OrderItem item);

        protected abstract OrderDeliveryInfo GetDeliveryInfo(OrderItem item);

        /// <summary>
        /// 创建公共订单部分
        /// </summary>
        /// <param name="order">公共订单信息</param>
        /// <returns></returns>
        private PUB_ORDERS_COMMON CreateOrderCommon(OrderItem orderitem, dynamic groupDB)
        {
            dynamic commonorder = new PUB_ORDERS_COMMON();
            commonorder.ORDER_ID = OrderCodeGen.GetOrderId();
            commonorder.ORDER_GROUP_ID = groupDB.ORDER_GROUP_ID;
            commonorder.IS_DELETE = (Int16)0; //是否删除：未删除：0,已删除：1
            commonorder.IS_CREDIT = (Int16)groupDB.IS_CREDIT; //订单类别: 0:原生订单；1:信用订单
            commonorder.ORDER_STATUS = (Int16)0;//订单状态：待处理=0,已通过审核=1 ,未通过审核=20,等待备货=4,等待买家确认收货=5 ,交易关闭=10（系统自动），客户作废=11,客户拒收=12,异常订单=13, 无人签收=3, 客户拒收=12, 已签收=2, 已完成=9, 订单作废=18, 处理中=19
            commonorder.SHIPPING_STATUS = (Int16)0;//发货状态：未发货=0，部分发货=1，已发货=2
            // commonorder.REFUND_MONEY_STATUS = "";//仅退款状态：退款协议等待商家确认=0,商家不同意协议=1, 商家同意退款=2,商家同意部分退款=3,客服介入=6,退款关闭=7,退款成功=8,商家准备退款=9, 买家同意取消退款申请=10
            // commonorder.REFUND_GOODSMONEY_STATUS = "";//退货退款状态：退货退款协议等待商家确认=0、商家不同意协议=1、等待买家退货=2、买家已发货等待商家确认=3、商家确认收货拒绝退款=4、商家确认收货准备退款=5、客服介入=6、退货退款关闭=7、退款成功=8、商家准备退款=9、等待买家发货=10、买家同意取消退款退货=11
            // commonorder.REFUND_CHANGGOODS_STATUS = "";//换货状态：换货协议等待商家确认=0、商家不同意协议=1、换货处理中=2、客服介入=6、换货关闭=7、换货成功=8、买家同意取消换货=9、等待买家发货=10、换货处理中=11
            // commonorder.REFUND_REPAIR_STATUS = "";//维修状态：维修协议等待商家确认=0、商家不同意协议=1、维修处理中=2、客服介入=6、维修关闭=7、维修成功=8、买家同意取消返修＝9、等待买家发货＝10
            // commonorder.TRANSFOR_STATUS = "";//分配状态：待转发=0；已转发=1；驳回=2；回收=3

            commonorder.ORDER_FROM = (Int16)orderitem.OrderFrom;//订单来源：商城=0，ETM=1，进销存=2，B2C=3，APP=4
            commonorder.ORDER_TYPE = (Int16)this.OrderType;//订单类型：商城订单=0，彩票订单=1，机票订单=2，报刊订单=3，充值订单=4，火车票订单=5，交通违章订单=6，景点门票订单=7，旅游酒店订单=8，汽车票订单=9，就医助手订单=10，幸运大转盘＝11，酒店预订＝12，东莞通＝13，信用卡＝14，银行转账＝15，水费订单＝16 ,电费订单＝17，煤气费订单＝18，流量充值＝19，电影票订单＝20
            commonorder.ORDER_CLASSIFY = (Int16)this.GetOrderClassify(orderitem);

            #region 设置产品信息
            var productinfo = this.GetProductInfo(orderitem);
            if (productinfo == null)
                throw new Exception("产品信息为空，无法创建订单！");
            commonorder.ITEM_TYPE = (Int16)productinfo.ItemType;//实体商品标志：实体商品=1，虚拟商品=0
            // commonorder.OPERATE_STATUS = "";//操作状态：用与虚拟订单类的扩展
            commonorder.PRODUCT_ID = productinfo.ProductID;//货品ID
            if (string.IsNullOrWhiteSpace(productinfo.ProductName))
                throw new Exception("订单的货品ProductName名称不能为空！");
            commonorder.PRODUCT_NAME = productinfo.ProductName;//货品名称
            commonorder.PRODUCT_PRICE = productinfo.ProductPrice;//货品价格           
            commonorder.GOODS_ID = productinfo.GoodsID;//商品ID
            if (string.IsNullOrWhiteSpace(productinfo.GoodsName))
                throw new Exception("订单的商品GoodsName名称不能为空！");
            commonorder.GOODS_NAME = productinfo.GoodsName; ;//商品名称
            commonorder.GOODSCATEGORYSET_ID = productinfo.GoodsCategroySetID;//商品类目ID
            commonorder.BRAND_NAME = productinfo.BrandName;//品牌名称
            commonorder.IMGURL = productinfo.ImgUrl;//商品图片URl
            commonorder.PRODUCT_DESCRIPTION = this.GenerateProductDescription(orderitem);//商品规格描述
            #endregion
            if (orderitem.Quantity == 0)
                throw new Exception("不能添加数量为零的订单项！");
            commonorder.PRODUCT_QUANTITY = orderitem.Quantity;//货品总数
            commonorder.TOTAL_AMOUNT = orderitem.TotalAmount;//订单金额
            commonorder.PAYMENT_STATUS = (Int16)0;//支付状态：未支付=0，部分支付=1，已支付=2，部分退款=3，全额退款=4，联合支付=5，无需支付=6
            // commonorder.PAYMENT_DATE = "";//支付时间
            commonorder.ORDER_ETM = orderitem.OrderETMID;//下订单时ETM机编号
            // commonorder.PAY_ETM = "";//订单支付时ETM机编号
            commonorder.MEMBER_ID = orderitem.MemberId;//订单购买会员ID
            commonorder.CREATOR = orderitem.MemberName;//下单会员名称
            commonorder.CREATOR_IP = orderitem.CreateIP;//下单会员IP地址
            commonorder.CREATE_DATE = groupDB.ORDER_DATE;//创建时间
            commonorder.MODIFY_DATE = groupDB.ORDER_DATE;//修改时间

            var storeinfo = this.GetStoreInfo(orderitem);
            if (string.IsNullOrWhiteSpace(storeinfo.StoreId))
                throw new Exception("商家编号不能为空。");
            commonorder.STORE_ID = storeinfo.StoreId;//商家ID
            commonorder.STORE_NAME = storeinfo.StoreName;//商家名称
            // commonorder.DELIVERY_SN = "";//物流编号
            // commonorder.DELIVERY_NAME = "";//物流名称

            var deliveryInfo = this.GetDeliveryInfo(orderitem);
            if (deliveryInfo != null)
            {
                commonorder.SHIP_PROVINCES = deliveryInfo.ShipProvince;//收货省
                commonorder.SHIP_CITY = deliveryInfo.ShipCity;//收货市
                commonorder.SHIP_REGION = deliveryInfo.ShipRegion;//收货区
                commonorder.SHIP_ADDR = deliveryInfo.ShipAddress;//收货详细地址
                //commonorder.VERIFY_DELIVERY_DATE = "";//订单确认完成时间          
                commonorder.DELIVERYTYPE_ID = deliveryInfo.DeliveryTypeId;//配送方式ID
                commonorder.DELIVERYTYPENAME = deliveryInfo.DeliveryTypeName;//配送方式名称
            }
            //commonorder.ISCOMMENTED = "";//该订单是否已评价（-1：订单交易完成但没评价 0：买家已评价 1：双方已评价  -8:无）            
            commonorder.TOTAL_COST = 0;//订单总成本，默认值为0
            commonorder.ALLOCATION_STATUS = (Int16)0;//分润标志，0：未分，1：待分，2：已分           
            return commonorder;
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="order">订单信息</param>
        /// <param name="extend"></param>
        /// <returns></returns>

        /// <summary>
        /// 创建1对1表的扩展部份。（如无用到此函数可不需重载。）
        /// </summary>
        /// <param name="extend">订单扩展信息</param>
        /// <param name="puborderscommon">订单公共信息实体</param>
        /// <returns>订单扩展实体</returns>
        protected virtual PUB_ORDERS_EXTENDED CreateOrderItemExtendedEntity(OrderItem item, PUB_ORDERS_COMMON orderitemcommon)
        {
            PUB_ORDERS_EXTENDED extenddb = default(PUB_ORDERS_EXTENDED);
            if (item != null)
            {
                dynamic extenddynamic = new PUB_ORDERS_EXTENDED();
                dynamic ordercommon = orderitemcommon;
                extenddynamic.ORDER_ID = ordercommon.ORDER_ID;
                extenddynamic.ORDER_TYPE = (Int16)ordercommon.ORDER_TYPE;
                extenddynamic.CREATE_DATE = ordercommon.CREATE_DATE;
                extenddb = extenddynamic;
            }
            return extenddb;

        }


        /// <summary>
        /// 将产生的实体添加到实体上下文。
        /// </summary>    
        /// <param name="common">公共订单实体</param>
        /// <param name="extended">扩展订单实体</param>
        private void AddEntitiesToContext(PUB_ORDERS_COMMON common, PUB_ORDERS_EXTENDED extended)
        {
            dynamic context = this.DbContext;
            if (common == null)
                throw new Exception("PUB_ORDERS_COMMON是null值，未能创建订单！");
            context.PUB_ORDERS_COMMON.Add(common);
            if (extended != null)
                context.PUB_ORDERS_EXTENDED.Add(extended);
        }


        /// <summary>
        /// 在使用到PUB_ORDERS_COMMON表及PUB_ORDERS_EXTENDED表以外的自定表时使用。
        /// 需要手动创建实体，并添加到Context中。
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="commonentity"></param>
        protected abstract void CreateAndAddOrderItemMoreDetail(OrderItem item, PUB_ORDERS_COMMON orderItemComEntity);


        #endregion

        #region 订单查询

        #region Public方法
        /// <summary>
        /// 根据订单组ID查询订单项
        /// </summary>
        /// <param name="groupId">订单组ID</param>
        /// <returns>订单明细列表</returns>
        public List<OrderItemQuery> GetOrderItems(string groupId)
        {
            var list = this.GetOrderCommonEntityList(groupId);
            List<OrderItemQuery> orderlist = new List<OrderItemQuery>();
            foreach (var c in list)
            {
                dynamic ordercomon = c;
                var item = this.QueryOrderItem(c);
                item = this.QueryOrderItemMore(item, c);
                orderlist.Add(item);
            }
            return orderlist;
        }

        public OrderItemQuery GetOrderItem(string orderid)
        {
            OrderItem item = new OrderItem();
            var queryitem = this.GetOrderCommon(orderid);
            return queryitem;
        }


        /// <summary>
        /// 根据订单ID获取订公共订单信息。
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public OrderItemQuery GetOrderCommon(string orderid)
        {
            OrderItemQuery ordercommon = null;
            var common = this.GetOrderItemCommonEntity(orderid);
            ordercommon = this.QueryOrderItem(common);
            return ordercommon;
        }


        #endregion

        #region protected方法


        /// <summary>
        /// 通过订单号获得扩展订单实体。
        /// </summary>
        /// <param name="orderid">订单号</param>
        /// <returns>扩展订单实体</returns>
        protected virtual PUB_ORDERS_EXTENDED GetOrderItemExtendedEntity(string orderid)
        {
            return null;
        }

        /// <summary>
        /// 根据公共订单实体转换公共订单信息。
        /// </summary>
        /// <param name="orderCommonentity">公共订单实体</param>
        /// <returns>公共订单信息</returns>
        protected OrderItemQuery QueryOrderItem(PUB_ORDERS_COMMON orderCommonentity)
        {
            dynamic commonentitydynamic = orderCommonentity;
            OrderItemQuery itemInfo = null;
            if (orderCommonentity != null)
            {
                itemInfo = new OrderItemQuery();
                itemInfo.OrderId = commonentitydynamic.ORDER_ID;
                if (commonentitydynamic.IS_DELETE != null)
                {
                    itemInfo.IsDelete = (Int16)commonentitydynamic.IS_DELETE;
                }
                if (commonentitydynamic.IS_CREDIT != null)
                {
                    itemInfo.IsCredit = commonentitydynamic.IS_CREDIT;
                }
                if (commonentitydynamic.ORDER_STATUS != null)
                {
                    itemInfo.OrderStatus = (Int16)commonentitydynamic.ORDER_STATUS;
                }
                if (commonentitydynamic.SHIPPING_STATUS != null)
                {
                    itemInfo.ShippingStatus = (Int16)commonentitydynamic.SHIPPING_STATUS;
                }

                // commonorder.REFUND_MONEY_STATUS = "";//仅退款状态：退款协议等待商家确认=0,商家不同意协议=1, 商家同意退款=2,商家同意部分退款=3,客服介入=6,退款关闭=7,退款成功=8,商家准备退款=9, 买家同意取消退款申请=10
                // commonorder.REFUND_GOODSMONEY_STATUS = "";//退货退款状态：退货退款协议等待商家确认=0、商家不同意协议=1、等待买家退货=2、买家已发货等待商家确认=3、商家确认收货拒绝退款=4、商家确认收货准备退款=5、客服介入=6、退货退款关闭=7、退款成功=8、商家准备退款=9、等待买家发货=10、买家同意取消退款退货=11
                // commonorder.REFUND_CHANGGOODS_STATUS = "";//换货状态：换货协议等待商家确认=0、商家不同意协议=1、换货处理中=2、客服介入=6、换货关闭=7、换货成功=8、买家同意取消换货=9、等待买家发货=10、换货处理中=11
                // commonorder.REFUND_REPAIR_STATUS = "";//维修状态：维修协议等待商家确认=0、商家不同意协议=1、维修处理中=2、客服介入=6、维修关闭=7、维修成功=8、买家同意取消返修＝9、等待买家发货＝10
                // commonorder.TRANSFOR_STATUS = "";//分配状态：待转发=0；已转发=1；驳回=2；回收=3
                if (commonentitydynamic.ORDER_FROM != null)
                {
                    itemInfo.OrderFrom = (Int16)commonentitydynamic.ORDER_FROM;
                }

                //订单类型：商城订单=0，彩票订单=1，机票订单=2，报刊订单=3，充值订单=4，火车票订单=5，交通违章订单=6，景点门票订单=7，旅游酒店订单=8，汽车票订单=9，就医助手订单=10，幸运大转盘＝11，酒店预订＝12，东莞通＝13，信用卡＝14，银行转账＝15，水费订单＝16 ,电费订单＝17，煤气费订单＝18，流量充值＝19，电影票订单＝20
                if (commonentitydynamic.ORDER_TYPE != null)
                {
                    itemInfo.OrderType = (Int16)commonentitydynamic.ORDER_TYPE;
                }




                #region 设置产品信息

                string product_Name = "";
                int item_Type = 0;
                decimal product_Price = 0;

                if (!string.IsNullOrEmpty(commonentitydynamic.PRODUCT_NAME))
                {
                    product_Name = commonentitydynamic.PRODUCT_NAME;
                }
                if (commonentitydynamic.ITEM_TYPE != null)
                {
                    item_Type = (Int16)commonentitydynamic.ITEM_TYPE;
                }
                if (commonentitydynamic.PRODUCT_PRICE != null)
                {
                    product_Price = commonentitydynamic.PRODUCT_PRICE;
                }

                itemInfo.ItemDescription = commonentitydynamic.PRODUCT_DESCRIPTION;

                #endregion

                if (commonentitydynamic.PRODUCT_QUANTITY != null)
                {
                    itemInfo.Quantity = commonentitydynamic.PRODUCT_QUANTITY;
                }
                if (commonentitydynamic.TOTAL_AMOUNT != null)
                {
                    itemInfo.TotalAmount = commonentitydynamic.TOTAL_AMOUNT;
                }
                if (commonentitydynamic.PAYMENT_STATUS != null)
                {
                    itemInfo.PaymentStatus = (Int16)commonentitydynamic.PAYMENT_STATUS;
                }
                itemInfo.PaymentTime = commonentitydynamic.PAYMENT_DATE;//支付时间
                itemInfo.OrderETMID = commonentitydynamic.ORDER_ETM;
                itemInfo.PayETM = commonentitydynamic.PAY_ETM;//订单支付时ETM机编号
                itemInfo.MemberId = commonentitydynamic.MEMBER_ID;
                itemInfo.MemberName = commonentitydynamic.CREATOR;
                itemInfo.CreateIP = commonentitydynamic.CREATOR_IP;
                if (commonentitydynamic.CREATE_DATE != null)
                {
                    itemInfo.OrderDate = commonentitydynamic.CREATE_DATE;
                }

                //commonentitydynamic.MODIFY_DATE = groupDB.ORDER_DATE;//修改时间

                itemInfo.TotalCost = commonentitydynamic.TOTAL_COST = 0;//订单总成本，默认值为0
                itemInfo.AllocationStatus = commonentitydynamic.ALLOCATION_STATUS = 0;//分润标志，0：未分，1：待分，2：已分           
            }
            return itemInfo;
        }

        protected abstract OrderItemQuery QueryOrderItemMore(OrderItemQuery item, PUB_ORDERS_COMMON orderCommonentity);


        /// <summary>
        /// 根据订单组ID获取公共订单实体类。（可在重载中使用Include方法将PUB_ORDERS_EXTENDED包含）
        /// </summary>
        /// <param name="groupid">组ID</param>
        /// <returns>公共订单实体列表</returns>
        protected abstract List<PUB_ORDERS_COMMON> GetOrderCommonEntityList(string groupid);

        /// <summary>
        /// 通过订单ID查找公共订单实体PUB_ORDERS_COMMON。
        /// </summary>
        /// <param name="orderid">订单号</param>
        /// <returns>PUB_ORDERS_COMMON实体</returns>
        protected abstract PUB_ORDERS_COMMON GetOrderItemCommonEntity(string orderid);

        #endregion
        #endregion

        #region 修改订单状态

        /// <summary>
        /// 设置发货状态或第三方发货成功状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <exception cref="OrderSdkException">OrderId can not be found by orderId</exception>
        public virtual void SetStandardShipStatus(string orderId, bool shipstatus)
        {
            dynamic order = this.GetOrderItemCommonEntity(orderId);

            if (order == null)
                throw new OrderSdkException("401", orderId + "获取数据库订单记录失败!");

            if (shipstatus)
            {
                order.SHIPPING_STATUS = (Int16)2;//发货状态：未发货=0，部分发货=1，已发货=2
                order.ORDER_STATUS = (Int16)1; //订单状态：待处理=0,已通过审核=1 ,未通过审核=20,等待备货=4,等待买家确认收货=5 ,交易关闭=10（系统自动），客户作废=11,客户拒收=12,异常订单=13, 无人签收=3, 客户拒收=12, 已签收=2, 已完成=9, 订单作废=18, 处理中=19
            }
            else
            {
                order.SHIPPING_STATUS = (Int16)0;//发货状态：未发货=0，部分发货=1，已发货=2
                order.ORDER_STATUS = (Int16)0;//订单状态：待处理=0,已通过审核=1 ,未通过审核=20,等待备货=4,等待买家确认收货=5 ,交易关闭=10（系统自动），客户作废=11,客户拒收=12,异常订单=13, 无人签收=3, 客户拒收=12, 已签收=2, 已完成=9, 订单作废=18, 处理中=19
            }
            this.DbContext.SaveChanges();
        }
        /// <summary>
        /// 设置订单状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <exception cref="OrderSdkException">OrderId can not be found by orderId</exception>
        public virtual void SetStandardOrderStatus(string orderId, OrderStatus status)
        {
            if (orderId == null)
                throw new ArgumentNullException("orderId");

            dynamic order = this.GetOrderItemCommonEntity(orderId);
            if (order == null)
                throw new OrderSdkException("400", orderId + "获取订单记录失败");
            order.ORDER_STATUS = (Int16)status;
            this.DbContext.SaveChanges();
        }

        /// <summary>
        /// 检查订单在支付系统中的支付状态及支付金额的正确性。
        /// </summary>
        /// <param name="order"></param>
        /// <exception cref="OrderSdkException">OrderId can not be found by orderId</exception>
        public bool CheckPayIsSuccess(string orderId)
        {
            dynamic order = this.GetOrderItemCommonEntity(orderId);
            if (order == null)
            {
                throw new OrderSdkException("400", orderId + "获取订单记录失败");
            }

            var ispay = (order.PAYMENT_STATUS == 2);
            return ispay;
        }
        #endregion
    }


}