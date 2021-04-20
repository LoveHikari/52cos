<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="ExchangeView.aspx.cs" Inherits="Com.Cos.Web.Pages.ShowManage.ExchangeView" %>

<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="Com.Cos.Api" %>

<%@ Register Src="~/Controls/PublisherInfo.ascx" TagPrefix="uc1" TagName="PublisherInfo" %>
<%@ Register Src="~/Controls/QuickNavigation.ascx" TagPrefix="uc1" TagName="QuickNavigation" %>
<%@ Register Src="~/Controls/HotLabel.ascx" TagPrefix="uc1" TagName="HotLabel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/plugins/sweetalert/sweetalert.min.js"></script>
    <link href="/plugins/sweetalert/sweetalert.css" rel="stylesheet" />
    <!-- 引入ystep样式 -->
    <link rel="stylesheet" href="/plugins/ystep/css/ystep.css">
    <!-- 引入ystep插件 -->
    <script src="/plugins/ystep/js/ystep.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="g">
        <div class="row">
            <div id="main" class="main g-desktop-3-4">
                <!--左边正文部分-->
                <article id="post-86" class=" singular-post panel post-86 post type-post status-publish format-standard has-post-thumbnail hentry category-acgtuji category-hjhc tag-18 tag-19 tag-21 tag-20">
                    <h2 class="entry-title"><%=exchangeEntity.Title %></h2>
                    <header class="entry-header">
                        <span class="entry-meta post-category" title="分类">
                            <i class="fa fa-folder-open"></i>
                            <a href="/fxlist-1.html" rel="category tag">分享</a>
                        </span>
                        <time class="entry-meta post-time" datetime="<%=exchangeEntity.AddTime.ToString("yyyy-MM-dd HH:mm:ss") %>" title="<%=exchangeEntity.AddTime.ToString("yyyy年MM月dd日") %>">
                            <i class="fa fa-clock-o"></i><%=WorksApi.GetTime(exchangeEntity.AddTime.ToString(CultureInfo.InvariantCulture)) %>
                        </time>
                        <a class="entry-meta post-author" href="/zl/gj-<%=uid %>.html" title="查看<%=uMemberEntity.nickname %>目录下的所有文章">
                            <i class="fa fa-user"></i>
                        </a>
                    </header>
                    <div class="entry-body">
                        <div class="entry-content content-reset">
                            物品名称：<span><%=exchangeEntity.ItemName %></span><br />
                            物品包括：<span><%=exchangeEntity.Constitute %></span><br />
                            物品来自：<span><%=exchangeEntity.Source %></span><br />
                            其他描述：<span><%=exchangeEntity.Describe %></span><br />
                            原价：<span><%=exchangeEntity.Price %></span>
                        </div>
                        <div class="entry-content content-reset">
                            <asp:Literal runat="server" ID="litCertificate"></asp:Literal>
                        </div>
                        <div class="entry-content content-reset">
                            <asp:Literal runat="server" ID="litImgList"></asp:Literal>
                        </div>
                        <footer class="entry-footer">
                            <div class="entry-tags">
                                <a href="javascript:void(0);" rel="tag">进行中</a>
                                <div class="ystep1"></div>
                            </div>
                        </footer>
                        <footer class="entry-footer">
                            <div style="display: inline">公投值：</div>
                            <div class="">
                                <div class="button">
                                    <a href="javascript:void(0);" name="vote" data-val="1" rel="tag">￥<%=exchangeEntity.Valuation1 %><span style="font-size: 12px; margin-left: 14px;"><%=exchangeEntity.Vote1 %></span></a>
                                </div>
                                <div class="button">
                                    <a href="javascript:void(0);" name="vote" data-val="1" rel="tag">￥<%=exchangeEntity.Valuation2 %><span style="font-size: 12px; margin-left: 14px;"><%=exchangeEntity.Vote2 %></span></a>
                                </div>
                                <div class="button">
                                    <a href="javascript:void(0);" name="vote" data-val="1" rel="tag">￥<%=exchangeEntity.Valuation3 %><span style="font-size: 12px; margin-left: 14px;"><%=exchangeEntity.Vote3 %></span></a>
                                </div>
                                <style>
                                    .button {
                                        width: 80px;
                                        height: 60px;
                                        background-image: url(/Style/img/button.png);
                                        background-repeat: no-repeat;
                                        display: inline-block;
                                    }

                                        .button a {
                                            float: left;
                                            font-size: 16px;
                                            font-family: "微软雅黑";
                                            line-height: 15px;
                                            margin-left: 10px;
                                            margin-top: 6px;
                                        }

                                        .button:hover {
                                            background-image: url(/Style/img/button-2.png);
                                            background-repeat: no-repeat;
                                        }

                                        .button a:hover {
                                            color: #FFF;
                                        }

                                        .button span {
                                            display: block;
                                        }
                                </style>
                            </div>
                        </footer>
                        <footer class="entry-footer" style="<%=exchangeEntity.Examine != "4"? "display: none": ""%>">
                            <div style="display: inline">最终值：</div>
                            <div class="">
                                <div class="button">
                                    <a href="javascript:void(0);" name="official" data-val="1" rel="tag">￥<%=exchangeEntity.Official %></a>
                                </div>
                                <div>
                                    <a href="javascript:void(0);" onclick="SignUp('<%=this.uid %>', '<%=this.exchangeEntity.Id %>','1')" rel="tag">兑换</a>
                                </div>
                                <div><a href="javascript:void(0);" onclick="SignUp('<%=this.uid %>', '<%=this.exchangeEntity.Id %>','2')" rel="tag">会员兑换</a></div>
                            </div>
                        </footer>
                    </div>
                </article>

            </div>
            <!--右边-->
            <div id="sidebar-container" class="g-desktop-1-4">
                <div id="sidebar" class="widget-area" role="complementary">
                    <uc1:PublisherInfo runat="server" ID="PublisherInfo" />
                    <uc1:HotLabel runat="server" ID="HotLabel" />
                    <uc1:QuickNavigation runat="server" ID="QuickNavigation" />
                </div>
            </div>
            <!---->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>var menu_header = '兑换区'</script>
    <script src="../../plugins/layer/layer.js"></script>
    <script>
        $(document).ready(function () {
            $(".ystep1").loadStep({
                size: "large",
                color: "blue",
                steps: [{
                    title: "公审中",
                    content: "UP主发起的项目，三天的公共投票时间"
                }, {
                    title: "审核中",
                    content: "等待官方确认"
                }, {
                    title: "回收中",
                    content: "正在等待官方收件"
                }, {
                    title: "兑换中",
                    content: "物品已在官方手中，可以兑换"
                }, {
                    title: "已兑换",
                    content: "物品已被兑换"
                }]
            });
            $(".ystep1").setStep(<%=exchangeEntity.Examine%>);

            $("a[name='vote']").click(function () {
                var _index = $(this).attr("data-val");
                var _id = '<%=exchangeEntity.Id%>';
                var _userId = '<%=this.User_id%>';
                if (_userId == "") {
                    swal("小2提醒您", "请先登录", "error");
                    return false;
                }
                $.post("/Service/ShowManage/EvaluationVote.ashx", { Index: _index, Id: _id, UserId: _userId }, function (res) {
                    var msg = eval("(" + res + ")");

                    if (msg.status == "success") {
                        alert( "投票成功");
                    } else if (msg.status == "已参与") {
                        alert("已参与");
                    } else {
                        alert("投票失败");
                    }
                }).error(function () { alert("系统繁忙，请稍后再试"); });
            });

        });
        //兑换
        function SignUp(_userId, _exId, _classId) {
            //判断是否已有兑换
            $.post("", {}, function(res) {
                var msg = eval("(" + res + ")");
                if (msg.status == "exist") {
                    window.swal("小2提醒您", "同时只能兑换一件", "error");
                    return false;
                } else {
                    window.layer.open({
                        type: 2,
                        title: false,
                        shadeClose: true,
                        shade: 0.8,
                        area: ['380px', '90%'],
                        content: '/Pages/ShowManage/SelectAddress.aspx?uid=' + _userId + "&exId=" + _exId + "&classId=" +_classId //iframe的url
                    });
                }
            });

        }
    </script>
</asp:Content>
