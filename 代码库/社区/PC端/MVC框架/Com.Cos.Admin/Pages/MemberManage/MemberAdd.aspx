<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="MemberAdd.aspx.cs" Inherits="Com.Cos.Admin.Pages.MemberManage.MemberAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>添加用户 - H-ui.admin v3.0</title>
    <meta name="keywords" content="H-ui.admin v3.0,H-ui网站后台模版,后台模版下载,后台管理系统模版,HTML后台模版下载">
    <meta name="description" content="H-ui.admin v3.0，是一款由国人开发的轻量级扁平化网站后台模板，完全免费开源的网站后台管理系统模版，适合中小型CMS后台系统。">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <article class="page-container">
        <form action="../../Service/MemberManage/AddMember.ashx" method="post" class="form form-horizontal" id="form-member-add">
            <div class="row cl">
                <input type="hidden" name="id" value="<%:Member.User_id %>"/>
                <label class="form-label col-xs-4 col-sm-3"><span class="c-red">*</span>密码：</label>
                <div class="formControls col-xs-8 col-sm-9">
                    <input type="password" class="input-text" value="<%:Com.Cos.Common.DEncryptUtils.Decrypt3DES(Member.Password) %>" placeholder="" id="password" name="password">
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-3"><span class="c-red">*</span>性别：</label>
                <div class="formControls col-xs-8 col-sm-9 skin-minimal">
                    <div class="radio-box">
                        <input value="1" name="sex" type="radio" id="sex-1" <%:Member.Gender=="1"?"checked":"" %> />
                        <label for="sex-1">男</label>
                    </div>
                    <div class="radio-box">
                        <input value="0" type="radio" id="sex-2" name="sex" <%:Member.Gender=="0"?"checked":"" %>/>
                        <label for="sex-2">女</label>
                    </div>
                    <div class="radio-box">
                        <input value="-1" type="radio" id="sex-3" name="sex" <%:Member.Gender!="0"&&Member.Gender!="1"?"checked":"" %>>
                        <label for="sex-3">保密</label>
                    </div>
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-3"><span class="c-red">*</span>手机：</label>
                <div class="formControls col-xs-8 col-sm-9">
                    <input type="text" class="input-text" value="<%:Member.Phone_mob %>" placeholder="" id="mobile" name="mobile">
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-3">邮箱：</label>
                <div class="formControls col-xs-8 col-sm-9">
                    <input type="text" class="input-text" value="<%:Member.Email %>" placeholder="@" name="email" id="email">
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-3">真实姓名：</label>
                <div class="formControls col-xs-8 col-sm-9">
                    <input type="text" class="input-text" value="<%:Member.Real_name %>" placeholder="" name="realname" id="realname">
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-3"><span class="c-red">*</span>昵称：</label>
                <div class="formControls col-xs-8 col-sm-9">
                    <input type="text" class="input-text" value="<%:Member.nickname %>" placeholder="" name="nickname" id="nickname">
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-3">身家：</label>
                <div class="formControls col-xs-8 col-sm-9">
                    <input type="text" class="input-text" value="<%:Member.Shenjia %>" placeholder="" name="shenjia" id="shenjia">
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-3">兑换总次数：</label>
                <div class="formControls col-xs-8 col-sm-9">
                    <input type="text" class="input-text" value="<%:Member.Conversions %>" placeholder="" name="conversions" id="conversions">
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-3">兑换剩余次数：</label>
                <div class="formControls col-xs-8 col-sm-9">
                    <input type="text" class="input-text" value="<%:Member.RemainingConversions %>" placeholder="" name="remainingConversions" id="remainingConversions">
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-3">会员时间：</label>
                <div class="formControls col-xs-8 col-sm-9">
                    <input type="text" value="<%:Member.Stime %>" onfocus="WdatePicker({ maxDate:'#F{$dp.$D(\'etime\')||\'%y-%M-%d\'}',dateFmt:'yyyy-MM-dd HH:mm:ss' })" class="input-text Wdate" placeholder="" name="stime" id="stime">
                    -
                    <input type="text" value="<%:Member.Etime %>" onfocus="WdatePicker({ minDate:'#F{$dp.$D(\'stime\',{y:1})}',dateFmt:'yyyy-MM-dd HH:mm:ss' })" class="input-text Wdate" placeholder="" name="etime" id="etime">
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-3">生日：</label>
                <div class="formControls col-xs-8 col-sm-9">
                    <input value="<%:Member.Birthday %>" onfocus="WdatePicker({ maxDate:'%y-%M-%d' })" type="text" class="input-text Wdate" placeholder="" name="birthday" id="birthday">
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-3">头像：</label>
                <div class="formControls col-xs-8 col-sm-9">
                    <span class="btn-upload form-group">
                        <input class="input-text upload-url" type="text" name="uploadfile" id="uploadfile" readonly nullmsg="请添加附件！" style="width: 200px">
                        <a href="javascript:void();" class="btn btn-primary radius upload-btn"><i class="Hui-iconfont">&#xe642;</i> 浏览文件</a>
                        <input type="file" multiple name="file-2" class="input-file">
                    </span>
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-3">所在城市：</label>
                <div class="formControls col-xs-8 col-sm-9">
                    <span class="select-box">
                        <select class="select" size="1" name="city">
                            <option value="" selected>请选择城市</option>
                            <option value="1">北京</option>
                            <option value="2">上海</option>
                            <option value="3">广州</option>
                        </select>
                    </span>
                </div>
            </div>
            <div class="row cl">
                <label class="form-label col-xs-4 col-sm-3">个人描述：</label>
                <div class="formControls col-xs-8 col-sm-9">
                    <textarea aria-valuetext="<%:Member.Describe %>" name="describe" cols="" rows="" class="textarea" placeholder="说点什么...最少输入10个字符" onkeyup="$.Huitextarealength(this,100)"></textarea>
                    <p class="textarea-numberbar"><em class="textarea-length">0</em>/100</p>
                </div>
            </div>
            <div class="row cl">
                <div class="col-xs-8 col-sm-9 col-xs-offset-4 col-sm-offset-3">
                    <input class="btn btn-primary radius" type="submit" value="&nbsp;&nbsp;提交&nbsp;&nbsp;">
                </div>
            </div>
        </form>
    </article>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
    <!--请在下方写此页面业务相关的脚本-->
    <script type="text/javascript" src="../../Scripts/plugins/My97DatePicker/4.8/WdatePicker.js"></script>
    <script type="text/javascript" src="../../Scripts/plugins/jquery.validation/1.14.0/jquery.validate.js"></script>
    <script type="text/javascript" src="../../Scripts/plugins/jquery.validation/1.14.0/validate-methods.js"></script>
    <script type="text/javascript" src="../../Scripts/plugins/jquery.validation/1.14.0/messages_zh.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.skin-minimal input').iCheck({
                checkboxClass: 'icheckbox-blue',
                radioClass: 'iradio-blue',
                increaseArea: '20%'
            });
            var ajax_option= {
                success: function(res) {
                    var msg = eval("(" + res + ")");
                    if (msg.status =="success") {
                        var index = parent.layer.getFrameIndex(window.name);
                        parent.$('.btn-success').click();
                        parent.layer.close(index);
                    } else {
                        layer.alert(msg.message,{icon:2});
                    }
                }
            }
            $("#form-member-add").validate({
                rules: {
                    password: {
                        required: true,
                        minlength: 2,
                        maxlength: 16
                    },
                    sex: {
                        required: true,
                    },
                    mobile: {
                        
                        isMobile: true,
                    },
                    nickname: {
                        required: true,
                        minlength: 2,
                        maxlength: 16
                    },
                },
                onkeyup: false,
                focusCleanup: true,
                success: "valid",
                submitHandler: function (form) {
                    $(form).ajaxSubmit(ajax_option);
                    //var index = parent.layer.getFrameIndex(window.name);
                    //parent.$('.btn-refresh').click();
                    //parent.layer.close(index);
                }
            });
        });
    </script>
    <!--/请在上方写此页面业务相关的脚本-->
</asp:Content>
