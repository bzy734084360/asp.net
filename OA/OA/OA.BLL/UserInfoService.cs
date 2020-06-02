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
        /// <summary>
        /// 批量删除多条用户数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteEntities(List<int> list)
        {
            //判断ID 是否在集合中存在，如果存在则查询出来
            var userInfoList = this.CurrentDBSession.UserInfoDal.LoadEntities(u => list.Contains(u.ID));
            foreach (var userInfo in userInfoList)
            {
                this.CurrentDBSession.UserInfoDal.DeleteEntity(userInfo);
            }
            return this.CurrentDBSession.SaveChanges();
        }

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
