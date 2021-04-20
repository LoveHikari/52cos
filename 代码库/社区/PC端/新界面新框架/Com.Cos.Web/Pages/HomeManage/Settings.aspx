<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/AccountMaster.master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="Com.Cos.Web.Pages.HomeManage.Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/plugins/sweetalert/sweetalert.min.js"></script>
    <link href="/plugins/sweetalert/sweetalert.css" rel="stylesheet" />
    <script src="/plugins/birthday/birthday.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form" runat="server">
    <form id="fm-my-settings" class="user-form form-horizontal" method="post" action="/Service/HomeManage/UpdateSettings.ashx">
        <div class="form-group">
            <div class="control-label g-tablet-1-6">
                <a href="<%=MemberEntity.Portrait %>" target="_blank" title="查看原图">
                    <img alt='' src='<%=MemberEntity.Portrait %>' srcset='<%=MemberEntity.Portrait %> 2x' class='avatar avatar-100 photo' height='100' width='100' /></a>
            </div>
            <div class="g-tablet-5-6">
                <div class="form-control-static">
                    <p>我的头像</p>
                    <p><a href="/Pages/HomeManage/Avatar.aspx" class="btn btn-success btn-xs">更改头像 <i class="fa fa-external-link"></i></a></p>
                </div>
            </div>
        </div>
        <fieldset>
            <legend>编辑我的资料</legend>
            <input type="hidden" name="user[userId]" value="<%=User_id %>"/>
            <%--<div class="form-group">
                <div class="control-label g-tablet-1-6">
                    <abbr title="唯一的标识（不能被更改）">
                        UID
                    </abbr>
                </div>
                <div class="g-tablet-5-6">
                    <p class="form-control-static">
                        <strong>
                            <a href="http://www.91moe.com/moeauthor/100037">100037</a>
                        </strong>
                    </p>
                </div>
            </div>--%>
            <div class="form-group">
                <label for="my-settings-nickname" class="control-label g-tablet-1-6">
                    <i class="fa fa-user"></i>
                    昵称
                </label>
                <div class="g-tablet-5-6">
                    <input name="user[nickname]" type="text" class="form-control" id="my-settings-nickname" placeholder="请输入昵称（必填）" title="请输入昵称" value="<%=MemberEntity.nickname %>" required tabindex="1">
                </div>
            </div>
            <div class="form-group">
                <label for="my-settings-nickname" class="control-label g-tablet-1-6">
                    <i class="fa fa-envelope"></i>
                    邮箱
                </label>
                <div class="g-tablet-5-6">
                    <input name="user[email]" type="email" class="form-control" id="my-settings-email" placeholder="请输入邮箱（必填）" title="请输入邮箱" value="<%=MemberEntity.Email %>" required tabindex="1">
                </div>
            </div>
            <div class="form-group">
                <label for="my-settings-url" class="control-label g-tablet-1-6">
                    <i class="fa fa-link"></i>
                    真实姓名
                </label>
                <div class="g-tablet-5-6">
                    <input name="user[Real_name]" type="text" class="form-control" id="my-settings-Real_name" placeholder="您的真实姓名" title="请输入您的真实姓名" value="<%=MemberEntity.Real_name %>" tabindex="1">
                </div>
            </div>
            <div class="form-group">
                <label for="my-settings-nickname" class="control-label g-tablet-1-6">
                    <i class="fa fa-venus-mars"></i>
                    性别
                </label>
                <div class="g-tablet-5-6">
                    <label class="radio-inline">
                        <input name="user[gender]" type="radio" class="theme_custom_post_source-source-radio" id="my-settings-gender0" title="无性动物" <%=MemberEntity.Gender==""?"checked":"" %> value="" required tabindex="1">无性动物
                    
                    </label>
                    <label class="radio-inline">
                        <input name="user[gender]" type="radio" class="theme_custom_post_source-source-radio" id="my-settings-gender1" title="正太" value="1" <%=MemberEntity.Gender=="1"?"checked":"" %> required tabindex="1">正太
                    </label>
                    <label class="radio-inline">
                        <input name="user[gender]" type="radio" class="theme_custom_post_source-source-radio" id="my-settings-gender2" title="萝莉" value="0" <%=MemberEntity.Gender=="0"?"checked":"" %> required tabindex="1">萝莉
                    </label>
                </div>
            </div>
            <div class="form-group">
                <label for="my-settings-nickname" class="control-label g-tablet-1-6">
                    <i class="fa fa-gift"></i>
                    生日
                </label>
                <div class="g-tablet-5-6">
                    <select class="sel_year" name="user[year]" rel="<%=MemberEntity.Birthday.Split('-').Length>3?MemberEntity.Birthday.Split('-')[0]:"0" %>" required></select>年 
                    <select class="sel_month" name="user[month]" rel="<%=MemberEntity.Birthday.Split('-').Length>3?MemberEntity.Birthday.Split('-')[1]:"0" %>" required></select>月 
                    <select class="sel_day" name="user[day]" rel="<%=MemberEntity.Birthday.Split('-').Length>3?MemberEntity.Birthday.Split('-')[2]:"0" %>" required></select>日 
                </div>
            </div>
            <div class="form-group">
                <label for="my-settings-nickname" class="control-label g-tablet-1-6">
                    <i class="fa fa-mobile"></i>
                    手机号
                </label>
                <div class="g-tablet-5-6">
                    <input name="user[Phone_mob]" type="text" class="form-control" id="my-settings-Phone_mob" placeholder="请输入手机号" title="请输入手机号" value="<%=MemberEntity.Phone_mob %>" tabindex="1">
                </div>
            </div>
            <div class="form-group">
                <label for="my-settings-nickname" class="control-label g-tablet-1-6">
                    <i class="fa fa-qq"></i>
                    QQ
                </label>
                <div class="g-tablet-5-6">
                    <input name="user[qq]" type="text" class="form-control" id="my-settings-qq" placeholder="请输入QQ" title="请输入QQ" value="<%=MemberEntity.Im_qq %>" tabindex="1">
                </div>
            </div>
            <div class="form-group">
                <label for="my-settings-des" class="control-label g-tablet-1-6">
                    <i class="fa fa-newspaper-o"></i>
                    描述
                </label>
                <div class="g-tablet-5-6">
                    <textarea name="user[description]" class="form-control" id="my-settings-des" placeholder="向每个人介绍自己" tabindex="1"></textarea>
                </div>
            </div>
            <div class="form-group">
                <div class="g-tablet-1-6">&nbsp;</div>
                <div class="g-tablet-5-6">
                    <div class="submit-tip"></div>
                    <input type="hidden" name="type" value="settings">
                    <button type="submit" class="submit btn btn-success btn-block btn-lg" data-loading-text="保存中，请稍候……">
                        <i class="fa fa-check"></i>
                        保存我的设置
                    </button>
                </div>
            </div>
        </fieldset>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>var active_menu="设置"</script>
    <script>
        $(document).ready(function () {
            $.ms_DatePicker({
                YearSelector: ".sel_year",
                MonthSelector: ".sel_month",
                DaySelector: ".sel_day"
            });

            //保存
            $('#fm-my-settings').bind('submit', function () {
                var $logbut = $("button", this);
                var submit_loading_tx = $logbut.attr("data-loading-text");
                $logbut.html(submit_loading_tx);
                $logbut.attr("disabled", !0);

                $(this).ajaxSubmit({
                    success: function (res) {
                        var msg = eval("(" + res + ")");
                        if (msg.status == "success") {
                            window.swal({
                                title: "",
                                text: '您的设置已保存',
                                timer: 3000,
                                showConfirmButton: false
                            });
                        } else if (msg.status == "exist") {
                            window.swal("小2提醒您", "该昵称已存在", "error");
                        }
                        $logbut.html("<i class='fa fa-check'></i>保存我的设置");
                        $logbut.attr("disabled", !!0);
                    },
                    error:function () {
                        window.swal("小2提醒您", "系统繁忙，请稍后再试", "error");
                        $logbut.html("<i class='fa fa-check'></i>保存我的设置");
                        $logbut.attr("disabled", !!0);
                    }
                });
                return false;
            });
        });
    </script>
</asp:Content>
