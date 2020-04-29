using CZBK.ItcastProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Project.WebApp.SessionDemo
{
    /// <summary>
    /// ValidateImageCode 的摘要说明
    /// </summary>
    public class ValidateImageCode : IHttpHandler, IRequiresSessionState
    {
        //一般处理程序中 如果使用Session 必须实现IRequiresSessionState
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            ValidateCode code = new ValidateCode();
            string str = code.CreateValidateCode(4);
            context.Session["validateCode"] = str;
            code.CreateValidateGraphic(str, context);
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