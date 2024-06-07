using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProObject.EFDemo
{
    public class CodeFirstDbContext : DbContext
    {
        public CodeFirstDbContext() : base("name=connStr")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
            //移除复数约定
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<CodeFirstDemoModel> CodeFirstDemoInfo { get; set; }
    }
}