<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="SearchList.aspx.cs" Inherits="Com.Cos.Web.Pages.ShowManage.SearchList" %>

<%@ Import Namespace="Com.Cos.Bll" %>
<%@ Import Namespace="Com.Cos.Api" %>
<%@ Import Namespace="Com.Cos.Utility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="g">
        <div id="main">
            <form id="fm-search-page" class="panel" method="get" action="/Pages/ShowManage/SearchList.aspx">
                <div class="content">
                    <fieldset>
                        <div class="form-group">
                            <label for="search-page-s"><i class="fa fa-search fa-fw"></i></label>
                            <input
                                type="search"
                                id="search-page-s"
                                name="s"
                                class="form-control"
                                value="<%=this.condition %>"
                                placeholder="输入关键字搜索"
                                title="输入关键字搜索"
                                autofocus>
                        </div>
                        <div class="ss-group">
                            <span class="ss-group-title">分类</span>
                            <div id="ss-cat-container" class="ss-condition-container"></div>
                        </div>
                    </fieldset>
                </div>
            </form>
            <div id="ss-result-container" class="row">
                <asp:Repeater runat="server" ID="repList">
                    <ItemTemplate>
                        <article class="g-desktop-1-4 g-tablet-1-2 card sm  post-10589 post type-post status-publish format-standard has-post-thumbnail hentry category-lzdh tag-80 tag-592 tag-593 tag-532 tag-449 tag-594">
                            <div class="card-bg">
                                <div class="card-cat">
                                    <span style="background-color: rgba(97,112,202,.8);"><%#WorksInformation.GetTypeText(Eval("workstype").ToString()) %></span>
                                    <span style="background-color: rgba(238,145,111,.8);"><%#WorksInformation.GetTypeText(Eval("type2").ToString()) %></span>
                                </div>
                                <a
                                    href="/Pages/ShowManage/view.aspx?nid=<%#Eval("WorksId") %>&type=works"
                                    title="<%#Eval("WorksTitle") %>"
                                    class="thumbnail-container"
                                    target="_blank">
                                    <img
                                        class="thumbnail"
                                        src="<%#WorksInformation.GetCover(Eval("cover").ToString())%>"
                                        alt="<%#Eval("WorksTitle") %>"
                                        width="320"
                                        height="180">
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
                                        href="/Pages/AuthorManage/Author.aspx?id=<%#Eval("User_id") %>"
                                        class="meta author"
                                        title="<%#Eval("nickname") %>"
                                        target="_blank">

                                        <img
                                            width="32"
                                            height="32"
                                            src="<%#Eval("Portrait") %>"
                                            alt="<%#Eval("nickname") %>"
                                            class="avatar">
                                        <span class="tx"><%#Eval("nickname") %></span>
                                    </a>
                                    <!-- time -->
                                    <!-- time -->
                                    <time class="meta time" datetime="<%#Convert.ToDateTime(Eval("ReleaseTime")).ToString("yyyy-MM-dd HH:mm:ss") %>" title="<%#Convert.ToDateTime(Eval("ReleaseTime")).ToString("yyyy年MM月dd日") %>"><%#UtilityHelper.GetTime(Eval("ReleaseTime").ToString()) %>
                                    </time>
                                </div>
                            </div>
                        </article>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div id="ss-search-loading" class="page-tip">
                <div class="tip-status tip-status-small tip-status-loading"><i class="fa fa-loading fa-fw"></i></div>
            </div>
        </div>
        <!-- #main -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
