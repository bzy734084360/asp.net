<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxPostDemo.aspx.cs" Inherits="Project.WebApp.Ajax.AjaxPostDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../JQuery/jquery-3.4.1.js"></script>
    <script>
        $(function () {
            $('#btnPost').click(function () {
                //通过AJAX 向服务器发送请求
                var xhr = new XMLHttpRequest;
                if (XMLHttpRequest) {//表示用户使用的高版本IE,谷歌,火狐等浏览器
                    xhr = new XMLHttpRequest;
                }
                else {//低IE（可以不使用，现浏览器版本已经为高版本IE）
                    xhr = new ActiveXObject("Miscrosoft.XMLHTTP");
                }
                xhr.open("post", "GetDate.ashx", true);
                //设置发送格式
                xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                xhr.send("name=张三&pwd=123");
                xhr.onreadystatechange = function () {
                    if (xhr.readyState == 4) {
                        if (xhr.status == 200) {
                            alert(xhr.responseText);
                        }
                    }
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" id="btnPost" value="获取数据" />
        </div>
    </form>
</body>
</html>
