<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/AccountMaster.master" AutoEventWireup="true" CodeBehind="BuyVip.aspx.cs" Inherits="Com.Cos.Web.Pages.HomeManage.BuyVip" %>

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
                    <p class="well">注意：您正在进行会员购买操作。</p>
                    <div class="form-group">
                        <input type="hidden" value="<%=this.User_id %>" name="user[id]"/>
                        <div class="g-tablet-1-6 control-label">
                            <i class="fa fa-tags"></i>
                            快速选择会员
                        </div>
                        <div class="g-tablet-5-6">
                            <div class="checkbox-select" id='select_money'>
                                <label class="ctb-tag" for="ctb-tags-21">
                                    <input class="ctb-preset-tag" type="radio" id="ctb-tags-21" name="ctb[money]" value="99.00" hidden>
                                    <span class="label label-default">1个月会员/￥99.00 </span>
                                </label>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="g-tablet-1-6 control-label">
                            <i class="fa fa-tags"></i>
                            购买方式选择
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
    <script>var active_menu = "购买会员"</script>
    <script>
        $(document).ready(function () {
            
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

    </script>
</asp:Content>
