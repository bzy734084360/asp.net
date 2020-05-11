using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Project.WebApp
{
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Web应用程序第一次启动时调用该方法。并且该方法只被调用一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Start(object sender, EventArgs e)
        {
            //启动定时任务框架；
        }
        /// <summary>
        /// 开始会话
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_Start(object sender, EventArgs e)
        {
            //Application 服务端的状态保持机制 放在该对象中的数据是共享的；Cache
            //使用则必须加锁解锁；
            Application.Lock();
            int count = Convert.ToInt32(Application["count"]);
            count++;
            Application["count"] = count;
            Application.UnLock();
            //最好保存到数据库或文件中；
        }
        /// <summary>
        /// 管道第一事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 全局的异常处理点。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            //在此捕获异常；
            Exception exception = HttpContext.Current.Server.GetLastError();
            //写到日志中；

        }
        /// <summary>
        /// 会话结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            int count = Convert.ToInt32(Application["count"]);
            count--;
            Application["count"] = count;
            Application.UnLock();
        }
        /// <summary>
        /// 应用程序结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}