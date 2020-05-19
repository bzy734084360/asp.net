using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFistDemo
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
        public DbSet<ClassInfoCF> ClassInfoCF { get; set; }
        public DbSet<StudentInfoCF> StudentInfoCF { get; set; }
    }
}
