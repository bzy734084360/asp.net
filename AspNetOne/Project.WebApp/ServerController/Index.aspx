<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project.WebApp.ServerController.Index" EnableViewState="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script>    
        function myfunction() {
            document.getElementById("TextBox1").value;
        }
    </script>
    <style>
        .txt {
            font-size: 20px;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="txt"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Button" Visible="true" CssClass="txt" />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </div>
        <select name="UserInfos">
            <%=MyProperty %>
        </select>
    </form>
</body>
</html>
