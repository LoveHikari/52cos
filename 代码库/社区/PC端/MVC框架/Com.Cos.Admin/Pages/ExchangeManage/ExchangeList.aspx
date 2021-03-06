<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="ExchangeList.aspx.cs" Inherits="Com.Cos.Admin.Pages.ExchangeManage.ExchangeList" %>

<%@ Register Src="../../Controls/ExchangeOperateControl.ascx" TagPrefix="uc1" TagName="ExchangeOperateControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>兑换管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav class="breadcrumb"><i class="Hui-iconfont">&#xe67f;</i> 首页 <span class="c-gray en">&gt;</span> 资讯管理 <span class="c-gray en">&gt;</span> 资讯列表 <a class="btn btn-success radius r" style="line-height: 1.6em; margin-top: 3px" href="javascript:location.replace(location.href);" title="刷新"><i class="Hui-iconfont">&#xe68f;</i></a></nav>
    <div class="page-container">
        <div class="text-c">
            <button onclick="removeIframe()" class="btn btn-primary radius">关闭选项卡</button>
            <span class="select-box inline">
                <select name="" class="select">
                    <option value="0">全部分类</option>
                    <option value="1">分类一</option>
                    <option value="2">分类二</option>
                </select>
            </span>日期范围：
		<input type="text" onfocus="WdatePicker({ maxDate:'#F{$dp.$D(\'logmax\')||\'%y-%M-%d\'}' })" id="logmin" class="input-text Wdate" style="width: 120px;">
            -
		<input type="text" onfocus="WdatePicker({ minDate:'#F{$dp.$D(\'logmin\')}',maxDate:'%y-%M-%d' })" id="logmax" class="input-text Wdate" style="width: 120px;">
            <input type="text" name="" id="" placeholder=" 资讯名称" style="width: 250px" class="input-text">
            <button name="" id="" class="btn btn-success" type="submit"><i class="Hui-iconfont">&#xe665;</i> 搜资讯</button>
        </div>
        <div class="cl pd-5 bg-1 bk-gray mt-20"><span class="l"><a href="javascript:;" onclick="datadel()" class="btn btn-danger radius"><i class="Hui-iconfont">&#xe6e2;</i> 批量删除</a> <a class="btn btn-primary radius" data-title="添加资讯" data-href="article-add.html" onclick="Hui_admin_tab(this)" href="javascript:;"><i class="Hui-iconfont">&#xe600;</i> 添加资讯</a></span> <span class="r">共有数据：<strong>54</strong> 条</span> </div>
        <div class="mt-20">
            <table class="table table-border table-bordered table-bg table-hover table-sort">
                <thead>
                    <tr class="text-c">
                        <th width="25">
                            <input type="checkbox" name="" value=""></th>
                        <th width="80">ID</th>
                        <th>标题</th>
                        <th>原价</th>
                        <th>最终价</th>
                        <th width="80">分类</th>
                        <th width="80">发布人</th>
                        <th width="120">发布时间</th>
                        <th width="75">浏览次数</th>
                        <th width="60">发布状态</th>
                        <th width="120">操作</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="repExchage">
                        <ItemTemplate>
                            <tr class="text-c">
                                <td>
                                    <input type="checkbox" value="" name=""></td>
                                <td><%#Eval("Id") %></td>
                                <td class="text-l"><u style="cursor: pointer" class="text-primary" onclick="article_edit('查看','article-zhang.html','10001')" title="查看"><%#Eval("Title") %></u></td>
                                <td><%#Eval("Price") %></td>
                                <td><%#Eval("Official") %></td>
                                <td><%#Eval("ClassName") %></td>
                                <td><%#Eval("nickname") %></td>
                                <td><%#Eval("AddTime") %></td>
                                <td>21212</td>
                                <td class="td-status"><span class="label <%#Eval("ExamineName").ToString()=="已结束"?"label-defaunt":"label-success" %> radius"><%#Eval("ExamineName") %></span></td>
                                <td class="f-14 td-manage">
                                    <uc1:ExchangeOperateControl runat="server" id="ExchangeOperateControl" ExamineName='<%#Eval("ExamineName") %>' />
                                    <a style="text-decoration: none" class="ml-5" onclick="article_edit('资讯编辑','article-add.html','10001')" href="javascript:;" title="编辑"><i class="Hui-iconfont">&#xe6df;</i></a>
                                    <a style="text-decoration: none" class="ml-5" onclick="article_del(this,'10001')" href="javascript:;" title="删除"><i class="Hui-iconfont">&#xe6e2;</i></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
    <!--请在下方写此页面业务相关的脚本-->
    <script type="text/javascript" src="../../Scripts/plugins/My97DatePicker/4.8/WdatePicker.js"></script>
    <script type="text/javascript" src="../../Scripts/plugins/datatables/1.10.0/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="../../Scripts/plugins/laypage/1.2/laypage.js"></script>
    <script type="text/javascript">
        $('.table-sort').dataTable({
            "aaSorting": [[1, "desc"]],//默认第几个排序
            "bStateSave": true,//状态保存
            "aoColumnDefs": [
                //{"bVisible": false, "aTargets": [ 3 ]} //控制列的隐藏显示
                { "orderable": false, "aTargets": [0, 8] }// 不参与排序的列
            ]
        });

        /*资讯-添加*/
        function article_add(title, url, w, h) {
            var index = layer.open({
                type: 2,
                title: title,
                content: url
            });
            layer.full(index);
        }
        /*资讯-编辑*/
        function article_edit(title, url, id, w, h) {
            var index = layer.open({
                type: 2,
                title: title,
                content: url
            });
            layer.full(index);
        }
        /*资讯-删除*/
        function article_del(obj, id) {
            layer.confirm('确认要删除吗？', function (index) {
                $.ajax({
                    type: 'POST',
                    url: '',
                    dataType: 'json',
                    success: function (data) {
                        $(obj).parents("tr").remove();
                        layer.msg('已删除!', { icon: 1, time: 1000 });
                    },
                    error: function (data) {
                        console.log(data.msg);
                    },
                });
            });
        }

        /*兑换-审核*/
        function article_shenhe(obj, id) {
            layer.prompt({ title: '输入最终值，并确认', formType: 3 }, function (text, index) {
                $.post("../../Service/ExchangeManage/UpdateExamine.ashx", { Id: id, Official: text, Examine: 1}, function (res) {
                    var msg = eval("(" + res + ")");
                    if (msg.status == "success") {
                        parent.$('a.btn-success i').click();
                        layer.close(index);
                    }
                    
                });
                
            });

        }
        /*兑换-回收*/
        function article_huishou(obj, id) {
            layer.confirm('确认要回收吗？', function (index) {
                $.post("../../Service/ExchangeManage/UpdateExamine.ashx", { Id: id,Examine: 2 }, function (res) {
                    var msg = eval("(" + res + ")");
                    if (msg.status == "success") {
                        layer.msg('已回收!', { icon: 5, time: 1000 });
                        parent.$('a.btn-success i').click();
                        layer.close(index);
                    }

                });
            });

        }
        /*兑换-下架*/
        function article_stop(obj, id) {
            layer.confirm('确认要下架吗？', function (index) {
                $.post("../../Service/ExchangeManage/UpdateExamine.ashx", { Id: id, Examine: -1 }, function (res) {
                    var msg = eval("(" + res + ")");
                    if (msg.status == "success") {
                        layer.msg('已下架!', { icon: 6, time: 1000 });
                        parent.$('a.btn-success i').click();
                        layer.close(index);
                    }

                });
            });
        }

        /*兑换-发布*/
        function article_start(obj, id) {
            layer.confirm('确认要发布吗？', function (index) {
                $.post("../../Service/ExchangeManage/UpdateExamine.ashx", { Id: id, Examine: 4 }, function (res) {
                    var msg = eval("(" + res + ")");
                    if (msg.status == "success") {
                        layer.msg('已发布!', { icon: 6, time: 1000 });
                        parent.$('a.btn-success i').click();
                        layer.close(index);
                    }

                });
                
            });
        }
        /*资讯-申请上线*/
        function article_shenqing(obj, id) {
            $(obj).parents("tr").find(".td-status").html('<span class="label label-default radius">待审核</span>');
            $(obj).parents("tr").find(".td-manage").html("");
            layer.msg('已提交申请，耐心等待审核!', { icon: 1, time: 2000 });
        }

    </script>
</asp:Content>
