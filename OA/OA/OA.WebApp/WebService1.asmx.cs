using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace OA.WebApp
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string Add(int a, int b)
        {
            return (a + b).ToString();
        }
        [WebMethod]
        public string LoadUserInfoList()
        {
            IBLL.IUserInfoService userInfoService = new BLL.UserInfoService();
            List<Model.UserInfo> list = userInfoService.LoadEntities(u => true).ToList();
            return "序列化的数据";
        }

    }
}
