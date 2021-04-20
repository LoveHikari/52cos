<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PublisherArticle.ascx.cs" Inherits="Com.Cos.Web.Controls.PublisherArticle" %>
        <aside id="widget_author_posts-2">
            <div class="widget widget_author_posts">
                <div class="heading ">
                    <h2 class="widget-title"><a href="/Pages/AuthorManage/AuthorWorks.aspx?id=<%=MemberEntity.User_id %>" title="查看更多作者的文章。"><i class="fa fa-file-text"></i>作者文章</a></h2>
                </div>
                <div class="card-container">
                    <div class="row widget-author-post-random">
                        <asp:Literal runat="server" ID="litArticle"></asp:Literal>
                    </div>
                </div>
            </div>
        </aside>