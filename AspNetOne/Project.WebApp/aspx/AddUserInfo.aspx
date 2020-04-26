<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUserInfo.aspx.cs" Inherits="Project.WebApp.aspx.AddUserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            用户名:<input type="text" name="txtName" /><br />
            密码：<input type="password" name="txtPwd" /><br />
            <input type="hidden" name="isPostBack" value="1" />
            <input type="submit" value="提交" />
        </div>
    </form>
</body>
</html>
