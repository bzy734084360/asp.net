<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProObject.EFDemo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="查询" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="Linq测试" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" Text="删除" OnClick="Button4_Click" />
            <asp:Button ID="Button5" runat="server" Text="更新" OnClick="Button5_Click" style="height: 21px" />
        </div>
    </form>
</body>
</html>
