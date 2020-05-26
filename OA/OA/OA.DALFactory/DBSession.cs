using OA.DAL;
using OA.IDAL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DALFactory
{
    /// <summary>
    /// 数据会话层:就是一个工厂类，负责完成所有数据操作类实例的创建，然后业务层通过数据会话层来回去要操作数据类的实例
    /// 所以数据会话层将业务层与数据层解耦
    /// 在数据会话层中提供一个方法：完成所有数据的保存。
    /// </summary>
    public class DBSession : IDBSession
    {
        public DbContext Db
        {
            get
            {
                return DBContextFactory.CreateDbContext();
            }
        }
        private IUserInfoDal _userInfoDal;
        public IUserInfoDal UserInfoDal
        {
            get
            {
                if (_userInfoDal == null)
                {
                    //_userInfoDal = new UserInfoDal;
                    //通过抽象工厂封装了类的实例的创建
                    _userInfoDal = AbstractFactory.CreateUserInfoDal();
                }
                return _userInfoDal;
            }
            set
            {
                _userInfoDal = value;
            }
        }
        /// <summary>
        /// 一个业务中，经常设计到对多张表的操作，我们希望是连接一次数据库，完成对多张表数据的操作；
        /// 保存数据(所有的)
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return Db.SaveChanges() > 0;
        }
    }
}
