using Project.BLL;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.WebApp.SessionDemo
{
    public partial class UserLogin : System.Web.UI.Page
    {
        public string Msg { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod.ToLower() == "post")
            {
                //判断验证码是否正确
                if (CheckValidateCode())
                {
                    //判断用户登录信息是否正确
                    CheckUserInfo();
                }
                else
                {
                    //验证码错误
                    if (string.IsNullOrEmpty(Msg)) Msg = "验证码错误！";
                }
            }
            else
            {
                if (Session["userInfo"] != null)
                {
                    Response.Redirect("UserInfoLogin.aspx");
                }
            }
        }

        /// <summary>
        /// 验证用户验证码
        /// </summary>
        /// <returns></returns>
        private bool CheckValidateCode()
        {
            bool isScess = false;
            if (Session["validateCode"] != null)
            {
                Msg = string.Empty;
                //获取用户输入的验证码
                string txtCode = Request.Form["txtCode"];
                //获取系统验证码
                string sys = Session["validateCode"].ToString();
                if (sys.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
                {
                    isScess = true;
                    //成功后要清空Session
                    Session["validateCode"] = null;
                }
            }
            else
            {
                Msg = "验证码已过期,请重新输入！";
            }
            return isScess;
        }
        //验证用户名和密码是否正确
        private void CheckUserInfo()
        {
            //获取用户名密码
            string userName = Request.Form["txtName"];
            string userPwd = Request.Form["txtPwd"];
            //校验用户名密码.
            UserInfoService userInfoService = new UserInfoService();
            string msg = string.Empty;
            UserInfo userInfo = null;
            //判断用户
            if (userInfoService.ValidateUserInfo(userName, userPwd, out msg, out userInfo))
            {
                //将Session赋值
                Session["userInfo"] = userInfo;
                Response.Redirect("UserInfoLogin.aspx");
            }
            else
            {
                Msg = msg;
            }
        }
    }
}