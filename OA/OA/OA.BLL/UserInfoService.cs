using OA.IBLL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.BLL
{
    public class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDBSession.UserInfoDal;
        }

        public void SetUserInfo(UserInfo userInfo)
        {
            this.CurrentDBSession.UserInfoDal.AddEntity(userInfo);
            this.CurrentDBSession.UserInfoDal.EditEntity(userInfo);
            this.CurrentDBSession.UserInfoDal.DeleteEntity(userInfo);
            //保存
            this.CurrentDBSession.SaveChanges();
        }
    }
}
