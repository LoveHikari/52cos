<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="AuthorRates.aspx.cs" Inherits="Com.Cos.Web.Pages.AuthorManage.AuthorRates" %>
<%@ Import Namespace="Com.Cos.Bll" %>

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
            <a class="" href="/Pages/AuthorManage/AuthorComments.aspx?id=<%=MemberEntity.User_id %>">
                <i class="fa fa-comments fa-fw"></i>
                评论			</a>
            <a class=" active " href="/Pages/AuthorManage/AuthorRates.aspx?id=<%=MemberEntity.User_id %>">
                <i class="fa fa-wpforms"></i>
                评分集			</a>

        </nav>
        <div class="panel">
            <div class="mod-body">
                <ul class="row post-img-lists">
                    <asp:Repeater runat="server" ID="repWork">
                        <ItemTemplate>
                            <article class="g-phone-1-2 g-tablet-1-3 g-desktop-1-4 card lg ">

                                <div class="card-bg">

                                    <a
                                        href="/Pages/ShowManage/view.aspx?nid=<%#Eval("WorksId") %>&type=works"
                                        title="<%#Eval("WorksTitle") %>"
                                        class="thumbnail-container"
                                        target="_blank">


                                        <img class="thumbnail" src="/Style/img/46201453_10.gif" data-src="<%#GetCover(Eval("cover").ToString())%>" alt="<%#Eval("WorksTitle") %>" width="320" height="180">

                                        <div class="card-cat">
                                            <span style="background-color: rgba(196,97,202,.8);"><%#SysParaBll.Instance.GetModel(Convert.ToInt32(Eval("workstype")))?.RefText %></span>
                                            <span style="background-color: rgba(97,180,202,.8);"><%#SysParaBll.Instance.GetModel(Convert.ToInt32(Eval("type2")))?.RefText %></span>
                                        </div>
                                    </a>

                                    <a
                                        href="/Pages/ShowManage/view.aspx?nid=<%#Eval("WorksId") %>&type=works"
                                        title="<%#Eval("WorksTitle") %>"
                                        class="card-title"
                                        target="_blank">

                                        <h3><%#Eval("WorksTitle") %></h3>

                                    </a>

                                    <div class="card-meta">

                                        <a
                                            href="/Pages/HomeManage/Home.aspx?uid=<%#Eval("User_id") %>"
                                            class="meta author"
                                            title="<%#Eval("nickname") %>"
                                            target="_blank">

                                            <img
                                                width="32"
                                                height="32"
                                                src="/Style/img/1.jpg"
                                                data-src="<%#Eval("Portrait") %>"
                                                alt="Freddy@Moe"
                                                class="avatar">
                                            <span class="tx"><%#Eval("nickname") %></span>
                                        </a>
                                        <span class="meta views" title="点赞数"><i class="fa fa-play-circle"></i><%#Eval("GoodNo") %></span>
                                        <!-- comments count -->
                                        <span class="meta comments-count" title="评论">
                                            <i class="fa fa-comment"></i><%#GetCommentNumber(Eval("Worksid").ToString()) %>
                                        </span>
                                    </div>
                                </div>
                            </article>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="archive-pagination">
                <div class="pager" aria-label="文章分页导航">
                    <label for="pagination-9818" class="middle">
                        <asp:Literal runat="server" ID="litPages"></asp:Literal>
                    </label>

                    <a class="next" runat="server" id="nextpage" href="javascript:void(0);" title="下一页"><i class="fa fa-arrow-right"></i></a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
