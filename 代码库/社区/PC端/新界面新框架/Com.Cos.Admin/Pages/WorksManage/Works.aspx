<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Works.aspx.cs" Inherits="Com.Cos.Admin.Pages.WorksManage.Works" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Style/css/plugins/sweetalert/sweetalert.css" rel="stylesheet" />
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
                    <h5>作品列表</h5>
                </div>
                <div class="ibox-content">
                    标题：<input type="text" id="txtTitle" class="form-control input-sm m-b-xs" placeholder="标题..." runat="server" />
                    类型：
                    <asp:DropDownList runat="server" ID="ddlType" class="form-control" DataValueField="id" DataTextField="RefText" />

                    昵称：<input type="text" id="txtNickname" class="form-control input-sm m-b-xs" placeholder="昵称..." runat="server" />
                    邮箱：<input type="text" id="txtEmail" class="form-control input-sm m-b-xs" placeholder="邮箱..." runat="server" />
                    日期：<input type="text" id="txtTime" class="form-control input-sm m-b-xs" placeholder="日期..." runat="server" />
                    <button type="button" runat="server" onserverclick="butSearch_OnServerClick" id="butSearch" class="btn btn-sm btn-primary" style="margin-bottom: 0">搜索</button>

                    <table class="footable table table-stripped toggle-arrow-tiny" data-page-size="10">
                        <thead>
                            <tr>
                                <th>id号</th>
                                <th data-toggle="true">标题</th>
                                <th>类型</th>
                                <th>发布人昵称</th>
                                <th>发布人邮箱</th>
                                <th data-hide="all">类型</th>
                                <th data-hide="all">最后评论时间</th>
                                <th data-hide="all">打赏数</th>
                                <th>发布日期</th>
                                <th>置顶</th>
                                <th>推荐</th>
                                <th>状态</th>
                                <th>操作</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="repWorks">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("WorksId") %></td>
                                        <td><%#Eval("WorksTitle") %></td>
                                        <td><%#GetType(Eval("WorksType").ToString()) %></td>
                                        <td><%#Eval("nickname") %></td>
                                        <td><%#Eval("Email") %></td>
                                        <td><%#GetType(Eval("WorksType").ToString()) %>, <%#GetType(Eval("Type2").ToString()) %></td>
                                        <td><span class="pie"><%#Eval("UpdateTime") %></span></td>
                                        <td><%#Eval("GoodNo") %></td>
                                        <td><%#Convert.ToDateTime(Eval("ReleaseTime")).ToString("yyyy-MM-dd HH:mm:ss") %></td>
                                        <td><a href="javascript:void(0);" onclick="UpdateStatus('<%#Eval("WorksId") %>', 'Sticky', '<%#Eval("Sticky") %>');"><i class="fa <%#Eval("Sticky").ToString()=="1"?"fa-toggle-on text-danger":"fa-toggle-off text-navy" %>"></i><%#Eval("Sticky").ToString()=="1"?"已置顶":"未置顶" %></a></td>
                                        <td><a href="javascript:void(0);" onclick="UpdateStatus('<%#Eval("WorksId") %>', 'Recommend', '<%#Eval("Recommend") %>');"><i class="fa <%#Eval("Recommend").ToString()=="1"?"fa-toggle-on text-danger":"fa-toggle-off text-navy" %>"></i><%#Eval("Recommend").ToString()=="1"?"已推荐":"未推荐" %></a></td>
                                        <td><a href="javascript:void(0);" onclick="DeleteWorks('<%#Eval("WorksId") %>', '<%#Eval("status") %>');"><i class="fa <%#Eval("status").ToString()=="1"?"fa-check text-navy":"fa-times text-danger" %>"></i><%#Eval("status").ToString()=="1"?"存在":"已删除" %></a></td>
                                        <td><a href="/Pages/WorksManage/WorksArticle.aspx?id=<%#Eval("WorksId") %>">查看</a></td>
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
    <script>
        $(document).ready(function () { $(".footable").footable(); $(".footable2").footable() });
    </script>
    <script src="/Style/js/plugins/footable/footable.all.min.js"></script>
    <script src="/Style/js/plugins/layer/laydate/laydate.js"></script>
    <script src="../../Style/js/plugins/sweetalert/sweetalert.min.js"></script>
    <script>
        $(document).ready(function () {
            //初始化日期控件
            laydate({
                elem: '#<%=txtTime.ClientID%>', //目标元素。由于laydate.js封装了一个轻量级的选择器引擎，因此elem还允许你传入class、tag但必须按照这种方式 '#id .class'
                event: 'focus' //响应事件。如果没有传入event，则按照默认的click
            });
        });
        //删除作品
        function DeleteWorks(_worksId, status) {
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
                $.get("/Service/WorksManage/DeleteWorks.ashx", { worksId: _worksId }, function (res) {
                    if (res == "True") {
                        swal("删除成功！", "您已经永久删除了这条信息。", "success");
                        window.location.reload();
                    } else {
                        swal("删除失败！", "请稍后再试", "error");
                    }
                }).error(function () { swal("错误", "服务器繁忙", "error"); });

            });

        }
        //修改推荐或置顶
        function UpdateStatus(_worksId,_statusNmae, _status) {
            swal({
                title: "您确定要删除这条信息吗",
                text: "删除后将无法恢复，请谨慎操作！",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "删除",
                closeOnConfirm: false
            }, function () {
                $.get("/Service/WorksManage/DeleteWorks.ashx", { WorksId: _worksId, StatusNmae: _statusNmae, Status: _status }, function (res) {
                    var msg = eval("(" + res + ")");
                    if (msg.status == "success") {
                        swal("删除成功！", "您已经永久删除了这条信息。", "success");
                        window.location.reload();
                    } else {
                        swal("删除失败！", "请稍后再试", "error");
                    }
                }).error(function () { swal("错误", "服务器繁忙", "error"); });

            });

        }
    </script>
</asp:Content>
