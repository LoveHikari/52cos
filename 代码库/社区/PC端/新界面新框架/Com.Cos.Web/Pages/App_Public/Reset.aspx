<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="Reset.aspx.cs" Inherits="Com.Cos.Web.Pages.App_Public.Reset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="/plugins/sweetalert/sweetalert.min.js"></script>
    <link href="/plugins/sweetalert/sweetalert.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="g page page-id-8 page-template page-template-page-sign page-template-page-sign-php singular">
        <div id="main" class="main">
            <div id="count" runat="server">
            <div class="panel mx-sign-panel mx-sign-panel-reset">
                <div class="heading">
                    <h3>重置我的密码</h3>
                </div>
                <div class="content">
                    <p>您正在重设 <strong runat="server" id="email"></strong> 的密码，请输入您的新密码。</p>
                    <form action="/Service/App_Public/RebuildPassword.ashx" id="fm-sign-reset" method="post">
                        <div class="form-group">
                            <div class="input-group">
                                <label for="sign-pwd" class="addon"><i class="fa fa-key fa-fw"></i></label>
                                <input type="password" name="user[pwd]" id="sign-pwd" class="form-control" title="输入新密码，至少 5 字符或以上" placeholder="输入新密码，至少 5 字符或以上" pattern=".{5,}" tabindex="1" required autofocus>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <label for="sign-pwd-again" class="addon"><i class="fa fa-key fa-fw"></i></label>
                                <input type="password" name="user[pwd-again]" id="sign-pwd-again" class="form-control" title="确认新密码，至少 5 字符或以上" placeholder="确认新密码，至少 5 字符或以上" required tabindex="1" pattern=".{5,}">
                            </div>
                        </div>
                        <div class="form-group form-group-submit">
                            <button type="submit" class="btn btn-success btn-block btn-lg submit" tabindex="1">
                                <i class="fa fa-check"></i>
                                重设
                            </button>
                            <input type="hidden" name="user[token]" value="<%=token %>">
                            <input type="hidden" name="type" value="reset">
                        </div>
                    </form>
                </div>
            </div>
            </div>
            <div class="open-login form-group row">
                <div class="g-phone-1-2">
                    <a href="http://www.91moe.com/wp-admin/admin-ajax.php?action=theme_open_sign&sign-type=qq" title="QQ 登录" class="btn btn-block btn-primary">
                        <i class="fa fa-qq fa-fw"></i>QQ 登录				</a>
                </div>
                <div class="g-phone-1-2">
                    <a href="http://www.91moe.com/wp-admin/admin-ajax.php?action=theme_open_sign&sign-type=sina" title="微博登录" class="btn btn-block btn-danger">
                        <i class="fa fa-weibo fa-fw"></i>微博登录				</a>
                </div>
                <div class="g-phone-1-2">
                    <a href="http://www.91moe.com/wp-admin/admin-ajax.php?action=theme_open_sign&sign-type=gg" title="Google 登录" class="btn btn-block btn-info">
                        <i class="fa fa-google-plus fa-fw"></i>Google 登录				</a>
                </div>
            </div>
        </div>
        <!-- .main.col-->
    </div>
    <!-- .row -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>
        $(document).ready(function() {
            $('#fm-sign-reset').bind('submit', function () {
                var $logbut = $("button", this);
                $logbut.attr("disabled", !0);
                ajaxSubmit(this, function (data) {
                    if (data == "True") {
                        swal({
                            title: "重设成功!",
                            text: '3秒后自动跳转<br/>或者<a href="/Pages/App_public/Login.aspx">点击这里跳转</a>',
                            html: true,
                            timer: 3000,
                            showConfirmButton: false
                        });
                        window.location.href = "/Pages/App_public/Login.aspx";
                    } else {
                        swal("小2提醒您", "邮箱或密码错误", "error");
                        $logbut.attr("disabled", !!0);
                    }
                }, function () {
                    swal("小2提醒您", "系统繁忙，请稍后再试", "error");
                    $logbut.attr("disabled", !!0);
                });
                return false;
            });
        });
    </script>
</asp:Content>
