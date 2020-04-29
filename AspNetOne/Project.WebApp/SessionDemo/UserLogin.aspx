<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="Project.WebApp.SessionDemo.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../JQuery/jquery-3.4.1.js"></script>
    <script>    
        $(function () {
            $('#imageCode').click(function () {
                $('#imageCode').attr("src", "ValidateImageCode.ashx?d=" + new Date().getMilliseconds());
            })
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            用户名：<input type="text" name="txtName" />
            <br />
            密码：<input type="password" name="txtPwd" />
            <br />
            验证码:<input type="text" name="txtCode" />
            <img src="ValidateImageCode.ashx" id="imageCode" />
            <br />
            <input type="checkbox" name="autoLogin" value="auto" />自动登录
            <br />
            <input type="submit" value="登录" /><span style="font-size: 14px; color: red"><%=Msg %></span>
        </div>
    </form>
</body>
</html>
