using Project.BLL;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.WebApp.Cache
{
    public partial class ShowDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["id"]);
            UserInfoService userInfoService = new UserInfoService();
            UserInfo userInfo = userInfoService.GetUserInfoModel(id);
            List<UserInfo> list = new List<UserInfo>();
            list.Add(userInfo);
            this.DetailsView1.DataSource = list;
            this.DetailsView1.DataBind();
        }
    }
}