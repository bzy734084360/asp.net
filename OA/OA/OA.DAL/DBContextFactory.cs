using OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OA.DAL
{
    /// <summary>
    /// 负责创建EF 数据操作上下文实例，必须保证线程内唯一。
    /// </summary>
    public class DBContextFactory
    {
        public static DbContext CreateDbContext()
        {
            //HTTPContext 中实现 是由CallContext 所以 直接使用CallContext
            DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
            if (dbContext == null)
            {
                dbContext = new OAEntities();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}
