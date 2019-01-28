namespace ETong.Order.Logic
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderNotFoundException : OrderException
    {
        public OrderNotFoundException(string id)
            : base("404","无法通过Id找到订单信息(id=" + id + ")")
        {

        }

    }
}