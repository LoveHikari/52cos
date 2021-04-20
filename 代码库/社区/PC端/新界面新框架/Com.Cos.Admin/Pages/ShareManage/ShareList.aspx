<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ShareList.aspx.cs" Inherits="Com.Cos.Admin.Pages.ShareManage.ShareList" %>
<%@ Import Namespace="Com.Cos.Api" %>
<%@ Import Namespace="Com.Cos.Utility" %>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>H+ 后台主题UI框架 - FooTable</title>
    <meta name="keywords" content="H+后台主题,后台bootstrap框架,会员中心主题,后台HTML,响应式后台">
    <meta name="description" content="H+是一个完全响应式，基于Bootstrap3最新版本开发的扁平化主题，她采用了主流的左右两栏式布局，使用了Html5+CSS3等现代技术">

    <link rel="shortcut icon" href="favicon.ico">
    <link href="/Style/css/bootstrap.min14ed.css?v=3.3.6" rel="stylesheet">
    <link href="/Style/css/font-awesome.min93e3.css?v=4.4.0" rel="stylesheet">
    <link href="/Style/css/plugins/footable/footable.core.css" rel="stylesheet">
    <link href="/Style/css/animate.min.css" rel="stylesheet">
    <link href="/Style/css/style.min862f.css?v=4.1.0" rel="stylesheet">
    
        <!--提示框插件-->
    <link href="/Style/css/plugins/sweetalert/sweetalert.css" rel="stylesheet" />
    <script src="/Style/js/plugins/sweetalert/sweetalert.min.js"></script>
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content animated fadeInUp">
        <div class="row">
            <div class="col-sm-12">

                <div class="ibox">
                    <div class="ibox-title">
                        <h5>所有分享</h5>
                        <div class="ibox-tools">
                            <a href="projects.html" class="btn btn-primary btn-xs">创建新分享</a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="row m-b-sm m-t-sm">
                            <div class="col-md-1">
                                <button type="button" id="loading-example-btn" class="btn btn-white btn-sm"><i class="fa fa-refresh"></i>刷新</button>
                            </div>
                            <div class="col-md-11">
                                <div class="input-group">
                                    <input type="text" placeholder="请输入分享标题" class="input-sm form-control">
                                    <span class="input-group-btn">
                                        <button type="button" class="btn btn-sm btn-primary">搜索</button>
                                    </span>
                                </div>
                            </div>
                        </div>

                        <!--表格部分-->
                        <div class="project-list">
                            <table class="table table-hover">
                                <tr>
                                    <th>状态</th>
                                    <th>标题</th>
                                    <th>估价</th>
                                    <th>官方价</th>
                                    <th>排队人员</th>
                                    <th>兑换人员</th>
                                    <th>最后兑换时间</th>
                                    <th>操作</th>
                                </tr>
                                <tbody>
                                    <asp:Repeater runat="server" ID="repShareList" OnItemDataBound="repShareList_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="project-status">
                                                    <span class="label label-primary"><%#GetExamineText(Eval("Examine").ToString()) %></span>
                                                </td>
                                                <td class="project-title">
                                                    <a href="ShareDetail.aspx"><%#Eval("Title") %></a>
                                                    <br />
                                                    <small>创建于 <%#Convert.ToDateTime(Eval("AddTime")).ToString("yyyy-MM-dd HH:mm:ss") %></small>
                                                </td>
                                                <td class="project-completion">
                                                    <small>估价1： <%#Eval("Valuation1") %></small>
                                                    <small>估价2： <%#Eval("Valuation2") %></small>
                                                    <small>估价3： <%#Eval("Valuation3") %></small><br />
                                                    <small>投票1： <%#Eval("Vote1") %></small>
                                                    <small>投票2： <%#Eval("Vote2") %></small>
                                                    <small>投票3： <%#Eval("Vote3") %></small>
                                                </td>
                                                <td class="project-completion">
                                                    <small><%#Eval("Official") %></small>
                                                </td>
                                                <td class="project-people">
                                                    <asp:Repeater runat="server" ID="repQueueList">
                                                        <ItemTemplate>
                                                            <a href="projects.html">
                                                                <img alt="" class="img-circle" title="<%#MemberApi.GetNickname(Eval("UserId").ToString()) %>" src="<%#UrlConfig.Instance._Web_sq + MemberApi.GetPortraitUrl(Eval("UserId").ToString()) %>"></a>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </td>
                                                <td class="project-people">
                                                    <a href="projects.html" style="<%#string.IsNullOrEmpty(Eval("ExchangePerson").ToString())?"display: none;": ""%>">
                                                        <img alt="" class="img-circle" title="<%#MemberApi.GetNickname(Eval("ExchangePerson").ToString()) %>" src="<%#UrlConfig.Instance._Web_sq + MemberApi.GetPortraitUrl(Eval("ExchangePerson").ToString()) %>">
                                                    </a>
                                                </td>
                                                <td class="project-completion">
                                                    <small><%#Eval("EnterTime")==DBNull.Value?"":Convert.ToDateTime(Eval("EnterTime")).ToString("yyyy-MM-dd HH:mm:ss") %></small>
                                                </td>
                                                <td class="project-actions">
                                                    <a href="javascript: editor('<%#Eval("Id") %>', 'view');" class="btn btn-white btn-sm"><i class="fa fa-folder"></i>查看 </a>
                                                    <a href="javascript: editor('<%#Eval("Id") %>', 'editor');" class="btn btn-white btn-sm"><i class="fa fa-pencil"></i>编辑 </a>
                                                    <a href="javascript: deleteShare('<%#Eval("Id") %>');" class="btn btn-white btn-sm"><i class="fa fa-pencil"></i><%# Eval("Status").ToString() == "1"?"删除":"已删除" %> </a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                        <!---->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="/Style/js/jquery.min.js?v=2.1.4"></script>
    <script src="/Style/js/plugins/layer/layer.min.js"></script>
    <script>
        $(document).ready(function () { $("#loading-example-btn").click(function () { btn = $(this); simpleLoad(btn, true); simpleLoad(btn, false) }) }); function simpleLoad(btn, state) { if (state) { btn.children().addClass("fa-spin"); btn.contents().last().replaceWith(" Loading") } else { setTimeout(function () { btn.children().removeClass("fa-spin"); btn.contents().last().replaceWith(" Refresh") }, 2000) } };
    </script>
    
    <script>
        $(document).ready(function () {

        });

        //查看/编辑
        function editor(exId, show) {
            var url = "ShareView.aspx" + "?ExId=" + exId + "&Show=" + show;
            layer.open({
                type: 2,
                area: ['1000px', '400px'],
                title: false,
                skin: 'layui-layer-rim', //加上边框
                content: [url, 'yes']
            });
        }

        function deleteShare(exId) {
            swal({
                title: "您确定要删除这条信息吗",
                text: "删除后将无法恢复，请谨慎操作！",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "删除",
                closeOnConfirm: false
            }, function() {
                $.post("/Service/ShareManage/DeleteShare.ashx", {ExId: exId}, function(res) {
                    var msg = eval("(" + res + ")");
                    if (msg.status == "success") {
                        sweetAlert("修改成功");
                        location.reload();
                    } else {
                        sweetAlert("修改失败");
                    }
                }).error(function (){sweetAlert("系统出错");});
            });
        }
    </script>
</body>

