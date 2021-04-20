<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="AuthorComments.aspx.cs" Inherits="Com.Cos.Web.Pages.AuthorManage.AuthorComments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="g">
        <h3 class="crumb-title">
            <img alt='' src='<%=MemberEntity.Portrait %>?v=<%=MemberEntity.User_id %>' srcset='<%=MemberEntity.Portrait %>?v=<%=MemberEntity.User_id %> 2x' class='avatar avatar-96 photo' height='96' width='96' />
            <%=MemberEntity.nickname %> - <small>资料</small>
        </h3>
        <nav class="nav">
            <a class="" href="/Pages/AuthorManage/Author.aspx?id=<%=MemberEntity.User_id %>">
                <i class="fa fa-newspaper-o fa-fw"></i>
                资料			</a>
            <a class="" href="/Pages/AuthorManage/AuthorWorks.aspx?id=<%=MemberEntity.User_id %>">
                <i class="fa fa-file-text fa-fw"></i>
                稿件			</a>
            <a class=" active " href="/Pages/AuthorManage/AuthorComments.aspx?id=<%=MemberEntity.User_id %>">
                <i class="fa fa-comments fa-fw"></i>
                评论			</a>
            <a class="" href="/Pages/AuthorManage/AuthorRates.aspx?id=<%=MemberEntity.User_id %>">
                <i class="fa fa-wpforms"></i>
                评分集			</a>

        </nav>
        <div class="panel">
            <ul class="list-group">
                <asp:Repeater runat="server" ID="repComment">
                    <ItemTemplate>
                        <li class="list-group-item">
                            <div class="media">
                                <div class="media-left">
                                    <a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("workId") %>&type=<%#Eval("type") %>">
                                        <img class="post-list-img" src="/Style/img/46201453_10.gif" data-src="<%#GetCover(Eval("cover").ToString()) %>" alt="<%#Eval("WorksTitle") %>" width="80" height="50" />
                                    </a>
                                </div>
                                <div class="media-body">
                                    <div class="media-heading">
                                        在《<a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("workId") %>&type=<%#Eval("type") %>"><%#Eval("WorksTitle") %></a>》中发表了一条评论。						
                                    </div>
                                    <div class="excerpt">
                                        <p>
                                            <%#Eval("ReplyContent") %>
                                        </p>
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
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
