<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/AccountMaster.master" AutoEventWireup="true" CodeBehind="Share.aspx.cs" Inherits="Com.Cos.Web.Pages.HomeManage.Share" %>
<%@OutputCache Duration="120" VaryByParam="type" Location="Client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Style/css/frontend-logged-default.css" rel="stylesheet" />
        <script src="../../Style/js/exif.js"></script>
    <script src="../../Style/js/canvasJs.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form" runat="server">
        <!--说明-->
    <div class="well">
        <font size="3px"><strong><font color="red"><p> 发布须知</p> </font></strong></font>
        <font size="2px"><strong><font color="red"><p>建议至少发布6张图片，分别包括正面、背面、侧面、里面、上面、下面 </p> </font></strong></font>
        <font size="2px"><strong><font color="red"><p>建议至少发布6张图片，分别包括正面、背面、侧面、里面、上面、下面 </p> </font></strong></font>
        <font size="2px"><strong><font color="red"><p>建议至少发布6张图片，分别包括正面、背面、侧面、里面、上面、下面 </p> </font></strong></font>
    </div>
    <form id="fm-ctb" class="form-horizontal" method="post" action="/Service/HomeManage/SaveShare.ashx">
        <div class="form-group">
            <label for="ctb-title" class="g-tablet-1-6 control-label">
                标题
            </label>
            <div class="g-tablet-5-6">
                <input type="text" name="ctb[post-title]" class="form-control" id="ctb-title" placeholder="文章标题（必填）" title="文章标题必须填写哦" value="" required autofocus maxlength="50">
            </div>
        </div>
        <div class="form-group">
            <label for="ctb-title" class="g-tablet-1-6 control-label">
                物品名称
            </label>
            <div class="g-tablet-5-6">
                <input type="text" name="ctb[post-itemName]" class="form-control" id="ctb-itemName" placeholder="物品名称（必填）" title="物品名称必须填写哦" value="" required maxlength="50">
            </div>
        </div>
        <div class="form-group">
            <label for="ctb-title" class="g-tablet-1-6 control-label">
                物品包括
            </label>
            <div class="g-tablet-5-6">
                <input type="text" name="ctb[post-constitute]" class="form-control" id="ctb-constitute" placeholder="物品包括（必填）" title="物品包括必须填写哦" value="" required maxlength="50">
            </div>
        </div>
        <div class="form-group">
            <label for="ctb-title" class="g-tablet-1-6 control-label">
                物品来自
            </label>
            <div class="g-tablet-5-6">
                <input type="text" name="ctb[post-source]" class="form-control" id="ctb-source" placeholder="物品来自（必填）" title="物品来自必须填写哦" value="" required maxlength="50">
            </div>
        </div>
        <div class="form-group">
            <div class="g-tablet-1-1">
                <label class="g-tablet-1-6 control-label">
                    其他描述
                </label>
                <div class="wp-core-ui wp-editor-wrap tmce-active">
                    <div class="wp-editor-container">
                        <textarea class="form-control wp-editor-area" rows="20" cols="40" placeholder="物品具体尺寸和细节描述（必填）" name="ctb[post-describe]" id="ctb-describe" required></textarea>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="g-tablet-1-6 control-label">
                <i class="fa fa-image"></i>
                上传购买凭证
            </div>
            <div class="g-tablet-5-6">
                <div id="">
                    <div class="" id="">
                        <i class="fa fa-upload"></i>
                        选择或拖放图片
                            <input type="file" id="ctb-certificate">
                    </div>
                </div>
                <div id="" class="progress">
                    <div id="" class="progress-bar progress-bar-success progress-bar-striped active"></div>
                </div>
                <div id=""></div>
                <div id="ctb-certificates" class="row" style="display: block;">
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="g-tablet-1-6 control-label">
                <i class="fa fa-image"></i>
                上传产品图片
            </div>
            <div class="g-tablet-5-6">
                <div id="ctb-file-area">
                    <div class="" id="ctb-file-btn">
                        <i class="fa fa-upload"></i>
                        选择或拖放图片
                            <input type="file" id="ctb-file" multiple>
                    </div>
                </div>
                <div id="ctb-file-progress-container" class="progress">
                    <div id="ctb-file-progress" class="progress-bar progress-bar-success progress-bar-striped active"></div>
                </div>
                <div id="ctb-file-completion"></div>
                <div id="ctb-files" class="row" style="display: block;">
                </div>
            </div>
        </div>
        <div class="form-group">
            <label for="ctb-title" class="g-tablet-1-6 control-label">
                物品原价
            </label>
            <div class="g-tablet-5-6">
                <input type="text" name="ctb[post-price]" class="form-control" id="ctb-price" placeholder="物品原价（必填）" title="物品原价必须填写哦" value="" required maxlength="50">
            </div>
        </div>
        <%
            if (type == "enchange")
                Response.Write(@"<div class='form-group'>
            <div class='g-tablet-1-6 control-label'>
                <i class='fa fa-database'></i>
                期望值
            </div>
            <div class='g-tablet-5-6'>
                <div class='row'>
                    <div class='g-phone-1-2 g-tablet-1-4'>
                        <input id='ctb-custom-tag-0' class='ctb-custom-tag form-control' type='text' name='ctb[tags][]' placeholder='估价 1' required maxlength='50'>
                    </div>
                    <div class='g-phone-1-2 g-tablet-1-4'>
                        <input id='ctb-custom-tag-1' class='ctb-custom-tag form-control' type='text' name='ctb[tags][]' placeholder='估价 2' required maxlength='50'>
                    </div>
                    <div class='g-phone-1-2 g-tablet-1-4'>
                        <input id='ctb-custom-tag-2' class='ctb-custom-tag form-control' type='text' name='ctb[tags][]' placeholder='估价 3' required maxlength='50'>
                    </div>
                </div>
            </div>
        </div>");
            else
                Response.Write(@"<div class='form-group'>
            <label for='ctb-title' class='g-tablet-1-6 control-label'>
                租赁价
            </label>
            <div class='g-tablet-5-6'>
                <input type='text' name='ctb[post-official]' class='form-control' id='ctb-official' placeholder='租赁价（必填）' title='租赁价必须填写哦' value='' required maxlength='50'>
            </div>
        </div>");
             %>
        
        <input type="hidden" name="ctb[uid]" value="<%=this.User_id %>" />
        <div class="form-group">
            <div class="g-tablet-5-6">
                <button type="submit" class="btn btn-lg btn-success btn-block submit" data-loading-text="数据发送中，请稍候…">
                    <i class="fa fa-check"></i>
                    提交
                </button>
            </div>
        </div>
    </form>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>var active_menu = "发布兑换"</script>
    <script src="/Style/js/picture.js"></script><%--图片上传--%>
    <script src="/Style/js/jquery.form.js"></script>
    <script>
        $(document).ready(function () {
            $('#ctb-certificate').fileUpload({ mapsel: '#ctb-certificates', imgBox: 'ctb[certificate-ids][]', insertSwitch: false }); //初始化图片上传
            $('#ctb-file').fileUpload({ mapsel: '#ctb-files', insertSwitch: false }); //初始化图片上传

            //提交
            $('#fm-ctb').bind('submit', function () {
                var $logbut = $('button[type="submit"]', this);
                var submit_loading_tx = $logbut.attr("data-loading-text");
                $logbut.html(submit_loading_tx);
                $logbut.attr("disabled", true);

                $(this).ajaxSubmit({
                    data: { 'type': '<%=type%>' },
                    beforeSubmit: function () {
                        if ($('input[name="ctb[attach-ids][]"]').val() == "") {
                            window.swal("小2提醒您", "未上传图片！", "error");
                            $logbut.html("<i class='fa fa-check'></i>提交");
                            $logbut.attr("disabled", false);
                            return false;
                        }
                        if ($('input[name="ctb[thumbnail-id]"]').val() == "") {
                            window.swal("小2提醒您", "未选择封面！", "error");
                            $logbut.html("<i class='fa fa-check'></i>提交");
                            $logbut.attr("disabled", false);
                            return false;
                        }
                    },
                    success: function (res) {
                        var msg = eval("(" + res + ")");
                        if (msg.status == "success") {
                            window.swal({
                                title: "",
                                text: '发布成功',
                                timer: 3000,
                                showConfirmButton: false
                            });
                            location.reload();
                        } else {
                            window.swal("小2提醒您", "发布失败，请稍后再试", "error");
                            $logbut.html("<i class='fa fa-check'></i>提交");
                            $logbut.attr("disabled", false);
                        }
                    },
                    error: function () {
                        window.swal("小2提醒您", "系统繁忙，请稍后再试", "error");
                        $logbut.html("<i class='fa fa-check'></i>提交");
                        $logbut.attr("disabled", false);
                    }
                });
                return false;
            });
        });
    </script>
</asp:Content>
