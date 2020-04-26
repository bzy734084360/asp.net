<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Project.WebApp.aspx.Index" %>

<%@ Import Namespace="Project.Model" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../JQuery/jquery-3.4.1.js"></script>
    <script>
        $(function () {
            $(".deletes").click(function () {
                if (!confirm("确定要删除该记录吗")) {
                    return false;
                }
            })
        })
    </script>
</head>
<body>
    <a href="AddUserInfo.aspx">添加</a>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <th>编号</th>
                    <th>用户名</th>
                    <th>密码</th>
                    <th>日期</th>
                    <th>详细</th>
                    <th>修改</th>
                    <th>删除</th>
                </tr>
                <%-- 第一种方式获取列表数据 --%>
                <%--<%=StrHtml%><!-- = Response.Write 等价 -->--%>
                <% foreach (UserInfo item in UserInfoList)
                    { %>
                <tr>
                    <td><%=item.UserId %></td>
                    <td><%=item.UserName %></td>
                    <td><%=item.UserPwd %></td>
                    <td><%=item.RegDate %></td>
                    <td>详细</td>
                    <td><a href="EditUserInfo.aspx?id=<%=item.UserId%>">修改</a></td>
                    <td><a href="DeleteUserInfo.ashx?id=<%=item.UserId%>" class="deletes">删除</a></td>
                </tr>
                <%} %>
            </table>
        </div>
    </form>
</body>
</html>
