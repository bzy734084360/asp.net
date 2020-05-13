using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProObject.EFDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //新增
            UserInfo userInfo = new UserInfo();
            userInfo.UserName = "EF新增";
            userInfo.UserPwd = "123456";
            userInfo.RegDate = DateTime.Now;
            StudyEntities db = new StudyEntities();
            //将数据添加到EF 并且添加了添加标记(Add)
            db.UserInfo.Add(userInfo);
            //更新到数据库
            //返回受影响的行数
            db.SaveChanges();
            Response.Write(userInfo.UserId);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //查询
            StudyEntities studyEntities = new StudyEntities();
            //linq表达式
            var userInfoList = from u in studyEntities.UserInfo
                               where u.UserId == 1166
                               select u;
            int i = 0;
            //延迟加载机制 数据使用到的时候吗，才会进行查询，否则不会进行查询
            foreach (var item in userInfoList)
            {
                Response.Write(item.UserName);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };
            var listInfo = from u in list
                           where u > 3
                           select u;
            foreach (var item in listInfo)
            {
                Response.Write(item);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button4_Click(object sender, EventArgs e)
        {
            StudyEntities studyEntities = new StudyEntities();
            //var userInfoList = from u in studyEntities.UserInfo
            //                   where u.UserId == 1166
            //                   select u;
            //UserInfo userInfo = userInfoList.FirstOrDefault();//返回第一个元素，如果没有则返回NULL
            //if (userInfo != null)
            //{
            //    //studyEntities.UserInfo.Remove(userInfo);
            //    studyEntities.Entry<UserInfo>(userInfo).State = EntityState.Deleted;
            //    studyEntities.SaveChanges();
            //}
            //else
            //{
            //    Response.Write("删除的数据不存在");
            //}
            //若要用Remove 则UserInfo对象需从EF中获取才可用；
            //而通过设置State的方式则不需要如此；
            UserInfo userInfo = new UserInfo() { UserId = 1162 };
            //studyEntities.UserInfo.Remove(userInfo);
            studyEntities.Entry<UserInfo>(userInfo).State = EntityState.Deleted;
            studyEntities.SaveChanges();

        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button5_Click(object sender, EventArgs e)
        {
            StudyEntities db = new StudyEntities();
            var userInfoList = from u in db.UserInfo
                               where u.UserId == 1163
                               select u;
            var userInfo = userInfoList.FirstOrDefault();
            userInfo.UserPwd = "666666";
            db.Entry<UserInfo>(userInfo).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}