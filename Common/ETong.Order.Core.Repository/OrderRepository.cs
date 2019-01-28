using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Data.Entity.Validation;
using System.Text;
using ETong.Order.Core.Repository.Models;

namespace ETong.Order.Core.Repository
{
    /// <summary>
    /// 订单持久化基类
    /// </summary>
    /// <typeparam name="Context"></typeparam>

    public abstract class OrderRepository<Context>
        where Context : DbContext, new()
    {
      
        private Context _dbContext;
        /// <summary>
        /// 实体模型
        /// </summary>
        public Context DbContext
        {
            get { return _dbContext; }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public OrderRepository()
        {
            this._dbContext = new Context();
        }
        /// <summary>
        /// 订单类型
        /// </summary>
        public abstract int OrderType
        { get; }
    }


}