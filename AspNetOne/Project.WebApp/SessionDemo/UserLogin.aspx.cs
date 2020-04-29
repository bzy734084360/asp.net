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
                //判断Cookie中的值
                CheckCookieInfo();
            }
        }
        /// <summary>
        /// 校验Cookie信息
        /// </summary>
        private void CheckCookieInfo()
        {
            if (Request.Cookies["cp1"] != null && Request.Cookies["cp2"] != null)
            {
                string userName = Request.Cookies["cp1"].Value;
                string userPwd = Request.Cookies["cp2"].Value;
                UserInfoService userInfoService = new UserInfoService();
                UserInfo info = userInfoService.GetUserInfoModel(userName);
                if (info != null)
                {
                    //注意：注册账号时，需加密后保存。
                    if (userPwd == Common.WebCommon.GetMd5String(Common.WebCommon.GetMd5String(info.UserPwd.Trim())))
                    {
                        Session["userinfo"] = info;
                        Response.Redirect("userInfoLogin.aspx");
                    }
                }
                //若Cookie 被篡改，或不匹配，则清空Cookie 重新登录
                Response.Cookies["cp1"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["cp2"].Expires = DateTime.Now.AddDays(-1);
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
                //自动登录，判断用户是否选择自动登录
                if (!string.IsNullOrEmpty(Request.Form["autoLogin"]))//页面上有多个复选框时，只能将选中的复选框的值提交到服务端
                {
                    HttpCookie cookie1 = new HttpCookie("cp1", userName);
                    HttpCookie cookie2 = new HttpCookie("cp2", Common.WebCommon.GetMd5String(Common.WebCommon.GetMd5String(userPwd)));
                    cookie1.Expires = DateTime.Now.AddDays(7);
                    cookie2.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(cookie1);
                    Response.Cookies.Add(cookie2);
                }
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