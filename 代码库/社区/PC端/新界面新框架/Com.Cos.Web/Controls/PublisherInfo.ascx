<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PublisherInfo.ascx.cs" Inherits="Com.Cos.Web.Controls.PublisherInfo" %>
<%@ Import Namespace="Com.Cos.Api" %>
        <aside id="theme_widget_author-2">
            <div class="widget theme_widget_author">
                <div id="widget-author-card" class="widget-container content">
                    <a href="/Pages/AuthorManage/Author.aspx?id=<%=MemberEntity.User_id %>" class="author-link" title="查看作者资料">
                        <img alt='' src="<%=MemberEntity.Portrait %>" srcset='<%=MemberEntity.Portrait %> 2x' class='avatar avatar-100 photo' height='100' width='100' /><h3 class="author-card-name"><%=MemberEntity.nickname %></h3>
                        <small class="label label-primary">认证作者</small></a><p class="author-card-description" title="<%=MemberEntity.Describe %>"><%=MemberEntity.Describe %></p>
                    <div class="author-card-meta-links">
                        <a class="tooltip" href="/Pages/AuthorManage/AuthorWorks.aspx?id=<%=MemberEntity.User_id %>" title="查看作者的文章" target="_blank"><span class="tx"><i class="fa fa-fw fa-file-text"></i></span><span class="count"><%=MemberApi.GetArticleNum(MemberEntity.User_id.ToString()) %></span></a>
                        <a class="tooltip" href="/Pages/AuthorManage/AuthorComments.aspx?id=<%=MemberEntity.User_id %>" title="查看作者的评论" target="_blank"><span class="tx"><i class="fa fa-fw fa-comments"></i></span><span class="count"><%=MemberApi.GetReplyNum(MemberEntity.User_id.ToString()) %></span></a>
                        <a class="tooltip" href="/Pages/HomeManage/Bomb.aspx" rel="nofollow" title="开始轰炸，BOOM！" target="_blank"><span class="tx"><i class="fa fa-fw fa-bomb"></i></span><span class="count"><%=String.Format("{0:N0}", MemberEntity.integral) %></span></a>
                        <a target="_blank" class="tooltip" href="/Pages/HomeManage/Translate.aspx" title="发送私信"><span class="tx"><i class="fa fa-envelope"></i></span><span class="count">勾搭</span></a>
                    </div>

                    <a class="medal-container" target="_blank" href="/Pages/HomeManage/Medal.aspx">
                        <asp:Repeater runat="server" ID="repMedal">
                            <ItemTemplate>
                                <span class="medal-item-container tooltip top" title="<%#Eval("RefText") %> - <%#Eval("RefDesc") %>">
                                    <img class="medal-img" data-src="<%#Eval("imgUrl") %>" src="/Style/img/46201453_10.gif" width="40" height="65" alt="<%#Eval("RefText") %>">
                                </span>
                            </ItemTemplate>
                        </asp:Repeater>
                    </a>
                </div>
            </div>
        </aside>