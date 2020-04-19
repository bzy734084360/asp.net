using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01IIS运用
{
    /// <summary>
    /// Accept 的摘要说明
    /// </summary>
    public class Accept : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //接收表单提交过来的数据
            //若以POST方式提交，则接收表单数据时需要用到context.Request.Form
            string userName = context.Request.Form["txtName"];
            //get接收方式
            string userPwd = context.Request.QueryString["txtPwd"];
            context.Response.Write($"输入的用户名:{userName} \n输入的密码：{userPwd}");
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