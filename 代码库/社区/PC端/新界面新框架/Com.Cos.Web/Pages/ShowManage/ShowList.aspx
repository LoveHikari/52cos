<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="ShowList.aspx.cs" Inherits="Com.Cos.Web.Pages.ShowManage.ShowList" %>
<%@OutputCache Duration="120" VaryByParam="type,page" Location="Client" %>
<%@ Import Namespace="Com.Cos.Utility" %>
<%@ Import Namespace="Com.Cos.Api" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="g">
        <div class="crumb-container">
            <nav class="crumb">
                <a href="/Default.aspx" class="home" title="返回到首页">
                    <i class="fa fa-home fa-fw"></i>
                    <span class="tx">返回到首页</span>
                </a>
                <span class="split"><i class="fa fa-angle-right"></i></span>
                <a href="/Pages/ShowManage/ShowList.aspx?type=<%=type %>&page=1"><%=SetTypeTxt() %></a>
                <span class="split"><i class="fa fa-angle-right"></i></span>目录浏览
            </nav>
        </div>
        <div id="main">
            <div class="row">
                <asp:Repeater runat="server" ID="repList">
                    <ItemTemplate>
                        <article class="g-desktop-1-4 g-tablet-1-2 card sm  post-11833 post type-post status-publish format-standard has-post-thumbnail hentry category-acgtuji category-hhjc-acgtuji tag-22 tag-23 tag-24">
                    <div class="card-bg">
                        <div class="card-cat">
                            <span style="background-color: rgba(196,97,202,.8);"><%#WorksApi.GetTypeText(Eval("workstype").ToString()) %></span>
                            <span style="background-color: rgba(238,145,111,.8);"><%#WorksApi.GetTypeText(Eval("type2").ToString()) %></span>
                        </div>
                        <a href="/<%#Eval("type") %>view-<%#Eval("WorksId") %>.html" title="<%#Eval("WorksTitle") %>" class="thumbnail-container" target="_blank">
                            <img class="thumbnail" src="<%#GetCover(Eval("cover").ToString())%>" alt="<%#Eval("WorksTitle") %>" width="320" height="180">
                        </a>
                        <a href="/<%#Eval("type") %>view-<%#Eval("WorksId") %>.html" title="<%#Eval("WorksTitle") %>" class="card-title" target="_blank">
                            <h3><%#Eval("WorksTitle") %></h3>
                        </a>
                        <div class="card-meta">
                            <a href="/Pages/AuthorManage/Author.aspx?id=<%#Eval("userId") %>" class="meta author" title="<%#Eval("nickname") %>" target="_blank">
                                <img width="32" height="32" src="<%#Eval("Portrait") %>" alt="<%#Eval("nickname") %>" class="avatar">
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
            <div class="area-pagination archive-pagination">
                <div class="pager" aria-label="文章分页导航">
                    <label for="pagination-5384" class="middle">
                        <asp:Literal runat="server" ID="litPages"></asp:Literal>
                    </label>
                    <a runat="server" id="nextpage" class="next" href="javascript:void(0);" title="下一页"><i class="fa fa-arrow-right"></i></a>
                </div>
            </div>
        </div>
        <!-- #main -->
    </div>
    <!-- .g -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>var menu_header = '<%=this.type%>'</script>
</asp:Content>
