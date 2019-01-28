using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;



namespace NativeOrderSdk.Common.EntityModels
{
    public class BaseOrderContext : DbContext
    {
        // 20151202 - KK186 - 此处的连接改为OrderContext，因为API里面是使用这个名称的。为了能兼容之前的酒店
        public BaseOrderContext()
            : base("name=OraString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ET_ORDERS");
        }
       
        public DbSet<PUB_ORDERS_COMMON> PUB_ORDERS_COMMON { get; set; }  
        public DbSet<PUB_ORDERS_GROUP> PUB_ORDERS_GROUP { get; set; }
        public DbSet<PUB_ORDERS_EXTENDED> PUB_ORDERS_EXTENDED { get; set; }
    }
}
