using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Project.Common
{
    public class ValidateSessionHttpModule : IHttpModule
    {
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += Context_AcquireRequestState;
        }

        private void Context_AcquireRequestState(object sender, EventArgs e)
        {
            //判断相应的文件；
            HttpApplication application = sender as HttpApplication;
            HttpContext context = application.Context;//获取当前的HttpContext；
            string url = context.Request.Url.ToString();//获取用户请求的Url地址
            if (url.Contains("Admin"))
            {
                if (context.Session["userInfo"] == null)
                {
                    context.Response.Redirect("/SessionDemo/UserLogin.aspx");
                }
            }

            //HttpContext context = new HttpContext();
        }
    }
}
