using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.WebApp.Cache
{
    public partial class FileCacheDep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filePath = Request.MapPath("File.txt");
            if (Cache["fileContent"] == null)
            {
                string fileContent = File.ReadAllText(filePath);
                //缓存依赖
                CacheDependency cDep = new CacheDependency(filePath);
                Cache.Insert("fileContent", fileContent, cDep);
                Response.Write("数据来自于文件");
            }
            else
            {
                Response.Write("数据来自于缓存" + Cache["fileContent"].ToString());
            }
        }
    }
}