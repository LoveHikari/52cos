<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/SiteMaster.Master" AutoEventWireup="true" CodeBehind="SlideList.aspx.cs" Inherits="Com.Cos.Admin.Pages.SlideManage.SlideList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Style/js/plugins/fancybox/jquery.fancybox.css" rel="stylesheet">
    <link href="/Style/css/plugins/sweetalert/sweetalert.css" rel="stylesheet" />
    <style>
        .form-control {
            display: inline;
            width: 10%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="ibox float-e-margins">
                <div class="ibox-title">
                    <h5>幻灯片及大海报列表</h5>
                </div>
                <div class="ibox-content">
                    类型：
                    <select id="selSign" runat="server">
                        <option value="">----</option>
                        <option value="1">幻灯片</option>
                        <option value="2">大海报</option>
                    </select>
                    文本：<input type="text" id="txtText" class="form-control input-sm m-b-xs" placeholder="文本..." runat="server" />
                    日期：<input type="text" id="txtTime" class="form-control input-sm m-b-xs" placeholder="日期..." runat="server" />
                    <button type="button" runat="server" onserverclick="butSearch_OnServerClick" id="butSearch" class="btn btn-sm btn-primary" style="margin-bottom: 0">搜索</button>
                    <input type="button" value="新增" class="btn btn-sm btn-primary" style="margin-bottom: 0" onclick="return addSlide();" />
                    <table class="footable table table-stripped toggle-arrow-tiny" data-page-size="10">
                        <thead>
                            <tr>
                                <th>id号</th>
                                <th>类型</th>
                                <th>文本</th>
                                <th>图片地址</th>
                                <th>链接地址</th>
                                <th>权重</th>
                                <th>添加时间</th>
                                <th>状态</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="repSlide">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("Id") %></td>
                                        <td><%#SetSign(Eval("Sign").ToString()) %></td>
                                        <td><%#Eval("ImgText") %></td>
                                        <td><%#Eval("ImgUrl") %></td>
                                        <td><%#Eval("ImgHref") %></td>
                                        <td><%#Eval("weight") %></td>
                                        <td><%#Convert.ToDateTime(Eval("AddTime")).ToString("yyyy-MM-dd HH:mm:ss") %></td>
                                        <td><a href="javascript:void(0);" onclick="deleteImg('<%#Eval("Id") %>', '<%#Eval("status") %>');"><i class="fa <%#Eval("status").ToString()=="1"?"fa-check":"fa-times" %> text-navy"></i><%#Eval("status").ToString()=="1"?"存在":"已删除" %></a></td>
                                        <td><a href="<%#Eval("ImgUrl") %>" class="fancybox">查看</a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                        <tfoot>
                            <tr>
                                <td colspan="5">
                                    <ul class="pagination pull-right"></ul>
                                </td>
                            </tr>
                        </tfoot>
                    </table>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script src="/Style/js/plugins/footable/footable.all.min.js"></script>
    <script src="/Style/js/plugins/fancybox/jquery.fancybox.js"></script>
    <script src="/Style/js/plugins/layer/layer.min.js?v=2.4"></script>
    <script>
        $(document).ready(function () { $(".footable").footable(); $(".footable2").footable() });
        $(document).ready(function () { $(".fancybox").fancybox({ openEffect: "none", closeEffect: "none" }) });
    </script>

    <script src="/Style/js/plugins/layer/laydate/laydate.js"></script>
    <script>
        $(document).ready(function () {
            //初始化日期控件
            laydate({
                elem: '#<%=txtTime.ClientID%>', //目标元素。由于laydate.js封装了一个轻量级的选择器引擎，因此elem还允许你传入class、tag但必须按照这种方式 '#id .class'
                event: 'focus' //响应事件。如果没有传入event，则按照默认的click
            });
        });
        //删除幻灯片
        function DeleteWorks(_id, status) {
            if (status == "0") {
                return;
            }
            swal({
                title: "您确定要删除这条信息吗",
                text: "删除后将无法恢复，请谨慎操作！",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "删除",
                closeOnConfirm: false
            }, function () {
                $.get("/Service/SlideManage/DeleteSlide.ashx", { Id: _id }, function (res) {
                    if (res == "True") {
                        swal("删除成功！", "您已经永久删除了这条信息。", "success");
                        window.location.reload();
                    } else {
                        swal("删除失败！", "请稍后再试", "error");
                    }
                }).error(function () { swal("错误", "服务器繁忙", "error"); });

            });

        }
        //新增
        function addSlide() {
            layer.open({
                type: 2,
                title: false,
                area: ['380px', '90%'],
                content: '/Pages/SlideManage/SlideDetail.aspx' //iframe的url
            });
        }
    </script>
</asp:Content>
