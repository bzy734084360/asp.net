<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ProObject.EFDemo.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="添加客户" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="查询" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="输出某个人的订单" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="根据订单号查询用户" />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="删除某个用户下的所有订单" />
        </div>

    </form>
</body>
</html>
