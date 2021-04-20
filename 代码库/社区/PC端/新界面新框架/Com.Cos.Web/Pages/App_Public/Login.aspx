<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Com.Cos.Web.Pages.App_Public.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/plugins/sweetalert/sweetalert.min.js"></script>
    <link href="/plugins/sweetalert/sweetalert.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="g page page-id-8 page-template page-template-page-sign page-template-page-sign-php singular">
        <div id="main" class="main">
            <div class="has-avatar panel mx-sign-panel mx-sign-panel-login tab">
                <div class="heading">
                    <img class="avatar" src="/Upload/Portrait/1.jpg" alt="avatar"/>
                    <div class="tab-heading">
                        <a href="javascript:;" class="tab-title tab-active">登录</a>
                        <a href="javascript:;" class="tab-title">注册</a>
                    </div>
                </div>
                <div class="content">
                    <form action="/Service/App_Public/LoginValidate.ashx" id="fm-sign-login" class="tab-body tab-active" method="post">
                        <div class="form-group">
                            <div class="input-group">
                                <label for="sign-email" class="addon"><i class="fa fa-user"></i></label>
                                <input name="user[email]" type="text" class="form-control" id="sign-email" placeholder="请输入 Email或用户名" title="请输入 Email或用户名" required tabindex="1" autofocus>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <label for="sign-pwd" class="addon"><i class="fa fa-key fa-fw"></i></label>
                                <input name="user[pwd]" type="password" class="form-control" id="sign-pwd" placeholder="请输入密码" title="请输入密码，至少 5 字符或以上" pattern=".{5,}" required tabindex="1">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <label for="sign-remember" class="addon"><i class="fa fa-fw"></i></label>
                                <label for="sign-remember">
                                    <input type="checkbox" name="user[remember]" id="sign-remember" value="1" checked tabindex="1"/>
                                    下次自动登录
                                </label>
                                <a class="forgot-pwd-link" href="/Pages/App_Public/Recover.aspx">
                                    <i class="fa fa-question-circle"></i>
                                    忘记密码了？ </a>
                            </div>
                        </div>
                        <div class="form-group form-group-submit">
                            <button type="submit" class="btn btn-lg btn-success btn-block submit" data-loading-text="登录中，请稍候……" tabindex="1">
                                <i class="fa fa-check"></i>
                                登录
                            </button>
                            <input type="hidden" name="type" value="login"/>
                        </div>
                    </form>
                    <div class="tab-body">
                        <form action="/Service/App_Public/RegisterLogin.ashx" id="fm-sign-register" method="post">
                            <div class="form-group">
                                <div class="input-group">
                                    <label for="sign-nickname" class="addon"><i class="fa fa-user fa-fw"></i></label>
                                    <input name="user[nickname]" type="text" class="form-control" id="sign-nickname" placeholder="您的昵称，至少 2 个字符或以上" title="请输入昵称，至少 2 个字符或以上" required pattern=".{2,}" tabindex="1" autofocus/>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <label for="sign-email" class="addon"><i class="fa fa-at fa-fw"></i></label>
                                    <input name="user[email]" type="email" class="form-control" id="sign-email" placeholder="请输入 Email，寻回密码时候需要" title="请输入 Email" required tabindex="1"/>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <label for="sign-pwd" class="addon"><i class="fa fa-key fa-fw"></i></label>
                                    <input name="user[pwd]" type="password" class="form-control" id="sign-pwd" placeholder="您的密码，至少 5 个字符或以上" title="请输入密码，至少 5 字符或以上" pattern=".{5,}" required tabindex="1"/>
                                </div>
                            </div>
                            <div class="form-group form-group-submit">
                                <button type="submit" class="btn btn-success btn-block btn-lg submit" data-loading-text="处理中，请稍候…" tabindex="1">
                                    <i class="fa fa-check"></i>
                                    注册 &amp; 登录
                                </button>
                                <input type="hidden" name="type" value="register"/>
                            </div>
                            <div class="form-group text-center">
                                <i class="fa fa-check-square-o"></i>
                                我已同意本站的 <a href="/bargain.html" target="_blank">服务协议</a>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <div class="open-login form-group row">
                <div class="g-phone-1-2">
                    <a href="https://graph.qq.com/oauth2.0/authorize?response_type=code&client_id=1104858188&redirect_uri=http://sq.52cos.cn/App_Public/ThirdPartyLogin.aspx&state=0.1&scope=test" title="QQ 登录" class="btn btn-block btn-primary">
                        <i class="fa fa-qq fa-fw"></i>QQ 登录 </a>
                </div>
                <div class="g-phone-1-2">
                    <a href="#" title="微博登录" class="btn btn-block btn-danger">
                        <i class="fa fa-weibo fa-fw"></i>微博登录 </a>
                </div>
                <div class="g-phone-1-2">
                    <a href="#" title="Google 登录" class="btn btn-block btn-info">
                        <i class="fa fa-google-plus fa-fw"></i>Google 登录 </a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>
        $(document).ready(function () {
            //登录
            $('#fm-sign-login').bind('submit', function () {
                var $logbut = $("button", this);
                var submit_loading_tx = $logbut.attr("data-loading-text");
                $logbut.html(submit_loading_tx);
                $logbut.attr("disabled", !0);

                $(this).ajaxSubmit({
                    success:function (data) {
                        if (data == 1) {
                            var refer = document.referrer;
                            if (refer.indexOf('/login.html') > -1) {
                                refer = refer.replace("/login.html", "/index.html");
                            }
                            window.swal({
                                title: "登录成功!",
                                text: '3秒后自动跳转<br/>或者<a href="' + refer + '">点击这里跳转</a>',
                                html: true,
                                timer: 3000,
                                showConfirmButton: false
                            });
                            window.location.href = refer;
                        } else {
                            window.swal("小2提醒您", "邮箱或密码错误", "error");
                        }
                    },
                    error:function () {
                        window.swal("小2提醒您", "系统繁忙，请稍后再试", "error");
                    }
                });
                $logbut.html("<i class='fa fa-check'></i>登录");
                $logbut.attr("disabled", !!0);
                return false;
            });
            //注册&登录
            $('#fm-sign-register').bind('submit', function () {
                var $regbut = $("button", this);
                var submit_loading_tx = $regbut.attr("data-loading-text");
                $regbut.html(submit_loading_tx);
                $regbut.attr("disabled", !0);
                $(this).ajaxSubmit({
                    success:function (res) {
                        var msg = eval("(" + res + ")");
                        if (msg.status == "success") {
                            var refer = document.referrer;
                            window.swal({
                                title: "登录成功!",
                                text: '3秒后自动跳转<br/>或者<a href="' + refer + '">点击这里跳转</a>',
                                html: true,
                                timer: 3000,
                                showConfirmButton: false
                            });
                            window.location.href = refer;
                        } else if (msg.status == "exist") {
                            window.swal("小2提醒您", "邮箱已存在", "error");
                        } else {
                            window.swal("小2提醒您", "系统发生错误，请联系管理员", "error");
                        }
                    },
                    error:function () {
                        window.swal("小2提醒您", "系统繁忙，请稍后再试", "error");
                    }
                });
                $regbut.html("<i class='fa fa-check'></i>注册 &amp; 登录");
                $regbut.attr("disabled", !!0);
                return false;
            });
        });

        
    </script>
</asp:Content>
