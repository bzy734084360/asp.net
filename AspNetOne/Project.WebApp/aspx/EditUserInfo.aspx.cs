using Project.BLL;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.WebApp.aspx
{
    public partial class EditUserInfo : System.Web.UI.Page
    {
        public UserInfo LoadUserInfo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack || Request.HttpMethod == "Post")
            {
                EditInfo();
            }
            else
            {
                int id;
                if (int.TryParse(Request.QueryString["id"], out id))
                {
                    UserInfoService userInfoService = new UserInfoService();
                    UserInfo userInfo = userInfoService.GetUserInfoModel(id);
                    LoadUserInfo = userInfo;

                }
            }
        }

        private void EditInfo()
        {
            int id;
            if (int.TryParse(Request.Form["txtUserId"], out id))
            {
                UserInfoService userInfoService = new UserInfoService();
                UserInfo userInfo = userInfoService.GetUserInfoModel(id);
                userInfo.UserName = Request.Form["txtName"].ToString();
                userInfo.UserPwd = Request.Form["txtPwd"].ToString();
                if (userInfoService.EditUserInfoMode(userInfo))
                {
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    Response.Redirect("/Error.html");
                }

            }
        }
    }
}