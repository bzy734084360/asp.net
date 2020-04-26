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
    public partial class NewList : System.Web.UI.Page
    {
        /// <summary>
        /// 加载列表内容
        /// </summary>
        public string StrHtml { get; set; }
        /// <summary>
        /// 最大页数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public string PageBar { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{

            //}
            //每页条数
            int pageSize = 5;//每页显示10条记录
            int pageIndex;//当前页码值
            if (!int.TryParse(Request.QueryString["pageIndex"], out pageIndex))
            {
                pageIndex = 1;
            }
            UserInfoService userInfoService = new UserInfoService();
            int pageCount = userInfoService.GetPageCount(pageSize);
            PageCount = pageCount;
            //pageIndex = pageIndex < 1 ? 1 : pageIndex;
            //pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            PageIndex = pageIndex;
            List<UserInfo> list = userInfoService.GetPageList(pageIndex, pageSize);
            StringBuilder sb = new StringBuilder();
            foreach (UserInfo item in list)
            {
                sb.Append($"<li><span>{item.RegDate}</span><a href=\"Shownews.html\" target=\"_blank\">{item.UserName}-{item.UserPwd}</a></li>");
            }
            StrHtml = sb.ToString();
            PageBar = Common.PageBar.GetPageBar(pageIndex, pageCount);
        }
    }
}