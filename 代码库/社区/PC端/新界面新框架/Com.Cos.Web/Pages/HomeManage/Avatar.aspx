<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/AccountMaster.master" AutoEventWireup="true" CodeBehind="Avatar.aspx.cs" Inherits="Com.Cos.Web.Pages.HomeManage.Avatar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Style/css/frontend-logged-default.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form" runat="server">
    <form id="fm-change-avatar" class="form-horizontal" action="javascript:;">
        <fieldset>
            <legend class="label label-success">更改我的头像</legend>
            <div class="form-group">
                <div class="control-label g-tablet-1-6">
                    当前头像
                </div>
                <div class="g-tablet-5-6">
                    <div class="current-avatar">
                        <img alt='' src=''  class='avatar avatar-100 photo' height='100' width='100' />
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="control-label g-tablet-1-6">
                    新头像
                </div>
                <div class="g-tablet-5-6">
                    <div class="row">
                        <div class="g-tablet-1-2">
                            <div id="cropper-container"></div>
                        </div>
                        <div class="g-tablet-1-2">
                            <div id="avatar-preview"></div>
                        </div>
                    </div>
                    <div class="submit-tip"></div>
                    <input type="hidden" name="type" value="avatar">
                    <button id="cropper-done-btn" type="submit" class="submit btn btn-success btn-block btn-lg" data-loading-text="保存中，请稍候……">
                        <i class="fa fa-check"></i>
                        保存我的头像
                    </button>
                    <span href="javascript:;" id="new-avatar-btn" class="file-btn-container btn btn-default btn-block">
                        <i class="fa fa-plus"></i>
                        上传新头像
                        <input type="file" id="file">
                    </span>
                </div>
            </div>
        </fieldset>
    </form>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>window.THEME_CONFIG = { "vars": { "locale": "zh_CN", "iden": "mx", "process_url": "" }, "lang": { "M01": "\u52a0\u8f7d\u4e2d\uff0c\u8bf7\u7a0d\u5019\u2026", "E01": "\u62b1\u6b49\uff0c\u670d\u52a1\u5668\u6b63\u5fd9\uff0c\u65e0\u6cd5\u54cd\u5e94\u4f60\u7684\u8bf7\u6c42\uff0c\u8bf7\u7a0d\u5019\u91cd\u8bd5\u3002" }, "theme_custom_user_settings": { "process_url": "/Service/HomeManage/UploadPortrait.ashx" } };</script>
    <script>var active_menu="头像"</script>
    <script src="../../Style/js/cropper.min.js"></script>
    <script src="../../Style/js/frontend-entry-logged.js"></script>
</asp:Content>
