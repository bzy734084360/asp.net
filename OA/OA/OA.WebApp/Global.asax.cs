using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OA.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                Exception ex = Server.GetLastError();
                //DIY.Util.LogHelper.AddErrorLog(ex.ToString());
                if (ex is HttpException)
                {
                    var statusCode = ((HttpException)ex).GetHttpCode();
                    //LogHelper.AddErrorLog("发生错误★：" + statusCode.ToString() + "" + Request.RawUrl + "★" + Request.Url.ToString() + ex.Message + ex.StackTrace + ",引发异常的方法：" + ex.TargetSite + "\r\n");
                    if (statusCode == 404)
                    {
                        ErrorCommon.ErrorSkip(Response, 404, Server);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
