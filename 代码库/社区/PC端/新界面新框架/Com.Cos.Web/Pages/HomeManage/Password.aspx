<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/AccountMaster.master" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="Com.Cos.Web.Pages.HomeManage.Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="/plugins/sweetalert/sweetalert.min.js"></script>
    <link href="/plugins/sweetalert/sweetalert.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form" runat="server">
    <form id="fm-change-password" class="user-form form-horizontal" method="post" action="/Service/HomeManage/UpdatePassword.ashx">
        <!-- current password -->
        <input type="hidden" name="user[userId]" value="<%=MemberEntity.User_id %>"/>
        <div class="form-group">
            <label class="control-label g-tablet-1-6">
                <label for="user-old-pwd">当前密码</label>
            </label>
            <div class="g-tablet-5-6">
                <input id="user-old-pwd" name="user[old-pwd]" type="password" class="form-control" placeholder="当前密码" title="输入当前的密码" required>
            </div>
        </div>
        <!-- new password -->
        <div class="form-group">
            <label class="control-label g-tablet-1-6">
                <label for="user-new-pwd-1">新密码</label>
            </label>
            <div class="g-tablet-5-6">
                <input id="user-new-pwd-1" name="user[new-pwd-1]" type="password" class="form-control" placeholder="新密码" title="输入新密码" required>
            </div>
        </div>
        <div class="form-group">
            <label class="control-label g-tablet-1-6">
                <label for="user-new-pwd-2">重新输入新密码</label>
            </label>
            <div class="g-tablet-5-6">
                <input id="user-new-pwd-2" name="user[new-pwd-2]" type="password" class="form-control" placeholder="重新输入新密码" title="重新输入新密码" required>
            </div>
        </div>
        <!-- submit -->
        <div class="form-group">
            <div class="g-tablet-1-6">&nbsp;</div>
            <div class="g-tablet-5-6">
                <div class="submit-tip"></div>
                <input type="hidden" name="type" value="pwd">
                <button type="submit" class="submit btn btn-success btn-block btn-lg" data-loading-text="保存中，请稍候……">
                    <i class="fa fa-check"></i>
                    更新密码
                </button>
            </div>
        </div>
    </form>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>var active_menu="密码"</script>
    <script>
        $(document).ready(function() {
            $('#fm-change-password').bind('submit', function () {
                if ($('#user-new-pwd-1').val() != $('#user-new-pwd-2').val()) {
                    window.swal("小2提醒您", "两次密码输入不同", "error");
                    return false;
                }

                var $logbut = $("button", this);
                var submit_loading_tx = $logbut.attr("data-loading-text");
                $logbut.html(submit_loading_tx);
                $logbut.attr("disabled", !0);

                $(this).ajaxSubmit({
                    success: function (res) {
                        var msg = eval("("+res+")");
                        if (msg.status == "error") {
                            window.swal("小2提醒您", "账号不存在或原始密码输入错误", "error");
                        } else if (msg == "success") {
                            window.swal("小2提醒您", "修改成功", "success");
                        } else {
                            window.swal("小2提醒您", "修改出现问题", "error");
                        }
                        $logbut.html("<i class='fa fa-check'></i>更新密码");
                        $logbut.attr("disabled", !!0);
                    },
                    error: function () {
                        window.swal("小2提醒您", "系统繁忙，请稍后再试", "error");
                        $logbut.html("<i class='fa fa-check'></i>更新密码");
                        $logbut.attr("disabled", !!0);
                    }

                });
                return false;
            });
        });
    </script>
</asp:Content>
