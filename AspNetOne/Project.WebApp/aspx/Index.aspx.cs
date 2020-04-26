using Project.BLL;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.WebApp.aspx
{
    public partial class Index : System.Web.UI.Page
    {
        public string StrHtml { get; set; }

        public List<UserInfo> UserInfoList { get; set; }
        /// <summary>
        /// 页面加载完后的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfoService userInfoService = new UserInfoService();
            List<UserInfo> list = userInfoService.GetList();
            //1、第一种方式加载数据
            //StringBuilder sb = new StringBuilder();

            //foreach (UserInfo item in list)
            //{
            //    sb.Append($"<tr><td>{item.UserId}</td><td>{item.UserName}</td><td>" +
            //   $"{item.UserPwd}</td><td>{item.RegDate.ToString("yyyy-MM-dd")}</td>" +
            //   $"<td><a href='/UserInfoDetail.ashx?id={item.UserId}'>详细</a></td>" +
            //   $"<td><a href='/UserInfoUpdate.ashx?id={item.UserId}&type=1'>修改</a></td>" +
            //   $"<td><a href='/DeleteUserInfo.ashx?id={item.UserId}' class='deletes'>删除</a></td></tr>");
            //}
            //StrHtml = sb.ToString();
            //2、第二种方式加载数据
            UserInfoList = list;
        }
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {

        }
    }
}