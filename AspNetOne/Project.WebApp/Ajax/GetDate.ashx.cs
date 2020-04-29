using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebApp.Ajax
{
    /// <summary>
    /// GetDate 的摘要说明
    /// </summary>
    public class GetDate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write(context.Request.QueryString["name"]);
            //context.Response.Write(context.Request.Form["name"]);
            //此方式会自动判断，请求方式
            context.Response.Write(context.Request["name"]);
            context.Response.Write(DateTime.Now.ToString());
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