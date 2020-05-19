using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFistDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeFirstDbContext db = new CodeFirstDbContext();
            //检测是否有数据库，如果无则直接创建数据库
            db.Database.CreateIfNotExists();
            ClassInfoCF classInfo = new ClassInfoCF();
            classInfo.ClassName = "0001班";
            classInfo.CreateTime = DateTime.Now;
            db.ClassInfoCF.Add(classInfo);
            db.SaveChanges();
        }
    }
}
