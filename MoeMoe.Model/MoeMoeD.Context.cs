﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MoeMoeD.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MoeMoeDEntities : DbContext
    {
        public MoeMoeDEntities()
            : base("name=MoeMoeDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Flie> Flie { get; set; }
        public virtual DbSet<Floder> Floder { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}