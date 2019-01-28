using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using ETong.Order.Logic.Utilitys;
using ETong.Utility.Converts;

using JavaOrderSdk;
using JavaOrderSdk.Model;

namespace ETong.Order.Logic.Common
{
    using System.Data.Entity.Validation;

    using ETong.Common.Enum;
    using ETong.Utility.Log;
    using log4net;

    /// <summary>
    ///     订单逻辑基类
    /// </summary> v
    /// <typeparam name="Context">EF生成的DbContext</typeparam>
    /// <typeparam name="CustomerOrderExtend">自定义的订单扩展字段，与PUB_ORDERS_EXTENDED表映射</typeparam>
    /// <typeparam name="CustomerOrderDetail">自定义的订单明细，与自定义表映射</typeparam>
    /// <typeparam name="PUB_ORDERS_COMMON">EF生成的PUB_ORDERS_GROUP</typeparam>
    /// <typeparam name="PUB_ORDERS_COMMON">EF生成的PUB_ORDERS_COMMON</typeparam>
    /// <typeparam name="PUB_ORDERS_EXTENDED">EF生成的PUB_ORDERS_EXTENDED</typeparam>
    public abstract class OrderLogicalBase<Context, CustomerOrderExtend, CustomerOrderDetail, OrderItem,
        PUB_ORDERS_GROUP, PUB_ORDERS_COMMON, PUB_ORDERS_EXTENDED>
        where Context : DbContext
        where CustomerOrderDetail : class
        where CustomerOrderExtend : class
        where OrderItem : OrderItemInfo<CustomerOrderExtend, CustomerOrderDetail>, new()
        where PUB_ORDERS_GROUP : class, new()
        where PUB_ORDERS_COMMON : class, new()
        where PUB_ORDERS_EXTENDED : class, new()
    {
        #region 字段属性

        /// <summary>
        ///     实体框架
        /// </summary>
        public Context DbContext { get; private set; }


        private OrderLogicalBase()
        {
            SyncToJava = true;
        }

        public OrderLogicalBase(Context context)
        {
            DbContext = context;
            SyncToJava = true;
        }

        private ILog _logger = LogManager.GetLogger("OrderLogicalBase");

        #endregion

        #region 创建订单

        /// <summary>
        ///     必须重载
        /// </summary>
        public abstract int OrderType { get; }

        /// <summary>
        ///     创建本地订单，并保存数据库。（包含扩展表,公共订单表，自定义表。）
        /// </summary>
        /// <param name="orderitems">订单明细单条</param>
        /// <returns>订单创建结果。（包含组ID及订单明细ID等简要信息）</returns>
        public OrderGroupResult CreateOrder(OrderItem orderitem)
        {
            var items = new List<OrderItem>();
            items.Add(orderitem);
            return CreateOrder(items).FirstOrDefault();
        }

        /// <summary>
        ///     创建本地订单，并保存数据库。（包含扩展表,公共订单表，自定义表。）
        /// </summary>
        /// <param name="orderitems">订单明细列表</param>
        /// <returns>订单创建结果。（包含组ID及订单明细ID等简要信息）</returns>
        public List<OrderGroupResult> CreateOrder(List<OrderItem> orderitems)
        {
            var groups = new List<OrderGroupResult>();

            //var stores = orderitems.Select(o => o.OrderCommon.StoreInfo.StoreId).Distinct();
            //foreach (var store in stores)
            //{
            //    dynamic group = null;
            //    var items = orderitems.Where(o => o.OrderCommon.StoreInfo.StoreId == store).ToList();
            //    var groupResult = CreateStoreOrder(items, out group);
            //    groups.Add(groupResult);
            //}
            groups = CreateStoreOrder(orderitems);

            //java
            return groups;
        }

        private List<OrderGroupResult> CreateStoreOrder(List<OrderItem> orderItems)
        {
            if (orderItems.Count == 0)
                throw new Exception("不存在订单明细项（订单项为0），无法创建订单");

            //创建返回结果
            var result = new List<OrderGroupResult>();

            //提交订单到java库, 并返回本地订单组列表
            var groupEntityList = CreateOrderGroupList(orderItems);

            //保存订单到本地库，并返回本地订单组列表
            dynamic dbcontext = DbContext;
            foreach (var g in groupEntityList)
            {
                dbcontext.PUB_ORDERS_GROUP.Add(g);

                dynamic dyGroup = g;
                var orderGroupResult = new OrderGroupResult() { Items = new List<OrderItemResult>() };
                var groupOrderItems = orderItems.Where(o => o.OrderCommon.StoreInfo.StoreId == dyGroup.STORE_ID).ToList();
                foreach (var it in groupOrderItems)
                {
                    PUB_ORDERS_COMMON etCommon = CreateOrderCommon(it.OrderCommon, dyGroup);
                    var extendEntity = CreateOrderExtended(it.OrderExtend, etCommon);
                    AddEntitiesToContext(etCommon, extendEntity);

                    CreateAndAddCustomerOrderDetail(it.OrderDetail, etCommon);

                    dynamic dyCommon = etCommon;
                    var orderItemResult = new OrderItemResult();
                    orderItemResult.OrderId = dyCommon.ORDER_ID;
                    orderItemResult.ItemName = dyCommon.PRODUCT_NAME;
                    orderItemResult.Amount = dyCommon.TOTAL_AMOUNT;
                    orderItemResult.Price = dyCommon.PRODUCT_PRICE;
                    orderItemResult.Qty = dyCommon.PRODUCT_QUANTITY;
                    orderItemResult.StoreId = dyCommon.STORE_ID;
                    orderItemResult.StoreName = dyCommon.STORE_NAME;
                    orderGroupResult.Items.Add(orderItemResult);
                }

                orderGroupResult.GroupId = dyGroup.ORDER_GROUP_ID;
                orderGroupResult.TotalAmount = dyGroup.TOTAL_AMOUNT;

                result.Add(orderGroupResult);
            }

            try
            {
                DbContext.SaveChanges();
            }
            catch (DbEntityValidationException exception)
            {
                var msg = "创建订单保存时异常，原因：" + exception.Message;
                _logger.Error(msg, exception);
                throw exception;
            }
            catch (Exception exception)
            {
                var msg = "创建订单保存时异常，原因：" + exception.Message + exception.GetType().FullName;
                _logger.Error(msg, exception);

                throw exception;
            }


            return result;
        }

        /// <summary>
        ///     创建订单组列表
        /// </summary>
        /// <param name="orders">订单明细项</param>
        /// <returns>订单组实体表列</returns>
        private List<PUB_ORDERS_GROUP> CreateOrderGroupList(List<OrderItem> orderItems)
        {
            //TODO:: will be remove
            //java 主订单服务同步
            if (orderItems.Count == 0)
            {
                throw new Exception("不存在订单明细项（订单项为0），无法创建订单");
            }

            var result = new List<PUB_ORDERS_GROUP>();

            //为方便取得本次业务各订单的会员和ETM等公共信息
            var orderFirst = orderItems.FirstOrDefault().OrderCommon;
            //按店铺分一个订单组, 对应一个java订单
            var orderList = new Dictionary<OrderItem, List<OrderItem>>();
            orderItems.Select(o => o.OrderCommon.StoreInfo.StoreId).Distinct().ToList().ForEach(storeId =>
            {
                //某一店铺的订单明细
                var storeItems = orderItems.Where(o => o.OrderCommon.StoreInfo.StoreId == storeId).ToList();
                //单头，明细
                orderList.Add(storeItems[0], storeItems);
            });

            if (OrderType > 0 && orderList.Count > 1)
            {
                throw new Exception("便民只能一次创建一个订单组");
            }

            //接收java接口返回的订单号列表
            var javaOrderIds = new Dictionary<string, string>();
            //if (!string.IsNullOrWhiteSpace(orderFirst.OrderETMID))
            //{
            //    orderFirst.OrderFrom = 1;
            //}
            //判断是否来源于ETM下单
            var isFromETM = orderFirst.OrderFrom == 1;
            //处理同步
            if (SyncToJava && (isFromETM || this.OrderType == 2 || this.OrderType == 16 || this.OrderType == 17 || this.OrderType == 18 || this.OrderType == 21 || this.OrderType == 6))
            {
                //订单同步处理器
                var orderManager = new OrderManager();
                //接收java接口的返回结果
                CreateOrderResponse createOrderResponse = null;

                //ETM库的商城订单类型OrderType=0；便民订单类型OrderType=n
                if (OrderType != 0)
                {
                    try
                    {
                        _logger.Info("开始向Java同步订单！");
                        // java接口要接收的"订单"数据结构(便民)
                        OrderInfo javaOrder = MapOrderForJave(orderItems);

                        // 提交到java接口
                        createOrderResponse = orderManager.CreateOrder(javaOrder);
                        javaOrderIds.Add(javaOrder.storeId, createOrderResponse.dataMap.orderId);
                    }
                    catch (Exception exception)
                    {
                        _logger.Error("创建订单同步到JAVA失败", exception);
                        throw exception;
                    }
                }
                else
                {
                    MallOrderInfos javaOrders = new MallOrderInfos() { orderList = new MallOrderInfo[] { } };
                    javaOrders.memberId = orderFirst.MemberId.ToLower() == "etong_common_user" ? null : orderFirst.MemberId;

                    //为方便组织出javaOrders.orderList
                    var javaOrderList = new List<MallOrderInfo>();
                    foreach (var order in orderList)
                    {
                        //java接口要接收的"订单"数据结构(商城)
                        MallOrderInfo javaOrder = MapOrderForJave(order.Value);

                        //java接口要接收的"订单明细"数据结构
                        var javaOrderItems = new List<CreateOrderMallOrderitemlist>();
                        order.Value.ForEach(item =>
                        {
                            javaOrderItems.Add(MapOrderItemForJava(item));
                        });
                        //java接口要接收的"订单"数据结构
                        javaOrder.orderItemList = javaOrderItems.ToArray();

                        //记住java接口要接收的"订单列表"
                        javaOrderList.Add(javaOrder);
                    }
                    //java接口要接收的"订单列表"数据结构
                    javaOrders.orderList = javaOrderList.ToArray();
                    _logger.Info("开始向Java同步订单！");
                    //提交到java接口, 将整个订单组列表一次性提交到java接口, 这样能使用到java的数据库事务处理
                    createOrderResponse = orderManager.CreateMallOrder(javaOrders);
                    javaOrderIds = createOrderResponse.dataMap.orderIds;
                }
            }

            //生成本地"订单组"列表.
            foreach (var g in orderList)
            {
                var javaOrderId = javaOrderIds.Where(o => o.Key == g.Key.OrderCommon.StoreInfo.StoreId).FirstOrDefault().Value;
                var groupId = string.IsNullOrWhiteSpace(javaOrderId) ? OrderCodeGen.GetOrderGroupId() : javaOrderId;
                var orderCount = OrderType == 0 ? orderList.Values.Count : 1;
                var totalAmount = g.Value.Sum(o => o.OrderCommon.TotalAmount);

                //生成本地订单组
                dynamic group = new PUB_ORDERS_GROUP();
                group.ORDER_GROUP_ID = groupId;
                group.IS_CREDIT = 0;
                group.ORDER_TYPE = OrderType;
                group.TOTAL_ORDERS = orderCount;
                group.TOTAL_AMOUNT = totalAmount;
                group.MEMBER_ID = g.Key.OrderCommon.MemberId;
                group.STORE_ID = g.Key.OrderCommon.StoreInfo.StoreId;
                group.STORE_NAME = g.Key.OrderCommon.StoreInfo.StoreName;
                group.ORDER_DATE = DateTime.Now;

                //本地订单组列表
                result.Add(group);
            }

            return result;
        }

        protected virtual MallOrderInfo MapOrderForJave(List<OrderItem> orders)
        {
            var order = orders[0];

            var memberId = (String.IsNullOrEmpty(order.OrderCommon.MemberId) || order.OrderCommon.MemberId.ToLower() == "etong_common_user") ? null : order.OrderCommon.MemberId;
            var memberName = (String.IsNullOrEmpty(order.OrderCommon.MemberName) || order.OrderCommon.MemberName.ToLower() == "etong_anonymous") ? null : order.OrderCommon.MemberName;

            var orderInfo = new MallOrderInfo
            {
                //orderId = orderItemResult.OrderId,
                memberId = memberId,
                memberName = memberName,
                message = null,
                orderAmount = (orders.Sum(o => o.OrderCommon.TotalAmount)).ToString(),//订单本身金额,不包括运费等
                orderDescribe = order.OrderCommon.ProductInfo.ProductDescription,
                orderFrom = order.OrderCommon.OrderFrom.ToString(),
                orderType = OrderType == 0 ? "31" : OrderType.ToString(),//商城订单类型在ETM库是0, 在java新库是31
                storeId = order.OrderCommon.StoreInfo.StoreId,
                storeName = order.OrderCommon.StoreInfo.StoreName,
                totalAmount = (orders.Sum(o => o.OrderCommon.TotalAmount)).ToString(),//订单总金额,包括订单金额和运费等
                orderEtm = order.OrderCommon.OrderETMID,
                freightTemplateId = order.OrderCommon.DeliveryInfo.DeliveryId,//运费模板Id
                freightTypeId = order.OrderCommon.DeliveryInfo.DeliveryTypeId //运送方式Id
            };

            return orderInfo;
        }

        protected virtual CreateOrderMallOrderitemlist MapOrderItemForJava(OrderItem item)
        {
            return new JavaOrderSdk.Model.CreateOrderMallOrderitemlist()
            {
                goodsId = item.OrderCommon.ProductInfo.GoodsID,
                goodsName = item.OrderCommon.ProductInfo.GoodsName,
                productId = item.OrderCommon.ProductInfo.ProductID,
                productName = item.OrderCommon.ProductInfo.ProductName,
                productPrice = item.OrderCommon.ProductInfo.ProductPrice.ToString(),
                productQuantity = item.OrderCommon.Quantity.ToString(),
                productSn = item.OrderCommon.ProductInfo.ProductID,
                goodsImagePath = item.OrderCommon.ProductInfo.ImgUrl,
                goodsUrl = String.Empty,
                skuText = item.OrderCommon.ProductInfo.ProductDescription,//产品sku属性文本,格式如:颜色:红色;尺码:180cm
            };
        }

        /// <summary>
        ///     创建公共订单部分
        /// </summary>
        /// <param name="order">公共订单信息</param>
        /// <returns></returns>
        private PUB_ORDERS_COMMON CreateOrderCommon(OrderCommon order, dynamic groupDB)
        {
            dynamic commonorder = new PUB_ORDERS_COMMON();
            commonorder.ORDER_ID = OrderCodeGen.GetOrderId();
            commonorder.ORDER_GROUP_ID = groupDB.ORDER_GROUP_ID;
            commonorder.IS_DELETE = 0; //是否删除：未删除：0,已删除：1
            commonorder.IS_CREDIT = groupDB.IS_CREDIT; //订单类别: 0:原生订单；1:信用订单
            commonorder.ORDER_STATUS = 0;
            //订单状态：待处理=0,已通过审核=1 ,未通过审核=20,等待备货=4,等待买家确认收货=5 ,交易关闭=10（系统自动），客户作废=11,客户拒收=12,异常订单=13, 无人签收=3, 客户拒收=12, 已签收=2, 已完成=9, 订单作废=18, 处理中=19
            commonorder.SHIPPING_STATUS = 0; //发货状态：未发货=0，部分发货=1，已发货=2
            // commonorder.REFUND_MONEY_STATUS = "";//仅退款状态：退款协议等待商家确认=0,商家不同意协议=1, 商家同意退款=2,商家同意部分退款=3,客服介入=6,退款关闭=7,退款成功=8,商家准备退款=9, 买家同意取消退款申请=10
            // commonorder.REFUND_GOODSMONEY_STATUS = "";//退货退款状态：退货退款协议等待商家确认=0、商家不同意协议=1、等待买家退货=2、买家已发货等待商家确认=3、商家确认收货拒绝退款=4、商家确认收货准备退款=5、客服介入=6、退货退款关闭=7、退款成功=8、商家准备退款=9、等待买家发货=10、买家同意取消退款退货=11
            // commonorder.REFUND_CHANGGOODS_STATUS = "";//换货状态：换货协议等待商家确认=0、商家不同意协议=1、换货处理中=2、客服介入=6、换货关闭=7、换货成功=8、买家同意取消换货=9、等待买家发货=10、换货处理中=11
            // commonorder.REFUND_REPAIR_STATUS = "";//维修状态：维修协议等待商家确认=0、商家不同意协议=1、维修处理中=2、客服介入=6、维修关闭=7、维修成功=8、买家同意取消返修＝9、等待买家发货＝10
            // commonorder.TRANSFOR_STATUS = "";//分配状态：待转发=0；已转发=1；驳回=2；回收=3

            commonorder.ORDER_FROM = order.OrderFrom; //订单来源：商城=0，ETM=1，进销存=2，B2C=3，APP=4
            commonorder.ORDER_TYPE = OrderType;
            //订单类型：商城订单=0，彩票订单=1，机票订单=2，报刊订单=3，充值订单=4，火车票订单=5，交通违章订单=6，景点门票订单=7，旅游酒店订单=8，汽车票订单=9，就医助手订单=10，幸运大转盘＝11，酒店预订＝12，东莞通＝13，信用卡＝14，银行转账＝15，水费订单＝16 ,电费订单＝17，煤气费订单＝18，流量充值＝19，电影票订单＝20
            commonorder.ORDER_CLASSIFY = order.OrderClassify; //订单分类：一般订单=0，组合套餐=1，团购=2，促销=3

            #region 设置产品信息

            if (order.ProductInfo == null)
                throw new Exception("产品信息为空，无法创建订单！");
            commonorder.ITEM_TYPE = order.ProductInfo.ItemType; //实体商品标志：实体商品=1，虚拟商品=0
            // commonorder.OPERATE_STATUS = "";//操作状态：用与虚拟订单类的扩展
            commonorder.PRODUCT_ID = order.ProductInfo.ProductID; //货品ID
            if (string.IsNullOrWhiteSpace(order.ProductInfo.ProductName))
                throw new Exception("订单的货品ProductName名称不能为空！");
            commonorder.PRODUCT_NAME = order.ProductInfo.ProductName; //货品名称
            commonorder.PRODUCT_PRICE = order.ProductInfo.ProductPrice; //货品价格           
            commonorder.GOODS_ID = order.ProductInfo.GoodsID; //商品ID
            if (string.IsNullOrWhiteSpace(order.ProductInfo.GoodsName))
                throw new Exception("订单的商品GoodsName名称不能为空！");
            commonorder.GOODS_NAME = order.ProductInfo.GoodsName;
            ; //商品名称
            commonorder.GOODSCATEGORYSET_ID = order.ProductInfo.GoodsCategroySetID; //商品类目ID
            commonorder.BRAND_NAME = order.ProductInfo.BrandName; //品牌名称
            commonorder.IMGURL = order.ProductInfo.ImgUrl; //商品图片URl
            commonorder.PRODUCT_DESCRIPTION = order.ProductInfo.ProductDescription; //商品规格描述

            #endregion

            if (order.Quantity == 0)
                throw new Exception("不能添加数量为零的订单项！");
            commonorder.PRODUCT_QUANTITY = order.Quantity; //货品总数
            commonorder.TOTAL_AMOUNT = order.TotalAmount; //订单金额
            commonorder.PAYMENT_STATUS = 0; //支付状态：未支付=0，部分支付=1，已支付=2，部分退款=3，全额退款=4，联合支付=5，无需支付=6
            // commonorder.PAYMENT_DATE = "";//支付时间
            commonorder.ORDER_ETM = order.OrderETMID; //下订单时ETM机编号
            // commonorder.PAY_ETM = "";//订单支付时ETM机编号
            commonorder.MEMBER_ID = order.MemberId; //订单购买会员ID
            commonorder.CREATOR = order.MemberName; //下单会员名称
            commonorder.CREATOR_IP = order.CreateIP; //下单会员IP地址
            commonorder.CREATE_DATE = groupDB.ORDER_DATE; //创建时间
            commonorder.MODIFY_DATE = groupDB.ORDER_DATE; //修改时间
            if (string.IsNullOrWhiteSpace(order.StoreInfo.StoreId))
                throw new Exception("商家编号不能为空。");
            commonorder.STORE_ID = order.StoreInfo.StoreId; //商家ID
            commonorder.STORE_NAME = order.StoreInfo.StoreName; //商家名称
            // commonorder.DELIVERY_SN = "";//物流编号
            // commonorder.DELIVERY_NAME = "";//物流名称
            commonorder.SHIP_PROVINCES = order.DeliveryInfo.ShipProvince; //收货省
            commonorder.SHIP_CITY = order.DeliveryInfo.ShipCity; //收货市
            commonorder.SHIP_REGION = order.DeliveryInfo.ShipRegion; //收货区
            commonorder.SHIP_ADDR = order.DeliveryInfo.ShipAddress; //收货详细地址
            //commonorder.VERIFY_DELIVERY_DATE = "";//订单确认完成时间       
            commonorder.DELIVERYTYPE_ID = order.DeliveryInfo.DeliveryTypeId; //配送方式ID
            commonorder.DELIVERYTYPENAME = order.DeliveryInfo.DeliveryTypeName; //配送方式名称
            //commonorder.ISCOMMENTED = "";//该订单是否已评价（-1：订单交易完成但没评价 0：买家已评价 1：双方已评价  -8:无）            
            commonorder.TOTAL_COST = 0; //订单总成本，默认值为0
            commonorder.ALLOCATION_STATUS = 0; //分润标志，0：未分，1：待分，2：已分     

            return commonorder;
        }

        /// <summary>
        ///     使用时重载:var extend=base.CreateOrderExtended（）;extend.EXTCOL01=extend.xxx；
        /// </summary>
        /// <param name="order">订单信息</param>
        /// <param name="extend"></param>
        /// <returns></returns>
        /// <summary>
        ///     创建1对1表的扩展部份。（如无用到此函数可不需重载。）
        /// </summary>
        /// <param name="extend">订单扩展信息</param>
        /// <param name="puborderscommon">订单公共信息实体</param>
        /// <returns>订单扩展实体</returns>
        protected virtual PUB_ORDERS_EXTENDED CreateOrderExtended(CustomerOrderExtend extend, PUB_ORDERS_COMMON puborderscommon)
        {
            var extenddb = default(PUB_ORDERS_EXTENDED);
            if (extend != null)
            {
                dynamic extenddynamic = new PUB_ORDERS_EXTENDED();
                dynamic ordercommon = puborderscommon;
                extenddynamic.ORDER_ID = ordercommon.ORDER_ID;
                extenddynamic.ORDER_TYPE = ordercommon.ORDER_TYPE;
                extenddynamic.CREATE_DATE = ordercommon.CREATE_DATE;
                extenddb = extenddynamic;
            }
            return extenddb;
        }

        /// <summary>
        ///     将产生的实体添加到实体上下文。
        /// </summary>
        /// <param name="common">公共订单实体</param>
        /// <param name="extended">扩展订单实体</param>
        private void AddEntitiesToContext(PUB_ORDERS_COMMON common, PUB_ORDERS_EXTENDED extended)
        {
            dynamic context = DbContext;
            if (common == null)
                throw new Exception("PUB_ORDERS_COMMON是null值，未能创建订单！");
            context.PUB_ORDERS_COMMON.Add(common);
            if (extended != null)
                context.PUB_ORDERS_EXTENDED.Add(extended);
        }


        /// <summary>
        ///     在使用到PUB_ORDERS_COMMON表及PUB_ORDERS_EXTENDED表以外的自定表时使用。
        ///     需要手动创建实体，并添加到Context中。
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="commonentity"></param>
        protected virtual void CreateAndAddCustomerOrderDetail(CustomerOrderDetail detail, PUB_ORDERS_COMMON commonentity)
        {
        }

        #endregion

        #region 订单查询

        #region Public方法

        /// <summary>
        ///     根据订单组ID查询订单项
        /// </summary>
        /// <param name="groupId">订单组ID</param>
        /// <returns>订单明细列表</returns>
        public List<OrderItem> GetOrderItems(string groupId)
        {
            var list = Get_PUB_ORDERS_COMMON_LIST(groupId);
            var orderlist = new List<OrderItem>();
            foreach (var c in list)
            {
                dynamic ordercomon = c;
                var item = new OrderItem();
                item.OrderCommon = GetOrderCommon(c);
                item.OrderID = ordercomon.ORDER_GROUP_ID;

                item.OrderExtend = this.GetCustomerOrderExtend(ordercomon.PUB_ORDERS_EXTENDED);
                item.OrderDetail = this.GetCustomerOrderDetail(ordercomon.ORDER_ID);
                orderlist.Add(item);
            }
            return orderlist;
        }

        public OrderItem GetOrderItem(string orderid)
        {
            var item = new OrderItem();
            item.OrderCommon = GetOrderCommon(orderid);
            item.OrderDetail = GetCustomerOrderDetail(orderid);
            item.OrderID = orderid;
            item.OrderExtend = GetCustomerOrderExtend(orderid);
            return item;
        }


        /// <summary>
        ///     根据订单ID获取订公共订单信息。
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public OrderCommonFull GetOrderCommon(string orderid)
        {
            OrderCommonFull ordercommon = null;
            var common = Get_PUB_ORDERS_COMMON(orderid);
            ordercommon = GetOrderCommon(common);
            return ordercommon;
        }

        /// <summary>
        ///     依据订单ID获取自定义订单扩展信息。
        /// </summary>
        /// <param name="orderid">订单ID</param>
        /// <returns>自定义扩展信息类</returns>
        public CustomerOrderExtend GetCustomerOrderExtend(string orderid)
        {
            var extendentity = Get_PUB_ORDERS_EXTENDED(orderid);
            var extend = GetCustomerOrderExtend(extendentity);
            return extend;
        }

        /// <summary>
        ///     根据订单ID查询自定义属性表属性。
        /// </summary>
        /// <param name="orderid">订单ID</param>
        /// <returns>自定义属性表属性</returns>
        public virtual CustomerOrderDetail GetCustomerOrderDetail(string orderid)
        {
            return null;
        }

        #endregion

        #region protected方法

        /// <summary>
        ///     依据扩展信息实体转换成自定义扩展信息。（需重载）
        /// </summary>
        /// <param name="orderextend">订单ID</param>
        /// <returns>自定义扩展信息类</returns>
        protected virtual CustomerOrderExtend GetCustomerOrderExtend(PUB_ORDERS_EXTENDED orderextend)
        {
            throw new NotImplementedException("GetCustomerOrderExtend方法未实现！");
        }


        /// <summary>
        ///     通过订单号获得扩展订单实体。
        /// </summary>
        /// <param name="orderid">订单号</param>
        /// <returns>扩展订单实体</returns>
        protected virtual PUB_ORDERS_EXTENDED Get_PUB_ORDERS_EXTENDED(string orderid)
        {
            return null;
        }

        /// <summary>
        ///     根据公共订单实体转换公共订单信息。
        /// </summary>
        /// <param name="orderCommonentity">公共订单实体</param>
        /// <returns>公共订单信息</returns>
        protected OrderCommonFull GetOrderCommon(PUB_ORDERS_COMMON orderCommonentity)
        {
            dynamic commonentitydynamic = orderCommonentity;
            OrderCommonFull common = null;
            if (orderCommonentity != null)
            {
                common = new OrderCommonFull();
                common.OrderId = commonentitydynamic.ORDER_ID;
                if (commonentitydynamic.IS_DELETE != null)
                {
                    common.IsDelete = commonentitydynamic.IS_DELETE;
                }
                if (commonentitydynamic.IS_CREDIT != null)
                {
                    common.IsCredit = commonentitydynamic.IS_CREDIT;
                }
                if (commonentitydynamic.ORDER_STATUS != null)
                {
                    common.OrderStatus = commonentitydynamic.ORDER_STATUS;
                }
                if (commonentitydynamic.SHIPPING_STATUS != null)
                {
                    common.ShippingStatus = commonentitydynamic.SHIPPING_STATUS;
                }

                // commonorder.REFUND_MONEY_STATUS = "";//仅退款状态：退款协议等待商家确认=0,商家不同意协议=1, 商家同意退款=2,商家同意部分退款=3,客服介入=6,退款关闭=7,退款成功=8,商家准备退款=9, 买家同意取消退款申请=10
                // commonorder.REFUND_GOODSMONEY_STATUS = "";//退货退款状态：退货退款协议等待商家确认=0、商家不同意协议=1、等待买家退货=2、买家已发货等待商家确认=3、商家确认收货拒绝退款=4、商家确认收货准备退款=5、客服介入=6、退货退款关闭=7、退款成功=8、商家准备退款=9、等待买家发货=10、买家同意取消退款退货=11
                // commonorder.REFUND_CHANGGOODS_STATUS = "";//换货状态：换货协议等待商家确认=0、商家不同意协议=1、换货处理中=2、客服介入=6、换货关闭=7、换货成功=8、买家同意取消换货=9、等待买家发货=10、换货处理中=11
                // commonorder.REFUND_REPAIR_STATUS = "";//维修状态：维修协议等待商家确认=0、商家不同意协议=1、维修处理中=2、客服介入=6、维修关闭=7、维修成功=8、买家同意取消返修＝9、等待买家发货＝10
                // commonorder.TRANSFOR_STATUS = "";//分配状态：待转发=0；已转发=1；驳回=2；回收=3
                if (commonentitydynamic.ORDER_FROM != null)
                {
                    common.OrderFrom = commonentitydynamic.ORDER_FROM;
                }

                //订单类型：商城订单=0，彩票订单=1，机票订单=2，报刊订单=3，充值订单=4，火车票订单=5，交通违章订单=6，景点门票订单=7，旅游酒店订单=8，汽车票订单=9，就医助手订单=10，幸运大转盘＝11，酒店预订＝12，东莞通＝13，信用卡＝14，银行转账＝15，水费订单＝16 ,电费订单＝17，煤气费订单＝18，流量充值＝19，电影票订单＝20
                if (commonentitydynamic.ORDER_TYPE != null)
                {
                    common.OrderType = commonentitydynamic.ORDER_TYPE;
                }
                if (commonentitydynamic.ORDER_CLASSIFY != null)
                {
                    common.OrderClassify = commonentitydynamic.ORDER_CLASSIFY;
                }

                #region 设置产品信息

                var product_Name = "";
                var item_Type = 0;
                decimal product_Price = 0;

                if (!string.IsNullOrEmpty(commonentitydynamic.PRODUCT_NAME))
                {
                    product_Name = commonentitydynamic.PRODUCT_NAME;
                }
                if (commonentitydynamic.ITEM_TYPE != null)
                {
                    item_Type = commonentitydynamic.ITEM_TYPE;
                }
                if (commonentitydynamic.PRODUCT_PRICE != null)
                {
                    product_Price = commonentitydynamic.PRODUCT_PRICE;
                }
                common.ProductInfo = new OrderProductInfo(product_Name, item_Type, product_Price);
                common.ProductInfo.ProductID = commonentitydynamic.PRODUCT_ID;
                common.ProductInfo.GoodsID = commonentitydynamic.GOODS_ID;
                common.ProductInfo.GoodsName = commonentitydynamic.GOODS_NAME;
                common.ProductInfo.GoodsCategroySetID = commonentitydynamic.GOODSCATEGORYSET_ID;
                common.ProductInfo.BrandName = commonentitydynamic.BRAND_NAME;
                common.ProductInfo.ImgUrl = commonentitydynamic.IMGURL;
                common.ProductInfo.ProductDescription = commonentitydynamic.PRODUCT_DESCRIPTION;

                #endregion

                if (commonentitydynamic.PRODUCT_QUANTITY != null)
                {
                    common.Quantity = commonentitydynamic.PRODUCT_QUANTITY;
                }
                if (commonentitydynamic.TOTAL_AMOUNT != null)
                {
                    common.TotalAmount = commonentitydynamic.TOTAL_AMOUNT;
                }
                if (commonentitydynamic.PAYMENT_STATUS != null)
                {
                    common.PaymentStatus = commonentitydynamic.PAYMENT_STATUS;
                }
                common.PaymentTime = commonentitydynamic.PAYMENT_DATE; //支付时间
                common.OrderETMID = commonentitydynamic.ORDER_ETM;
                common.PayETM = commonentitydynamic.PAY_ETM; //订单支付时ETM机编号
                common.MemberId = commonentitydynamic.MEMBER_ID;
                common.MemberName = commonentitydynamic.CREATOR;
                common.CreateIP = commonentitydynamic.CREATOR_IP;
                if (commonentitydynamic.CREATE_DATE != null)
                {
                    common.OrderDate = commonentitydynamic.CREATE_DATE;
                }

                //commonentitydynamic.MODIFY_DATE = groupDB.ORDER_DATE;//修改时间
                common.StoreInfo = new OrderStoreInfo();
                common.StoreInfo.StoreId = commonentitydynamic.STORE_ID;
                common.StoreInfo.StoreName = commonentitydynamic.STORE_NAME;

                common.DeliverySn = commonentitydynamic.DELIVERY_SN;
                common.DeliveryName = commonentitydynamic.DELIVERY_NAME;


                common.DeliveryInfo.ShipProvince = commonentitydynamic.SHIP_PROVINCES; //收货省
                common.DeliveryInfo.ShipCity = commonentitydynamic.SHIP_CITY; //收货市
                common.DeliveryInfo.ShipRegion = commonentitydynamic.SHIP_REGION; //收货区
                common.DeliveryInfo.ShipAddress = commonentitydynamic.SHIP_ADDR; //收货详细地址
                //commonorder.VERIFY_DELIVERY_DATE = "";//订单确认完成时间          
                common.DeliveryInfo.DeliveryTypeId = commonentitydynamic.DELIVERYTYPE_ID; //配送方式ID
                common.DeliveryInfo.DeliveryTypeName = commonentitydynamic.DELIVERYTYPENAME; //配送方式名称
                //commonorder.ISCOMMENTED = "";//该订单是否已评价（-1：订单交易完成但没评价 0：买家已评价 1：双方已评价  -8:无）            
                common.TotalCost = commonentitydynamic.TOTAL_COST = 0; //订单总成本，默认值为0
                common.AllocationStatus = commonentitydynamic.ALLOCATION_STATUS = 0; //分润标志，0：未分，1：待分，2：已分           
            }
            return common;
        }

        /// <summary>
        ///     根据订单组ID获取公共订单实体类。（可在重载中使用Include方法将PUB_ORDERS_EXTENDED包含）
        /// </summary>
        /// <param name="groupid">组ID</param>
        /// <returns>公共订单实体列表</returns>
        protected virtual List<PUB_ORDERS_COMMON> Get_PUB_ORDERS_COMMON_LIST(string groupid)
        {
            return new List<PUB_ORDERS_COMMON>();
        }

        /// <summary>
        ///     通过订单ID查找公共订单实体PUB_ORDERS_COMMON。
        /// </summary>
        /// <param name="orderid">订单号</param>
        /// <returns>PUB_ORDERS_COMMON实体</returns>
        protected virtual PUB_ORDERS_COMMON Get_PUB_ORDERS_COMMON(string orderid)
        {
            return null;
        }

        #endregion

        #endregion

        #region 修改订单状态

        /// <summary>
        ///     设置发货状态或第三方发货成功状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <exception cref="OrderNotFoundException">OrderId can not be found by orderId</exception>
        public virtual void SetStandardShipStatus(string orderId, bool shipstatus)
        {
            dynamic order = Get_PUB_ORDERS_COMMON(orderId);

            if (order == null)
                throw new OrderNotFoundException(orderId);

            if (shipstatus)
            {
                order.SHIPPING_STATUS = 2; //发货状态：未发货=0，部分发货=1，已发货=2
                order.ORDER_STATUS = 1;
                //订单状态：待处理=0,已通过审核=1 ,未通过审核=20,等待备货=4,等待买家确认收货=5 ,交易关闭=10（系统自动），客户作废=11,客户拒收=12,异常订单=13, 无人签收=3, 客户拒收=12, 已签收=2, 已完成=9, 订单作废=18, 处理中=19
            }
            else
            {
                order.SHIPPING_STATUS = 0; //发货状态：未发货=0，部分发货=1，已发货=2
                order.ORDER_STATUS = 0;
                //订单状态：待处理=0,已通过审核=1 ,未通过审核=20,等待备货=4,等待买家确认收货=5 ,交易关闭=10（系统自动），客户作废=11,客户拒收=12,异常订单=13, 无人签收=3, 客户拒收=12, 已签收=2, 已完成=9, 订单作废=18, 处理中=19
            }
            DbContext.SaveChanges();
        }

        /// <summary>
        ///     设置订单状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <exception cref="OrderNotFoundException">OrderId can not be found by orderId</exception>
        public virtual void SetStandardOrderStatus(string orderId, OrderStatus status)
        {
            ILog _logger = LogManager.GetLogger(this.GetType());
            if (orderId == null)
                throw new ArgumentNullException("orderId");

            dynamic order = Get_PUB_ORDERS_COMMON(orderId);
            if (order == null)
                throw new OrderNotFoundException(orderId);

            order.ORDER_STATUS = (int)status;
            DbContext.SaveChanges();
            _logger.Debug("SyncToJava状态:" + SyncToJava.ToString());
            _logger.Debug("SyncToJava订单状态:" + status.ToString());
            if (SyncToJava)
            {
                //java同步.
                string groupId, memberId;
                GetGroupIdByOrderId(orderId, out groupId, out memberId);
                if (status == OrderStatus.Finished)
                {
                    try
                    {

                        _logger.Debug("开始进行Java订单同步，orderId=" + groupId);
                        OrderManager manager = new OrderManager();
                        manager.Finish(groupId, memberId, GetProviderByOrderType(order.ORDER_TYPE, order));
                        _logger.Debug("Java订单同步成功，orderId=" + groupId);
                    }
                    catch (Exception exception)
                    {
                        Logger.Write(Log.Log_Type.Error, "同步JAVA订单状态失败", exception);
                        throw exception;
                    }

                }

                if (status == OrderStatus.CancelByCustomer)
                {
                    try
                    {
                        OrderManager manager = new OrderManager();
                        manager.Cancel(groupId, memberId);
                    }
                    catch (Exception exception)
                    {
                        Logger.Write(Log.Log_Type.Error, "同步JAVA订单状态失败", exception);
                        throw exception;
                    }
                }
            }
        }

        protected virtual bool SyncToJava { get; set; }
        protected abstract void GetGroupIdByOrderId(string orderId, out string groupId, out string memberId);

        /// <summary>
        /// 检查订单是否已支付
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <returns>是否</returns>
        public bool CheckPayIsSuccess(string orderId)
        {
            dynamic order = Get_PUB_ORDERS_COMMON(orderId);
            if (order == null)
            {
                throw new OrderNotFoundException("orderId");
            }

            var ispay = (order.PAYMENT_STATUS == 2);
            return ispay;
        }

        #endregion

        protected virtual string GetProviderByOrderType(int orderType, PUB_ORDERS_COMMON orderItem)
        {
            //http://192.168.0.97/mediawiki/index.php?title=%E8%AE%A2%E5%8D%95#order_type
            switch (orderType)
            {
                case 0:
                    throw new NotImplementedException("请在商城订单实现本方法");
                case 1:
                    throw new NotImplementedException("现在没有彩票了");
                case 2:
                    return "P0005";
                case 7:
                case 12:
                    return "P0005";
                case 3:
                    throw new NotImplementedException("现在没有报刊了");
                case 4:
                    throw new NotImplementedException("手机要自己override");
                case 5:
                    return "P0008"; //航天华友
                case 6:
                    throw new NotImplementedException("请在交通违章订单实现本方法");
                case 10:
                    return "P0011";
                case 11:
                    throw new NotImplementedException("现在没有了幸运大转盘");
                case 13:
                    return "P0013";
                case 14:
                    return "P0012";
                case 15:
                    return "P0013";
                case 16:
                    return "P0016";
                case 17:
                case 18:
                case 19:
                case 21:
                case 22:
                    return "P0006";
                case 20:
                    return "P0014";
                case 23:
                    return "P0015";
                default:
                    throw new NotImplementedException("Not imple get　Provider　for " + orderType);


            }
            return "";

        }
    }
}