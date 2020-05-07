using Project.BLL;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Project.WebApp.Ajax
{
    /// <summary>
    /// UserAjaxList 的摘要说明
    /// </summary>
    public class UserAjaxList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int pageIndex;
            if (!int.TryParse(context.Request["pageIndex"], out pageIndex))
            {
                pageIndex = 1;
            }
            int pageSize = 5;

            UserInfoService userInfoService = new UserInfoService();
            int pageCount = userInfoService.GetPageCount(pageSize);
            //判断当前页码之的取值范围
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            //获取分页数据
            List<UserInfo> list = userInfoService.GetPageList(pageIndex, pageSize);
            //获取页码条
            string pageBar = Common.PageBar.GetPageBar(pageIndex, pageCount);
            JavaScriptSerializer js = new JavaScriptSerializer();
            //匿名类
            context.Response.Write(js.Serialize(new { UList = list, MyPageBar = pageBar }));//将数据序列化成JSON字符串
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}