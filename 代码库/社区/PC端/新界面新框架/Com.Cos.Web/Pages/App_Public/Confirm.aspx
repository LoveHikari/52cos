<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="Com.Cos.Web.Pages.App_Public.Confirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/plugins/sweetalert/sweetalert.min.js"></script>
    <link href="/plugins/sweetalert/sweetalert.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 40px;"></div>
    <div style="width: 600px; margin: 0 auto;">
        <div class="box10 boxshow boxHack gpd1 msgbox">
            <div class="sdload"></div>
            <p id="cont" runat="server">登录成功，正在跳转，请稍后...</p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>
        function js_method() {
            $.get("/Service/App_Public/SendEmail.ashx", {code: <%=code %>}, function (res) {
                if (res == "True") {
                    swal({
                        title: "发送成功!",
                        text: '3秒后自动跳转<br/>或者<a href="/Pages/App_public/Index.aspx">点击这里跳转</a>',
                        html: true,
                        timer: 3000,
                        showConfirmButton: false
                    });
                    window.location.href = "/Pages/App_public/Index.aspx";
                } else {
                    swal("小2提醒您", "发送失败，请重试！", "error");
                }
            }).error(function(){swal("小2提醒您", "系统繁忙，请稍后再试！", "error");});
        }
    </script>
</asp:Content>
