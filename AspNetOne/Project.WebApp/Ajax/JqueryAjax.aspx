<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JqueryAjax.aspx.cs" Inherits="Project.WebApp.Ajax.JqueryAjax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../JQuery/jquery-3.4.1.js"></script>
    <script>
        $(function () {
            $("#btnGet").click(function () {
                $.get("GetDate.ashx", { "name": "李四", "pwd": "123" }, function (data) {
                    alert(data);
                });
            });
            $("#btnPost").click(function () {
                $.post("GetDate.ashx", { "name": "李四", "pwd": "123" }, function (data) {
                    alert(data);
                });
            });
            $("#btnAjax").click(function () {
                $.ajax({
                    type: "POST",
                    url: "GetDate.ashx",
                    data: { "name": "李四", "pwd": "123" },
                    success: function (data) {
                        alert(data);
                    }
                });
            });
            $("#btnAjaxAspx").click(function () {
                $.post("ShowDate.aspx", { "name": "李四", "pwd": "123" }, function (data) {
                    alert(data);
                });
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" name="name" value="获取数据" id="btnGet" />
            <input type="button" name="name" value="Post获取数据" id="btnPost" />
            <input type="button" name="name" value="AJAX获取数据" id="btnAjax" />
            <input type="button" name="name" value="AJAX访问aspx页面" id="btnAjaxAspx" />
        </div>
    </form>
</body>
</html>
