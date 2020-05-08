using Project.BLL;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.WebApp.ServerController
{
    public partial class Index : System.Web.UI.Page
    {
        public string MyProperty { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfoService userInfoService = new UserInfoService();
            List<UserInfo> list = userInfoService.GetList();
            StringBuilder sb = new StringBuilder();

            foreach (UserInfo item in list)
            {
                sb.Append($"<option value='{item.UserName}' >{item.UserName}</option>");
            }
            MyProperty = sb.ToString();

        }
    }
}