using Project.BLL;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.WebApp.Cache
{
    public partial class CacheDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断缓存中是否有数据
            if (Cache["userInfoList"] == null)
            {
                UserInfoService userInfoService = new UserInfoService();
                List<UserInfo> list = userInfoService.GetList();
                //将数据放到缓存中
                //Cache["userInfoList"] = list;
                //CacheDependency 参数 缓存依赖项，监测数据是否有改变， DateTime 和TimeSpan 参数只能二选一
                Cache.Insert("userInfoList", list, null, DateTime.Now.AddSeconds(5), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, RemoveCache);
                Response.Write("数据来自数据库");
                //强制移除缓存
                //Cache.Remove("userInfoList");
            }
            else
            {
                List<UserInfo> list = Cache["userInfoList"] as List<UserInfo>;
                Response.Write("数据来自于缓存");
            }
        }
        //移除缓存时，调用方法
        protected void RemoveCache(string key, object value, CacheItemRemovedReason reason)
        {
            if (reason == CacheItemRemovedReason.Expired)
            {
                //缓存移除的原因，写到日志中；

            }
        }
    }
}