<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/AccountMaster.master" AutoEventWireup="true" CodeBehind="MyReleaseExchange.aspx.cs" Inherits="Com.Cos.Web.Pages.HomeManage.MyReleaseExchange" %>

<%@ Import Namespace="Com.Cos.Api" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form" runat="server">
    <div class="row">
        <div class="account-dashboard account-dashboard-right g-tablet-3-5" style="width: 100%">
            <div class="panel">
                <div class="heading">
                    <i class="fa fa-clock-o"></i>
                    我发布的兑换
                </div>
                <ul class="list-group history-group">
                    <asp:Repeater runat="server" ID="Repeater1">
                        <ItemTemplate>
                            <li class="list-group-item">
                                <div class="media">
                                    <div class="media-left">
                                        <a href="/shareview-<%#Eval("Id") %>.html">
                                            <img class="post-list-img" src="<%#WorksApi.GetCover(Eval("cover").ToString()) %>" alt="<%#Eval("Title") %>" width="80" height="50">
                                        </a>
                                    </div>
                                    <div class="media-body">
                                        <div class="media-heading">
                                            于 <%#Eval("AddTime") %> 发表了文章《<a href="/shareview-<%#Eval("Id") %>.html"><%#Eval("Title") %></a>》。
                                        </div>
                                        <div class="media-object">
                                            当前状态：<%#GetExamineText(Eval("Examine").ToString()) %>
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div class="content" runat="server" visible='<%#bool.Parse((Repeater1.Items.Count==0).ToString())%>'>
                                <div class="tip-status tip-status-small tip-status-info"><i class="fa fa-exclamation-circle fa-fw"></i>还没有发布兑换</div>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </ul>


            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>var active_menu = "我发布的兑换"</script>
</asp:Content>
