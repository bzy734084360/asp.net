using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebApp.JSON
{
    /// <summary>
    /// GetJson 的摘要说明
    /// </summary>
    public class GetJson : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("{\"Name\":\"张三\",\"Age\":\"12\"}");
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