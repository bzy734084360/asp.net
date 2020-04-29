using Project.DAL;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL
{
    public class UserInfoService
    {
        UserInfoDal UserInfoDal = new UserInfoDal();

        public List<UserInfo> GetList()
        {
            return UserInfoDal.GetList();
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        public bool AddUserInfo(UserInfo userInfo)
        {
            return UserInfoDal.AddUserInfo(userInfo) > 0;
        }
        /// <summary>
        /// 根据编号删除用户记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteUserInfo(int id)
        {
            return UserInfoDal.DeleteUserInfoModel(id) > 0;
        }
        /// <summary>
        /// 根据用户编号，查询用户的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfo GetUserInfoModel(int id)
        {
            return UserInfoDal.GetUserInfoModel(id);
        }
        /// <summary>
        /// 根据用户编号，修改用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool EditUserInfoMode(UserInfo userInfo)
        {
            return UserInfoDal.EditUserInfoModel(userInfo) > 0;
        }
        /// <summary>
        /// 获取总的记录数
        /// </summary>
        /// <param name="pageSize">每页显示记录数</param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            //获取总记录数
            int recordCount = UserInfoDal.GetRecordCount();
            //总页数
            //int pageCount = recordCount % pageSize > 0 ? recordCount / pageSize + 1 : recordCount / pageSize;
            int pageCount = (int)Math.Ceiling((double)recordCount / pageSize);
            return pageCount;
        }
        /// <summary>
        /// 获取指定范围内的数据
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <returns></returns>
        public List<UserInfo> GetPageList(int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            return UserInfoDal.GetPageList(start, end);
        }
        /// <summary>
        /// 完成用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">用户密码</param>
        /// <param name="msg">登录信息</param>
        /// <param name="userInfo">登录用户信息</param>
        /// <returns></returns>
        public bool ValidateUserInfo(string userName, string userPwd, out string msg, out UserInfo userInfo)
        {
            userInfo = UserInfoDal.GetUserInfoModel(userName);
            if (userInfo != null)
            {
                if (userInfo.UserPwd.Trim() == userPwd)
                {
                    msg = "登录成功！";
                    return true;
                }
                else
                {
                    msg = "用户名或密码错误！";
                }
            }
            else
            {
                msg = "没有此用户！";
            }
            return false;
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>

        public UserInfo GetUserInfoModel(string userName)
        {
            return UserInfoDal.GetUserInfoModel(userName);
        }
    }
}
