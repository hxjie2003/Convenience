﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ETong.ETM.Sdk.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ET_BussinessEntities : DbContext
    {
        public ET_BussinessEntities()
            : base("name=ET_BussinessEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ETM_BIZ_AGENT_DEALER_DRIVER> ETM_BIZ_AGENT_DEALER_DRIVER { get; set; }
        public virtual DbSet<ETM_LOCATION_TO_LOCATION> ETM_LOCATION_TO_LOCATION { get; set; }
        public virtual DbSet<ETM_SYS_LOCATION> ETM_SYS_LOCATION { get; set; }
    }
}
