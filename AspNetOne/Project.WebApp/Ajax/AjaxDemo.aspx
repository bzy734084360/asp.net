<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxDemo.aspx.cs" Inherits="Project.WebApp.Ajax.AjaxDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../JQuery/jquery-3.4.1.js"></script>
    <script>
        $(function () {
            $('#btnGetDate').click(function () {
                //通过AJAX 向服务器发送请求
                var xhr = new XMLHttpRequest;
                if (XMLHttpRequest) {//表示用户使用的高版本IE,谷歌,火狐等浏览器
                    xhr = new XMLHttpRequest;
                }
                else {//低IE（可以不使用，现浏览器版本已经为高版本IE）
                    xhr = new ActiveXObject("Miscrosoft.XMLHTTP");
                }
                //参数：请求方式，请求地址，是否异步
                xhr.open("get", "GetDate.ashx?name=XXX&age=12", true);
                xhr.send();//开始发送
                //回调函数：当服务器将数据返回给浏览器后，自动调用该方法
                xhr.onreadystatechange = function () {
                    //指出了对象在发送/接收数据过程中所处的几个状态 4：表示服务端已经将数据完整返回，并且浏览器全部接收完毕
                    if (xhr.readyState == 4) {
                        //判断服务端返回的响应状态码
                        if (xhr.status == 200) {
                            alert(xhr.responseText);
                        }
                    }
                };
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" value="获取服务端时间" id="btnGetDate" />
        </div>
    </form>
</body>
</html>
