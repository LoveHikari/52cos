<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/AccountMaster.master" AutoEventWireup="true" CodeBehind="Recharge.aspx.cs" Inherits="Com.Cos.Web.Pages.HomeManage.Recharge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="/plugins/sweetalert/sweetalert.min.js"></script>
    <link href="/plugins/sweetalert/sweetalert.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form" runat="server">
    <div class="row">
        <div class="g-tablet-5-6">
            <div class="pm-dialog-container">
                <!-- pm-new -->
                <form action="/Service/HomeManage/Recharge.ashx" id="pm-dialog-new" class="pm-dialog" method="post">
                    <p class="well">注意：您正在进行身家充值操作。</p>
                    <div class="form-group">
                        <input type="hidden" value="<%=this.User_id %>" name="user[id]"/>
                        <div class="g-tablet-1-6 control-label">
                            <i class="fa fa-tags"></i>
                            快速选择金额
                        </div>
                        <div class="g-tablet-5-6">
                            <div class="checkbox-select" id='select_money'>
                                <label class="ctb-tag" for="ctb-tags-21">
                                    <input class="ctb-preset-tag" type="radio" id="ctb-tags-21" name="ctb[money]" value="0.01" hidden>
                                    <span class="label label-default">1身家/￥1.00 </span>
                                </label>
                                <label class="ctb-tag" for="ctb-tags-24">
                                    <input class="ctb-preset-tag" type="radio" id="ctb-tags-24" name="ctb[money]" value="2.33" hidden>
                                    <span class="label label-default">2.33身家/￥2.33 </span>
                                </label>
                                <label class="ctb-tag" for="ctb-tags-19">
                                    <input class="ctb-preset-tag" type="radio" id="ctb-tags-19" name="ctb[money]" value="6.66" hidden>
                                    <span class="label label-default">6.66身家/￥6.66 </span>
                                </label>
                                <label class="ctb-tag" for="ctb-tags-28">
                                    <input class="ctb-preset-tag" type="radio" id="ctb-tags-28" name="ctb[money]" value="9.99" hidden>
                                    <span class="label label-default">9.99身家/￥9.99 </span>
                                </label>
                                <label class="ctb-tag" for="ctb-tags-27">
                                    <input class="ctb-preset-tag" type="radio" id="ctb-tags-27" name="ctb[money]" value="23.33" hidden>
                                    <span class="label label-default">23.33身家/￥23.33 </span>
                                </label>
                                <label class="ctb-tag" for="ctb-tags-23">
                                    <input class="ctb-preset-tag" type="radio" id="ctb-tags-23" name="ctb[money]" value="666" hidden>
                                    <span class="label label-default">666身家/￥666 </span>
                                </label>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="ctb-excerpt" class="g-tablet-1-6 control-label">
                            充值金额
                        </label>
                        <div class="g-tablet-5-6">
                            <input type="text" name="ctb[money]" id="money" class="form-control" onfocus="return textChange();" style="width: 50%;display: inline" pattern="^[0-9]*[1-9][0-9]*$" placeholder="输入大于0的整数" onkeyup="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'')}else{this.value=this.value.replace(/\D/g,'')}" onafterpaste="if(this.value.length==1){this.value=this.value.replace(/[^1-9]/g,'0')}else{this.value=this.value.replace(/\D/g,'')}" />
                            <label class="control-label" id="money_cn">= 0 C</label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="g-tablet-1-6 control-label">
                            <i class="fa fa-tags"></i>
                            充值方式选择
                        </div>
                        <div class="g-tablet-5-6">
                            <div class="checkbox-select">
                                <label class="ctb-tag" for="ctb-tags-22">
                                    <input class="ctb-preset-tag" type="radio" id="ctb-tags-22" name="ctb[][]" value="支付宝" checked hidden>
                                    <span class="label label-default">支付宝 </span>
                                </label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <button class="btn btn-success btn-block" type="submit" onclick="return check();" data-loading-text="提交，请稍候……" tabindex="1">
                            <i class="fa fa-check"></i>&nbsp;提交
                        </button>
                    </div>
                </form>
            </div>
        </div>
        <!-- col -->
    </div>
    <!-- .row -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>var active_menu = "充值"</script>
    <script>
        $(document).ready(function () {
            //选择金额时，输入框清空
            $("input[type='radio']", "#select_money").click(function () {
                $("#money").val("");
            });

            $('#money').blur(function () {
                console.info($(this).val());
                $('#money_cn').text($(this).val()*100 + " C");
            });
        });

        //表单验证
        function check() {
            var rad = $("input[type='radio']", "#select_money");
            var b = false;
            $.each(rad, function (n, value) {
                if ($(rad[n]).is(":checked")) {
                    b = true;
                    return false;
                }
            });
            if (b || $("#money").val() != "") {
                if ($("#money").val() != "" && $("#money").val() == 0.0) {
                    swal("小2提醒您", "金额不能为0", "error");
                    return false;
                } else {
                    return true;
                }
                
            } else {
                swal("小2提醒您", "没有选择金额", "error");
                return false;
            }
        }
        //输入金额时，快速选择清空
        function textChange() {
            var rad = $("input[type='radio']", "#select_money");
            $.each(rad, function (n, value) {
                $(rad[n]).removeAttr('checked');
            });
        }
    </script>
</asp:Content>
