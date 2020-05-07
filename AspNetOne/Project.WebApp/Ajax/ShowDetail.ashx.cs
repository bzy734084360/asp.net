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
    /// ShowDetail 的摘要说明
    /// </summary>
    public class ShowDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            UserInfoService userInfoService = new UserInfoService();
            UserInfo userInfo = userInfoService.GetUserInfoModel(Convert.ToInt32(context.Request["id"]));
            JavaScriptSerializer js = new JavaScriptSerializer();
            context.Response.Write(js.Serialize(userInfo));
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