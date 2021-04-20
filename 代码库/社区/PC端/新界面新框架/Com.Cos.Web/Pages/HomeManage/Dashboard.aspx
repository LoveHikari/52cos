<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/AccountMaster.master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Com.Cos.Web.Pages.HomeManage.Dashboard" %>

<%@ Import Namespace="Com.Cos.Utility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form" runat="server">
    <div class="row">
        <div class="account-dashboard account-dashboard-left g-tablet-2-5">
            <div class="panel">
                <div class="heading">
                    <i class="fa fa-pie-chart"></i>
                    我的统计状态
                </div>
                <div class="content">
                    <a class="media" href="/Pages/HomeManage/History.aspx" title="查看我的历史积分">
                        <div class="media-left">
                            <img class="media-object" src="/Style/img/integral.gif" alt="">
                        </div>
                        <div class="media-body">
                            <h4 class="media-heading"><strong class="total-point"><%=MemberEntity.integral %></strong></h4>
                        </div>
                    </a>
                    <div class="row">
                        <!-- posts count -->
                        <div class="g-phone-1-2">
                            我的投稿：<a href="/Pages/AuthorManage/AuthorWorks.aspx?id=<%=MemberEntity.User_id %>"><%=GetArticleNum() %></a>
                        </div>
                        <!-- comments count -->
                        <div class="g-phone-1-2">
                            我的评论：<a href="/Pages/AuthorManage/AuthorComments.aspx?id=<%=MemberEntity.User_id %>"><%=GetReplyNum() %></a>
                        </div>
                        <!-- followers count -->
                        <!-- <div class="g-phone-1-2">
						我的粉丝：<a href="">0</a>					</div> -->
                        <!-- following count -->
                        <!-- <div class="g-tablet-1-2 g-desktop-1-3">
						我在关注：<a href="">0</a>					</div> -->
                    </div>
                </div>
            </div>
            <div class="panel">
                <div class="heading">
                    <i class="fa fa-line-chart"></i>
                    我最近的积分动态		
                </div>
                <ul class="list-group history-group">
                    <asp:Repeater runat="server" ID="repIntCha">
                        <ItemTemplate>
                            <li class="list-group-item">
                                <span class="point-icon"><i class="fa fa-2x fa-fw <%#SetImg(Eval("source").ToString()) %>"></i></span>
                                <span class="point-value plus">节操 <%#SetIntegral(Eval("integral").ToString()) %></span>
                                <span class="point-value plus">热心 <%#SetIntegral(Eval("ardent").ToString()) %></span>
                                <span class="point-value plus">CN币 <%#SetIntegral(Eval("Cnbi").ToString()) %></span>
                                <span class="history-text"><%#GetIntegralSource(Eval("source").ToString()) %></span>
                                <span class="history-time"><%#UtilityHelper.GetTime(Eval("AddTime").ToString()) %></span>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>

            </div>
        </div>
        <div class="account-dashboard account-dashboard-right g-tablet-3-5">
            <!-- Recent comments for my posts -->
            <div class="dashboard-recent-comments-4-my-posts panel">
                <div class="heading">
                    <i class="fa fa-comments"></i>
                    最近给我文章的的评论		
                </div>
                <ul class="list-group history-group">
                    <asp:Repeater runat="server" ID="repComment">
                        <ItemTemplate>
                            <li class="list-group-item">
                                <div class="media">
                                    <div class="media-left">
                                        <a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("workId") %>&type=<%#Eval("type") %>">
                                            <img class="post-list-img" src="<%#GetCover(Eval("cover").ToString()) %>" alt="<%#Eval("WorksTitle") %>" width="80" height="50">
                                        </a>
                                    </div>
                                    <div class="media-body">
                                        <div class="media-heading">
                                            在《<a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("workId") %>&type=<%#Eval("type") %>"><%#Eval("WorksTitle") %></a>》中发表了一条评论。
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div class="content" runat="server" visible='<%#bool.Parse((repComment.Items.Count==0).ToString())%>'>
                                <div class="tip-status tip-status-small tip-status-info"><i class="fa fa-exclamation-circle fa-fw"></i>还没有评论</div>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </ul>

            </div>
            <div class="panel">
                <div class="heading">
                    <i class="fa fa-clock-o"></i>
                    我最近的文章		
                </div>
                <ul class="list-group history-group">
                    <asp:Repeater runat="server" ID="repArticle">
                        <ItemTemplate>
                            <li class="list-group-item">
                                <div class="media">
                                    <div class="media-left">
                                        <a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("WorksId") %>&type=works">
                                            <img class="post-list-img" src="<%#GetCover(Eval("cover").ToString()) %>" alt="<%#Eval("WorksTitle") %>" width="80" height="50">
                                        </a>
                                    </div>
                                    <div class="media-body">
                                        <div class="media-heading">
                                            发表了文章《<a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("WorksId") %>&type=works"><%#Eval("WorksTitle") %></a>》。
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div class="content" runat="server" visible='<%#bool.Parse((repArticle.Items.Count==0).ToString())%>'>
                                <div class="tip-status tip-status-small tip-status-info"><i class="fa fa-exclamation-circle fa-fw"></i>还没有文章</div>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </ul>


            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>var active_menu = "用户中心"</script>
</asp:Content>
