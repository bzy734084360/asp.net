<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServerDemo.aspx.cs" Inherits="Project.WebApp.Request与Response其他成员.ServerDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            主页面
            <%--主页面
            <% Server.Execute("Child.aspx"); %>--%>
            <%--白帽
            黑帽--%>
            <%//Server.Transfer("Child.aspx"); %>
            <%=Server.HtmlEncode("<font color='red'>啊</font>") %>
            <%=Server.HtmlDecode("<font color='red'>啊</font>") %>
            <a href="aa.aspx?a=<%=Server.UrlEncode("sss")%>">测试连接</a>
        </div>
    </form>
</body>
</html>
