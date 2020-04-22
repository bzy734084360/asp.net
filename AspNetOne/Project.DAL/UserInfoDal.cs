using Project.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL
{
    public class UserInfoDal
    {
        public List<UserInfo> GetList()
        {
            string sql = "select *from UserInfo";
            DataTable table = SqlHelper.GetDataTable(sql, System.Data.CommandType.Text);
            List<UserInfo> list = null;
            if (table.Rows.Count > 0)
            {
                list = new List<UserInfo>();
                UserInfo userInfo = null;
                foreach (DataRow item in table.Rows)
                {
                    userInfo = new UserInfo();
                    LoadEntity(item, userInfo);
                    list.Add(userInfo);
                }
            }
            return list;
        }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        public int AddUserInfo(UserInfo userInfo)
        {
            string sql = "insert into UserInfo (UserName,UserPwd,Regdate) values(@UserName,@UserPwd,@RegDate)";
            SqlParameter[] pars = {
                new SqlParameter("@UserName", SqlDbType.NVarChar, 32),
                new SqlParameter("@UserPwd", SqlDbType.NVarChar, 32),
                new SqlParameter("@RegDate", SqlDbType.DateTime),
            };
            pars[0].Value = userInfo.UserName;
            pars[1].Value = userInfo.UserPwd;
            pars[2].Value = userInfo.RegDate;
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }
        /// <summary>
        /// 根据编号删除用户记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteUserInfoModel(int id)
        {
            string sql = $"delete from userInfo where Userid=@Id";
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, new SqlParameter("@Id", id));
        }
        /// <summary>
        /// 根据用户编号查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfo GetUserInfoModel(int id)
        {
            string sql = "select *from userinfo where UserId=@Id";
            UserInfo userInfo = null;
            DataTable tb = SqlHelper.GetDataTable(sql, CommandType.Text, new SqlParameter("@Id", id));
            if (tb.Rows.Count > 0)
            {
                userInfo = new UserInfo();
                LoadEntity(tb.Rows[0], userInfo);
            }
            return userInfo;
        }

        public int EditUserInfoModel(UserInfo userInfo)
        {
            string sql = "update userinfo set userPwd=@userPwd,userName=@userName,regDate=@regDate where userId=@userId";
            SqlParameter[] pars = {
                new SqlParameter("@userName", SqlDbType.NVarChar, 32),
                new SqlParameter("@userPwd", SqlDbType.NVarChar, 32),
                new SqlParameter("@regDate", SqlDbType.DateTime),
                new SqlParameter("@userId", SqlDbType.Int),
            };
            pars[0].Value = userInfo.UserName;
            pars[1].Value = userInfo.UserPwd;
            pars[2].Value = userInfo.RegDate;
            pars[3].Value = userInfo.UserId;
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }

        private void LoadEntity(DataRow item, UserInfo userInfo)
        {
            userInfo.UserId = Convert.ToInt32(item["UserId"]);
            userInfo.UserName = item["UserName"] != DBNull.Value ? item["UserName"].ToString() : string.Empty;
            userInfo.UserPwd = item["UserPwd"] != DBNull.Value ? item["UserPwd"].ToString() : string.Empty;
            userInfo.RegDate = Convert.ToDateTime(item["RegDate"]);
        }
    }
}
