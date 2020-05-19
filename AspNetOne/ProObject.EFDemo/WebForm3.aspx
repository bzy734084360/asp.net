<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="ProObject.EFDemo.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" Text="查询部分列" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Height="21px" OnClick="Button2_Click" Text="Lambda查询" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="拓展方法" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="接口的区别" />
        <div>
        </div>
    </form>
</body>
</html>
