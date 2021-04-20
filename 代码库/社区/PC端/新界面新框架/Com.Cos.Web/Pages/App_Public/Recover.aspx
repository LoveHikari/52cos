<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="Recover.aspx.cs" Inherits="Com.Cos.Web.Pages.App_Public.Recover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="/plugins/sweetalert/sweetalert.min.js"></script>
    <link href="/plugins/sweetalert/sweetalert.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="g page page-id-8 page-template page-template-page-sign page-template-page-sign-php singular">
        <div id="main" class="main">
            <div class="panel mx-sign-panel mx-sign-panel-recover">
                <div class="heading">
                    <h3>找回密码</h3>
                </div>

                <div class="content">
                    <form action="/Service/App_Public/RecoverPassword.ashx" id="fm-sign-recover" method="post">
                        <div class="form-group">如果您忘记了账号密码，您可以通过账号邮箱来重置密码。请输入您的账号邮箱，我们将会发送一封确认邮件，并根据提示重置您的密码。</div>
                        <div class="form-group">
                            <div class="input-group">
                                <label for="sign-email" class="addon"><i class="fa fa-at fa-fw"></i></label>
                                <input type="email" name="user[email]" id="sign-email" class="form-control" title="请输入 Email" required tabindex="1" autofocus placeholder="请输入 Email">
                            </div>
                        </div>
                        <div class="form-group form-group-submit">
                            <button type="submit" class="btn btn-success btn-block btn-lg submit" tabindex="1" data-loading-text="邮件发送中，请稍等……">
                                <i class="fa fa-send"></i>
                                发送邮件以确认
                            </button>
                            <input type="hidden" name="type" value="recover">
                        </div>
                        <div class="form-group">
                            <a href="/Pages/App_Public/Login.aspx"><i class="fa fa-angle-double-left"></i>返回到登录页面</a>
                        </div>
                    </form>
                </div>
                <!-- .content -->
            </div>
            <!-- .panel -->

            <div class="open-login form-group row">
                <div class="g-phone-1-2">
                    <a href="http://www.91moe.com/wp-admin/admin-ajax.php?action=theme_open_sign&sign-type=qq&redirect=%252F%252Fwww.91moe.com%252F" title="QQ 登录" class="btn btn-block btn-primary">
                        <i class="fa fa-qq fa-fw"></i>QQ 登录				</a>
                </div>
                <div class="g-phone-1-2">
                    <a href="http://www.91moe.com/wp-admin/admin-ajax.php?action=theme_open_sign&sign-type=sina&redirect=%252F%252Fwww.91moe.com%252F" title="微博登录" class="btn btn-block btn-danger">
                        <i class="fa fa-weibo fa-fw"></i>微博登录				</a>
                </div>
                <div class="g-phone-1-2">
                    <a href="http://www.91moe.com/wp-admin/admin-ajax.php?action=theme_open_sign&sign-type=gg&redirect=%252F%252Fwww.91moe.com%252F" title="Google 登录" class="btn btn-block btn-info">
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
            $('#fm-sign-recover').bind('submit', function () {
                var $logbut = $("button", this);
                var submit_loading_tx = $logbut.attr("data-loading-text");
                $logbut.html(submit_loading_tx);
                $logbut.attr("disabled", !0);
                ajaxSubmit(this, function (data) {
                    if (data == "2") {
                        swal("小2提醒您", "邮箱发生失败，请联系管理员", "error");
                    } else if (data == "True") {
                        swal("成功", "我们已发送了一封包括如何找回密码的邮件，请您在 3 小时内查收。", "success");
                    } else {
                        swal("小2提醒您", "邮箱不存在或未激活", "error");
                        $logbut.html("<i class='fa fa-send'></i>发送邮件以确认");
                        $logbut.attr("disabled", !!0);
                    }
                }, function () {
                    swal("小2提醒您", "系统繁忙，请稍后再试", "error");
                    $logbut.html("<i class='fa fa-send'></i>发送邮件以确认");
                    $logbut.attr("disabled", !!0);
                });
                return false;
            });
        });
    </script>
</asp:Content>
