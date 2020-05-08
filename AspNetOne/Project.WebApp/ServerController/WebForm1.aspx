<%@ Page Title="" Language="C#" MasterPageFile="~/ServerController/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Project.WebApp.ServerController.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function showResult() {
            document.getElementById(<%=TextBox1.ClientID%>).value;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    aspx页面
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</asp:Content>
