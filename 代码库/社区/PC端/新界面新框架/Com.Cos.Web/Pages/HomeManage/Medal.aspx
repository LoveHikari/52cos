<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/AccountMaster.master" AutoEventWireup="true" CodeBehind="Medal.aspx.cs" Inherits="Com.Cos.Web.Pages.HomeManage.Medal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel='stylesheet' id='frontend-css' href='/Style/css/frontend-logged-default.css' type='text/css' media='all' />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form" runat="server">
    <div class="well">
        <p>欢迎来到勋章中心。您可以在这里获取一些勋章。</p>
    </div>
    <!-- list preset medal items -->
    <fieldset>
        <legend class="label label-default"><i class="fa fa-gg-circle"></i>预设勋章</legend>
        <div class="well">
            <p>这里有众多勋章任你挑选，只要满足勋章获得要求，即可获得哟</p>
        </div>
        <div class="medal-my-info row">
            <!-- my points count -->
            <div class="g-tablet-1-3">
                <img src="/Style/img/integral.gif" alt="节操" width="16" height="16">
                我的节操： 
					<span id="points-number"><%=MemberEntity.integral %></span>
                我的热心： 
					<span id="points-ardent"><%=MemberEntity.ardent %></span>
                我的CN币： 
					<span id="points-CNbi"><%=MemberEntity.CNbi %></span>
            </div>
            <!-- posts count -->
            <div class="g-tablet-1-3">
                <i class="fa fa-paint-brush"></i>
                我的文章： 
					<span id="posts-number"><%=GetArticleNum() %></span>
            </div>
            <!-- comments count -->
            <div class="g-tablet-1-3">
                <i class="fa fa-comments"></i>
                我的评论： 
					<span id="comments-number"><%=GetReplyNum() %></span>
            </div>
        </div>
        <div class="preset-medals medal-container">
            <asp:Repeater runat="server" ID="repMedal">
                <ItemTemplate>
                    <a href="javascript:;" class="medal-item-container tooltip top preset-medal" title="<%#Eval("RefText") %> - <%#Eval("RefDesc") %>" data-id="demo-medal-posts-talent" disabled>
                        <img class="medal-img" src="<%#Eval("imgUrl") %>" alt="<%#Eval("RefText") %>" width="40" height="65">
                        <span class="insufficient-condition"><i class="fa fa-ban"></i></span>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </fieldset>

    <fieldset>
        <legend class="label label-default"><i class="fa fa-usd"></i>我的勋章</legend>
        <div id="my-medal-container">
            <asp:Repeater runat="server" ID="repMyMedal">
                <ItemTemplate>
                    <a href="javascript:;" class="medal-item-container tooltip top preset-medal" title="<%#Eval("RefText") %> - <%#Eval("RefDesc") %>" data-id="demo-medal-posts-talent">
                        <img class="medal-img" src="<%#Eval("imgUrl") %>" alt="<%#Eval("RefText") %>" width="40" height="65">
                    </a>
                </ItemTemplate>
                <FooterTemplate>
                    <div class="page-tip" Visible='<%#bool.Parse((repMyMedal.Items.Count==0).ToString())%>'>
                        <div class="tip-status tip-status-small tip-status-info">
                            <i class="fa fa-exclamation-circle fa-fw"></i> 
                            您还没有任何勋章哦。您可以在上方添加或创建自己的勋章。
                        </div>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </fieldset>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>var active_menu="勋章"</script>
</asp:Content>
