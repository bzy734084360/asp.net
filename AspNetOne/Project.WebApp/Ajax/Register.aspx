<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Project.WebApp.Ajax.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../JQuery/jquery-3.4.1.js"></script>
    <script>
        $(function () {
            $("#idTxtName").blur(function () {
                var userName = $(this).val();
                if (userName != "") {
                    $("#idSpanName").text("");
                    $.ajax({
                        type: "POST",
                        url: "CheckUserName.ashx",
                        data: { "name": userName },
                        success: function (data) {
                            if (data == "此用户名已存在!") {
                                $("#idSpanName").css("color", "red");
                            }
                            else {
                                $("#idSpanName").css("color", "green");
                            }
                            $("#idSpanName").text(data);
                        }
                    }
                    );
                }
                else {
                    $("#idSpanName").css("color", "red");
                    $("#idSpanName").text("用户名不能为空！");
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            用户名：<input type="text" name="txtName" id="idTxtName" /><span style="font-size: 14px; color: red" id="idSpanName"></span>
            <br />
            密码：<input type="password" name="txtPwd" />
            <br />
            <input type="submit" value="注册" />
        </div>
    </form>
</body>
</html>
