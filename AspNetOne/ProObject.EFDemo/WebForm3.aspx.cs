using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProObject.EFDemo
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //查询部分列
            //通过在select中加入匿名类
            StudyEntities db = null;
            if (HttpContext.Current.Items["db"] == null)
            {
                db = new StudyEntities();
                HttpContext.Current.Items["db"] = db;
            }
            else
            {
                db = HttpContext.Current.Items["db"] as StudyEntities;
            }
            var userInfoList = from u in db.UserInfo
                               where u.UserId == 1039
                               select new { UName = u.UserName, UPwd = u.UserPwd };
            foreach (var item in userInfoList)
            {
                Response.Write(item.UName);
                //Response.Write(UserInfo.)
            }
        }
        /// <summary>
        /// 分页排序查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            StudyEntities db = new StudyEntities();
            int pageIndex = 2;
            int pageSize = 2;
            //排序OrderBy 分页 Skip(跳过几条数据)Take(取出几条数据)
            var userInfoList = db.UserInfo.Where(t => t.UserId > 0).OrderByDescending(u => u.UserId).ThenByDescending(t => t.UserPwd).Skip((pageIndex - 1) * pageIndex).Take(pageSize);

            //var userInfoList = (from u in db.UserInfo
            //                    where u.UserId > 0
            //                    orderby u.UserId ascending//descending降序
            //                    select u).Skip((pageIndex - 1) * pageIndex).Take(pageSize);//分页与lambda表达式一样的处理
            foreach (var item in userInfoList)
            {
                Response.Write(item.UserName);
            }
        }
        /// <summary>
        /// 拓展方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            string str = "tttt";
            Response.Write(str.MyStr());
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            StudyEntities db = new StudyEntities();
            var userInfoList = db.UserInfo.Where(u => u.UserId > 0).ToList();
            int i = 0;
            int count = userInfoList.Count();
            Response.Write(count);
        }
    }
}