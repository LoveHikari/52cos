
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectAddress.aspx.cs" Inherits="Com.Cos.Web.Pages.ShowManage.SelectAddress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="/Style/js/jquery-1.12.3.min.js"></script>
    <script src="/Style/js/jquery.form.js"></script>
</head>
<body>
    <div class="shade_content">
        <asp:Repeater runat="server" ID="repAddress">
            <ItemTemplate>
                <input type="radio" name="address" value="<%#Eval("Id") %>"/><label><%#Eval("Id") %></label>
                <input type="button" id="" onclick="javascript: update('<%#Eval("Id") %>');" value="修改" />
            </ItemTemplate>
        </asp:Repeater>
        <div class="nav shade_content_div" id="add_box">
            <div class="col-xs-12 shade_title">
                新增收货地址
            </div>
            <div class="col-xs-12 shade_from">
                <form id="showDataForm" action="/Service/ShowManage/Address.ashx" method="post" onsubmit="return saveReport();">
                    <input type="hidden" name="ctb[post-addId]" id="txt_addId" value="" />
                    <input type="hidden" name="ctb[post-status]" id="txt_status" value="add" />
                    <input type="hidden" name="ctb[post-userId]" id="txt_userId" value="<%=userId %>" />
                    <div class="col-xs-12">
                        <span class="span_style" id="">地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;区</span>
                        <div class="info">
                            <div>
                                <select id="s_province" name="ctb[post-province]"></select>
                                <select id="s_city" name="ctb[post-city]"></select>
                                <select id="s_county" name="ctb[post-county]"></select>
                                <script src="/plugins/area.js" type="text/javascript"></script>
                                <script type="text/javascript">_init_area();</script>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-12">
                        <span id="">详细地址</span>
                        <input type="text" name="ctb[post-address]" id="txt_address" value="" required placeholder="&nbsp;&nbsp;请输入您的详细地址" />
                    </div>
                    <div class="col-xs-12">
                        <span id="">邮政编号</span>
                        <input type="text" name="ctb[post-zipCode]" id="txt_zipCode" value="" required placeholder="&nbsp;&nbsp;请输入您的邮政编号" />
                    </div>
                    <div class="col-xs-12">
                        <span id="">姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名</span>
                        <input type="text" name="ctb[post-name]" id="txt_name" value="" required placeholder="&nbsp;&nbsp;请输入您的姓名" />
                    </div>
                    <div class="col-xs-12">
                        <span id="">手机号码</span>
                        <input type="text" name="ctb[post-phone]" id="txt_phone" value="" required placeholder="&nbsp;&nbsp;请输入您的手机号码" />
                    </div>
                    <div class="col-xs-12">
                        <input type="button" id="" onclick="javascript: onclick_close();" value="取消" />
                        <input type="submit" class="sub_set" id="sub_setID" value="提交" />
                    </div>
                </form>
            </div>
        </div>
        <input type="button" id="confirm" value="确定" />
    </div>
    <script>
        var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
        $(document).ready(function() {
            if ($("input[name='address']").length > 2) {
                $('#add_box').hide();
            }
            //确定
            $('#confirm').click(function() {
                var address = $("input[name='address']:checked").val();
                if (!address) {
                    alert("请选择一个地址");
                    return false;
                }
                if ('<%=type%>' == "rent") {
                    $.post("/Service/ShowManage/RentSignUp.ashx", { UserId: <%=userId%>, RId: <%=exId%>, AddressId: address }, function (res) {
                    var msg = eval("(" + res + ")");
                    if (msg.status == "success") {
                        alert("兑换成功");
                        parent.location.reload();
                        parent.layer.close(index);
                    } else if (msg.status == "error") {
                        alert("兑换失败");
                    } else if (msg.status == "lacking") {
                        alert("身家不足");
                    }
                    else {
                        alert("未在兑换时间或已兑换");
                    }
                }).error(function () { alert("系统繁忙，请稍后再试"); });
                } else {
                    $.post("/Service/ShowManage/ShareSignUp.ashx", { UserId: <%=userId%>, ExId: <%=exId%>, AddressId: address,classId:<%=classId%> }, function (res) {
                    var msg = eval("(" + res + ")");
                    if (msg.status == "success") {
                        alert("兑换成功");
                        parent.location.reload();
                        parent.layer.close(index);
                    } else if (msg.status == "error") {
                        alert("兑换失败");
                    } else if (msg.status == "lacking") {
                        alert("身家不足或会员到期");
                    }
                    else {
                        alert("未在兑换时间或已兑换");
                    }
                }).error(function () { alert("系统繁忙，请稍后再试"); });
                }
                
            });
        });
        //取消
        function onclick_close() {
            
            parent.layer.close(index);
        }
        //提交
        function saveReport() {
            // jquery 表单提交
            $("#showDataForm").ajaxSubmit(function (res) {
                // 对于表单提交成功后处理，message为提交页面的返回内容
                var msg = eval("(" + res + ")");
                console.info(msg);
                if (msg.status == "success") {
                    location.reload();
                } else {
                    alert("地址添加失败");
                }
            });

            return false; // 必须返回false，否则表单会自己再做一次提交操作，并且页面跳转
        }
        //修改
        function update(id) {
            $('#txt_addId').val(id);
            $('#txt_status').val("update");
            $('#add_box').show();
        }
    </script>
</body>
</html>
