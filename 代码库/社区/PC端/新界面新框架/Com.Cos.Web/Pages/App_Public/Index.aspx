<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Com.Cos.Web.Pages.App_Public.Index" %>

<%@ Import Namespace="Com.Cos.Bll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/plugins/swipeslider/dist/swipeslider.css">
    <script type="text/javascript" src="/plugins/swipeslider/dist/swipeslider.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--排头-->
    <div class="theme_custom_slidebox-container theme_custom_slidebox-scroller">
        <div class="heading" data-title="52cos平台 官方形象人设即将揭晓！">
            <asp:Literal runat="server" ID="litPoster"></asp:Literal>
            <a class="header-link" href="#" target="_blank" style="height: 170px;"></a>
            <%--<div class="num">
                <div class="menu-wrapper">
                    <div class="search on" id="fm-search" data-focus-target="#fm-search-s" style="top: -50px; right: 20px; z-index: 1;">
                        <a href="javascript:;" class="tool search fa fa-search fa-2x" data-toggle-target="#fm-search" data-focus-target="#fm-search-s" data-icon-active="fa-arrow-down" data-icon-original="fa-search" style="float: right; margin-top: 4px" title="搜索"></a>
                        <input id="fm-search-s" name="s" class="form-control" placeholder="请输入搜索关键词" value="" type="search" required="" style="width: 250px; height: 35px; float: right; text-align: left;" />
                    </div>
                </div>
            </div>--%>
        </div>
        <div style="clear: both;"></div>
        <div class="area-main">
            <div class="item large" style="margin-left: 20px">
                <article class="container">
                    <section>
                        <figure id="sample_slider" class="swipslider">
                            <ul class="sw-slides">
                                <asp:Repeater runat="server" ID="repSlide">
                                    <ItemTemplate>
                                        <li class="sw-slide">
                                            <img src="<%#Eval("ImgUrl") %>" alt="<%#Eval("ImgText") %>" title="<%#Eval("ImgText") %>" width="640px" height="400px">
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </figure>
                    </section>
                </article>
            </div>
            <div class="item" style="margin-left: 20px">
                <asp:Repeater runat="server" ID="repTop">
                    <ItemTemplate>
                        <a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("WorksId") %>&type=works" title="<%#Eval("WorksTitle") %>" style="background-image: url(<%#GetCover(Eval("cover").ToString()) %>);">
                            <h2><%#Eval("WorksTitle") %></h2>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <!---->
    <%--<div class="g theme_custom_slidebox-ad-below">
        <iframe src="http://danmu.gameker.net/91cj.php?title=91moesp1&src=91moesp" width="100%" height="145" frameborder="no" marginwidth="0" marginheight="0" scrolling="no"></iframe>
        <b><font color="red"><i class="fa fa-volume-up"></i>欢迎来到91萌 91moe.com！绅士动漫交流群：「518914235」 微博: 91萌<iframe src="http://widget.weibo.com/relationship/followbutton.php?btn=red&style=1&uid=1761577334&width=67&height=24&language=zh_cn" width="67" height="24" frameborder="0" scrolling="no" marginheight="0"></iframe>---2016！祝各位早日找到心仪的对象~喵~~！</font></b>
    </div>--%>

    <!--正文-->
    <div class="g">
        <div class="recomm-container hidden-sm">
            <div class="home-recomm mod panel">
                <div class="heading">
                    <h2 class="title">
                        <span class="bg">
                            <a href="#">
                                <i class="fa fa-star-o"></i>
                                萌推荐
                            </a>
                        </span>
                    </h2>
                    <a href="#" class="more">更多 &raquo;</a>
                </div>
                <div class="row">
                    <asp:Repeater runat="server" ID="repRecommend">
                        <ItemTemplate>
                            <article class="g-tablet-1-2 g-tablet-1-4 card lg ">
                                <div class="card-bg">
                                    <a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("WorksId") %>&type=works" title="<%#Eval("WorksTitle") %>" class="thumbnail-container" target="_blank">
                                        <img class="thumbnail" src="<%#GetCover(Eval("cover").ToString()) %>" alt="<%#Eval("WorksTitle") %>" width="320" height="180">
                                        <div class="card-cat">
                                            <span style="background-color: rgba(196,97,202,.8);"><%#SysParaBll.Instance.GetModel(Convert.ToInt32(Eval("workstype")))?.RefText %></span>
                                            <span style="background-color: rgba(97,180,202,.8);"><%#SysParaBll.Instance.GetModel(Convert.ToInt32(Eval("type2")))?.RefText %></span>
                                        </div>
                                    </a>
                                    <a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("WorksId") %>&type=works" title="<%#Eval("WorksTitle") %>" class="card-title" target="_blank">
                                        <h3><%#Eval("WorksTitle") %></h3>
                                    </a>
                                    <div class="card-meta">
                                        <a href="/Pages/HomeManage/Home.aspx?uid=<%#Eval("User_id") %>" class="meta author" title="<%#Eval("nickname") %>" target="_blank">
                                            <img width="32" height="32" src="<%#Eval("Portrait") %>" alt="<%#Eval("nickname") %>" class="avatar">
                                            <span class="tx"><%#Eval("nickname") %></span>
                                        </a>
                                        <span class="meta views" title="点赞数"><i class="fa fa-play-circle"></i><%#Eval("GoodNo") %></span>
                                        <span class="meta comments-count" title="评论">
                                            <i class="fa fa-comment"></i><%#GetCommentNumber(Eval("Worksid").ToString()) %>
                                        </span>
                                    </div>
                                </div>
                            </article>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>

        <div class="row">
            <!--左边-->
            <div id="main" class="g-desktop-3-4">
                <!--cos/日常/绘画/摄影-->
                <asp:Repeater runat="server" ID="repList" OnItemDataBound="repList_ItemDataBound">
                    <ItemTemplate>
                        <div id="homebox-<%#Eval("RefValue") %>" class="homebox panel mod">
                            <div class="heading">
                                <h2 class="title"><span class="bg"><a href="/zplist-<%#Eval("RefValue") %>-1.html" title="更多<%#Gettitle(Eval("RefText").ToString()) %>"><i class="<%#GetStyle(Eval("RefText").ToString()) %>"></i><%#Gettitle(Eval("RefText").ToString()) %></a></span></h2>
                                <%--<div class="extra">
                            <div class="keywords"><a href="http://www.91moe.com/moe/acgtuji/hjhc">画集画册</a><a href="http://www.91moe.com/moe/acgtuji/cosplay">COS图集</a><a href="http://www.91moe.com/moe/acgtuji/gif">GIF动图</a><a href="http://www.91moe.com/moe/acgtuji/hhjc-acgtuji">绘画教程</a><a href="http://www.91moe.com/moe/acgtuji/ychh">原创绘画</a></div>
                        </div>--%>
                            </div>
                            <div class="row">
                                <asp:Repeater runat="server" ID="repcos">
                                    <ItemTemplate>
                                        <article class="g-tablet-1-3 card sm post-12435 post type-post status-publish format-standard has-post-thumbnail hentry category-acgtuji category-hjhc tag-19 tag-21 tag-24 tag-collection">
                                            <div class="card-bg">
                                                <a href="/worksview-<%#Eval("WorksId") %>.html" title="<%#Eval("WorksTitle") %>" class="thumbnail-container" target="_blank">
                                                    <img class="thumbnail" src="/Style/img/46201453_10.gif" data-src="<%#GetCover(Eval("cover").ToString()) %>" alt="<%#Eval("WorksTitle") %>" width="320" height="180"></a><a href="/workview-<%#Eval("WorksId") %>.html" title="<%#Eval("Workstitle") %>" class="card-title" target="_blank"><h3><%#Eval("Workstitle") %></h3>
                                                    </a>
                                                <div class="card-meta">
                                                    <a href="/home-<%#Eval("User_id") %>.html" class="meta author" title="<%#Eval("nickname") %>" target="_blank">
                                                        <img width="32" height="32" src="/Upload/Portrait/1.jpg" data-src="<%#Eval("Portrait") %>" alt="<%#Eval("nickname") %>" class="avatar">
                                                        <span class="tx"><%#Eval("nickname") %></span></a><time class="meta time" datetime="<%#Convert.ToDateTime(Eval("ReleaseTime")).ToString("yyyy-MM-dd HH:mm:ss") %>" title="<%#Convert.ToDateTime(Eval("ReleaseTime")).ToString("yyyy年MM月dd日") %>"><%#GetTime(Eval("ReleaseTime").ToString()) %></time>
                                                </div>
                                            </div>
                                        </article>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Repeater runat="server" ID="repcos2">
                                    <ItemTemplate>
                                        <article class="g-tablet-1-4 card sm post-12426 post type-post status-publish format-standard has-post-thumbnail hentry category-cosplay category-acgtuji tag-cosplay tag-625 tag-631 tag-624">
                                            <div class="card-bg">
                                                <a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("WorksId") %>&type=works" title="<%#Eval("WorksTitle") %>" class="thumbnail-container" target="_blank">
                                                    <img class="thumbnail" src="/Style/img/46201453_10.gif" data-src="<%#GetCover(Eval("cover").ToString()) %>" alt="<%#Eval("WorksTitle") %>" width="320" height="180"></a><a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("WorksId") %>&type=works" title="<%#Eval("Workstitle") %>" class="card-title" target="_blank"><h3><%#Eval("Workstitle") %></h3>
                                                    </a>
                                                <div class="card-meta">
                                                    <a href="/Pages/HomeManage/Home.aspx?uid=<%#Eval("User_id") %>" class="meta author" title="<%#Eval("nickname") %>" target="_blank">
                                                        <img width="32" height="32" src="/Upload/Portrait/1.jpg" data-src="<%#Eval("Portrait") %>" alt="<%#Eval("nickname") %>" class="avatar">
                                                        <span class="tx"><%#Eval("nickname") %></span></a><time class="meta time" datetime="<%#Convert.ToDateTime(Eval("ReleaseTime")).ToString("yyyy-MM-dd HH:mm:ss") %>" title="<%#Convert.ToDateTime(Eval("ReleaseTime")).ToString("yyyy年MM月dd日") %>"><%#GetTime(Eval("ReleaseTime").ToString()) %></time>
                                                </div>
                                            </div>
                                        </article>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <a href="/Pages/ShowManage/ShowList.aspx?type=<%#Eval("RefValue") %>&page=1" class="below-more btn btn-block btn-default" target="_blank">更多<%#Gettitle(Eval("RefText").ToString()) %> <i class="fa fa-caret-right"></i></a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <!--合作-->
                <%--<div id="homebox-1454299169422" class="homebox panel mod">
                    <div class="heading">
                        <h2 class="title"><span class="bg"><a href="/Pages/ShowManage/ShowList.aspx?type=reprint&page=1" title="更多合作"><i class="fa fa-smile-o"></i>合作</a></span></h2>
                        <%--<div class="extra">
                            <div class="keywords"><a href="http://www.91moe.com/moe/manhua/lzmh">连载漫画</a><a href="http://www.91moe.com/moe/manhua/mhzh">漫画综合</a></div>
                        </div>--%
                    </div>
                    <div class="row">
                        <asp:Repeater runat="server" ID="repCoo">
                            <ItemTemplate>
                                <article class="g-tablet-1-3 card sm post-11554 post type-post status-publish format-standard has-post-thumbnail hentry category-manhua category-mhzh tag-582 tag-583 tag-581">
                                    <div class="card-bg">
                                        <a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("id") %>&type=reprint" title="<%#Eval("title") %>" class="thumbnail-container" target="_blank">
                                            <img class="thumbnail" src="/Style/img/46201453_10.gif" data-src="<%#GetCover(Eval("cover").ToString()) %>" alt="<%#Eval("title") %>" width="320" height="180"></a><a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("id") %>&type=reprint" title="<%#Eval("title") %>" class="card-title" target="_blank"><h3><%#Eval("title") %></h3>
                                            </a>
                                        <div class="card-meta">
                                            <a href="/Pages/HomeManage/Home.aspx?uid=<%#Eval("User_id") %>" class="meta author" title="<%#Eval("nickname") %>" target="_blank">
                                                <img width="32" height="32" src="/Upload/Portrait/1.jpg" data-src="<%#Eval("Portrait") %>" alt="<%#Eval("nickname") %>" class="avatar">
                                                <span class="tx"><%#Eval("nickname") %></span></a><time class="meta time" datetime="<%#Convert.ToDateTime(Eval("ReleaseTime")).ToString("yyyy-MM-dd HH:mm:ss") %>" title="<%#Convert.ToDateTime(Eval("ReleaseTime")).ToString("yyyy年MM月dd日") %>"><%#GetTime(Eval("ReleaseTime").ToString()) %></time>
                                        </div>
                                    </div>
                                </article>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater runat="server" ID="repCoo2">
                            <ItemTemplate>
                                <article class="g-tablet-1-4 card sm post-6744 post type-post status-publish format-standard has-post-thumbnail hentry category-manhua category-lzmh tag-172 tag-324 tag-21 tag-323">
                                    <div class="card-bg">
                                        <a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("id") %>&type=reprint" title="<%#Eval("title") %>" class="thumbnail-container" target="_blank">
                                            <img class="thumbnail" src="/Style/img/46201453_10.gif" data-src="<%#GetCover(Eval("cover").ToString()) %>" alt="<%#Eval("title") %>" width="320" height="180"></a><a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("id") %>&type=reprint" title="<%#Eval("title") %>" class="card-title" target="_blank"><h3><%#Eval("title") %></h3>
                                            </a>
                                        <div class="card-meta">
                                            <a href="/Pages/HomeManage/Home.aspx?uid=<%#Eval("User_id") %>" class="meta author" title="<%#Eval("nickname") %>" target="_blank">
                                                <img width="32" height="32" src="/Upload/Portrait/1.jpg" data-src="<%#Eval("Portrait") %>" alt="<%#Eval("nickname") %>" class="avatar">
                                                <span class="tx"><%#Eval("nickname") %></span></a><time class="meta time" datetime="<%#Convert.ToDateTime(Eval("ReleaseTime")).ToString("yyyy-MM-dd HH:mm:ss") %>" title="<%#Convert.ToDateTime(Eval("ReleaseTime")).ToString("yyyy年MM月dd日") %>"><%#GetTime(Eval("ReleaseTime").ToString()) %></time>
                                        </div>
                                    </div>
                                </article>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <a href="/Pages/ShowManage/ShowList.aspx?type=reprint&page=1" class="below-more btn btn-block btn-default" target="_blank">更多合作 <i class="fa fa-caret-right"></i></a>
                </div>--%>
                <!--活动-->
                <div id="homebox-1447696628513" class="homebox panel mod">
                    <div class="heading">
                        <h2 class="title"><span class="bg"><a href="/Pages/ShowManage/ShowList.aspx?type=activity&page=1" title="更多活动资讯"><i class="fa fa-newspaper-o"></i>活动资讯</a></span></h2>
                        <%--<div class="extra">
                            <div class="keywords"><a href="http://www.91moe.com/moe/acg-news/dmzx">动漫资讯</a><a href="http://www.91moe.com/moe/acg-news/game-news">游戏资讯</a></div>
                        </div>--%>
                    </div>

                    <div class="row">
                        <asp:Repeater runat="server" ID="repAct">
                            <ItemTemplate>
                                <article class="g-tablet-1-3 card sm post-12490 post type-post status-publish format-standard hentry category-acg-news category-dmzx tag-527">
                                    <div class="card-bg">
                                        <a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("id") %>&type=activity" title="<%#Eval("title") %>" class="thumbnail-container" target="_blank">
                                            <img class="thumbnail" src="/Style/img/46201453_10.gif" data-src="<%#GetCover(Eval("cover").ToString()) %>" alt="<%#Eval("title") %>" width="320" height="180"></a><a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("id") %>&type=activity" title="<%#Eval("title") %>" class="card-title" target="_blank"><h3><%#Eval("title") %></h3>
                                            </a>
                                        <div class="card-meta">
                                            <a href="/Pages/HomeManage/Home.aspx?uid=<%#Eval("User_id") %>" class="meta author" title="<%#Eval("nickname") %>" target="_blank">
                                                <img width="32" height="32" src="/Upload/Portrait/1.jpg" data-src="<%#Eval("Portrait") %>" alt="<%#Eval("nickname") %>" class="avatar">
                                                <span class="tx"><%#Eval("nickname") %></span></a><time class="meta time" datetime="<%#Convert.ToDateTime(Eval("ReleaseTime")).ToString("yyyy-MM-dd HH:mm:ss") %>" title="<%#Convert.ToDateTime(Eval("ReleaseTime")).ToString("yyyy年MM月dd日") %>"><%#GetTime(Eval("ReleaseTime").ToString()) %></time>
                                        </div>
                                    </div>
                                </article>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater runat="server" ID="repAct2">
                            <ItemTemplate>
                                <article class="g-tablet-1-4 card sm post-12480 post type-post status-publish format-standard hentry category-acg-news category-dmzx tag-634">
                                    <div class="card-bg">
                                        <a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("id") %>&type=activity" title="<%#Eval("title") %>" class="thumbnail-container" target="_blank">
                                            <img class="thumbnail" src="/Style/img/46201453_10.gif" data-src="<%#GetCover(Eval("cover").ToString()) %>" alt="<%#Eval("title") %>" width="320" height="180"></a><a href="/Pages/ShowManage/view.aspx?nid=<%#Eval("id") %>&type=activity" title="<%#Eval("title") %>" class="card-title" target="_blank"><h3><%#Eval("title") %></h3>
                                            </a>
                                        <div class="card-meta">
                                            <a href="/Pages/HomeManage/Home.aspx?uid=<%#Eval("User_id") %>" class="meta author" title="<%#Eval("nickname") %>" target="_blank">
                                                <img width="32" height="32" src="/Upload/Portrait/1.jpg" data-src="<%#Eval("Portrait") %>" alt="<%#Eval("nickname") %>" class="avatar">
                                                <span class="tx"><%#Eval("nickname") %></span></a><time class="meta time" datetime="<%#Convert.ToDateTime(Eval("ReleaseTime")).ToString("yyyy-MM-dd HH:mm:ss") %>" title="<%#Convert.ToDateTime(Eval("ReleaseTime")).ToString("yyyy年MM月dd日") %>"><%#GetTime(Eval("ReleaseTime").ToString()) %></time>
                                        </div>
                                    </div>
                                </article>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <a href="/Pages/ShowManage/ShowList.aspx?type=activity&page=1" class="below-more btn btn-block btn-default" target="_blank">更多活动资讯 <i class="fa fa-caret-right"></i></a>
                </div>

                <%-- <div id="homebox-1447696723066" class="homebox panel mod">
                    <div class="heading">
                        <h2 class="title"><span class="bg"><a href="http://www.91moe.com/moe/acgmusic" title="更多ACG音乐"><i class="fa fa-music"></i>ACG音乐</a></span></h2>
                        <div class="extra">
                            <div class="keywords"><a href="http://www.91moe.com/moe/acgmusic/trmusic">同人音乐</a><a href="http://www.91moe.com/moe/acgmusic/music-xj">音乐选集</a></div>
                        </div>
                    </div>
                    <div class="row">
                        <article class="g-tablet-1-3 card sm post-11803 post type-post status-publish format-standard has-post-thumbnail hentry category-acgmusic category-music-xj tag-515 tag-56">
                            <div class="card-bg">
                                <a href="http://www.91moe.com/moe11803.html" title="平行四界" class="thumbnail-container" target="_blank">
                                    <img class="thumbnail" src="http://img.91moe.com/46201453_10.gif" data-src="http://img.91moe.com/2016/05/e49683288f9610337c5057797f2e9a971-320x180.jpg" alt="平行四界" width="320" height="180"></a><a href="http://www.91moe.com/moe11803.html" title="平行四界" class="card-title" target="_blank"><h3>平行四界</h3>
                                    </a>
                                <div class="card-meta">
                                    <a href="http://www.91moe.com/moeauthor/101693" class="meta author" title="nqclymt" target="_blank">
                                        <img width="32" height="32" src="http://img.91moe.com/banben.jpg" data-src="http://www.91moe.com/wp-content/uploads/avatar/1693.jpg?v=1464086031" alt="nqclymt" class="avatar">
                                        <span class="tx">nqclymt</span></a><time class="meta time" datetime="2016-05-09 16:49:15" title="2016年05月09日">18天前</time>
                                </div>
                            </div>
                        </article>
                        <article class="g-tablet-1-3 card sm post-11807 post type-post status-publish format-standard has-post-thumbnail hentry category-acgmusic category-music-xj tag-34">
                            <div class="card-bg">
                                <a href="http://www.91moe.com/moe11807.html" title="东方Project音乐合集" class="thumbnail-container" target="_blank">
                                    <img class="thumbnail" src="http://img.91moe.com/46201453_10.gif" data-src="http://img.91moe.com/2016/05/7421fc5c04ecd2fd04d979d0afd87052-217x180.jpg" alt="东方Project音乐合集" width="320" height="180"></a><a href="http://www.91moe.com/moe11807.html" title="东方Project音乐合集" class="card-title" target="_blank"><h3>东方Project音乐合集</h3>
                                    </a>
                                <div class="card-meta">
                                    <a href="http://www.91moe.com/moeauthor/101693" class="meta author" title="nqclymt" target="_blank">
                                        <img width="32" height="32" src="http://img.91moe.com/banben.jpg" data-src="http://www.91moe.com/wp-content/uploads/avatar/1693.jpg?v=1464086031" alt="nqclymt" class="avatar">
                                        <span class="tx">nqclymt</span></a><time class="meta time" datetime="2016-05-09 16:39:32" title="2016年05月09日">18天前</time>
                                </div>
                            </div>
                        </article>
                        <article class="g-tablet-1-3 card sm post-11809 post type-post status-publish format-standard has-post-thumbnail hentry category-acgmusic category-music-xj tag-511 tag-606">
                            <div class="card-bg">
                                <a href="http://www.91moe.com/moe11809.html" title="玄觞《心弦》无损" class="thumbnail-container" target="_blank">
                                    <img class="thumbnail" src="http://img.91moe.com/46201453_10.gif" data-src="http://img.91moe.com/2016/05/b274725bb49614d8c57e2f3a20651a65-240x180.jpg" alt="玄觞《心弦》无损" width="320" height="180"></a><a href="http://www.91moe.com/moe11809.html" title="玄觞《心弦》无损" class="card-title" target="_blank"><h3>玄觞《心弦》无损</h3>
                                    </a>
                                <div class="card-meta">
                                    <a href="http://www.91moe.com/moeauthor/101693" class="meta author" title="nqclymt" target="_blank">
                                        <img width="32" height="32" src="http://img.91moe.com/banben.jpg" data-src="http://www.91moe.com/wp-content/uploads/avatar/1693.jpg?v=1464086031" alt="nqclymt" class="avatar">
                                        <span class="tx">nqclymt</span></a><time class="meta time" datetime="2016-05-09 16:34:38" title="2016年05月09日">18天前</time>
                                </div>
                            </div>
                        </article>
                        <article class="g-tablet-1-4 card sm post-11812 post type-post status-publish format-standard has-post-thumbnail hentry category-acgmusic category-music-xj tag-608 tag-607">
                            <div class="card-bg">
                                <a href="http://www.91moe.com/moe11812.html" title="河图《倾尽天下》无损(WAV)" class="thumbnail-container" target="_blank">
                                    <img class="thumbnail" src="http://img.91moe.com/46201453_10.gif" data-src="http://img.91moe.com/2016/05/eae624dcab7b5911f5c504e8d71bb80f-320x180.jpg" alt="河图《倾尽天下》无损(WAV)" width="320" height="180"></a><a href="http://www.91moe.com/moe11812.html" title="河图《倾尽天下》无损(WAV)" class="card-title" target="_blank"><h3>河图《倾尽天下》无损(WAV)</h3>
                                    </a>
                                <div class="card-meta">
                                    <a href="http://www.91moe.com/moeauthor/101693" class="meta author" title="nqclymt" target="_blank">
                                        <img width="32" height="32" src="http://img.91moe.com/banben.jpg" data-src="http://www.91moe.com/wp-content/uploads/avatar/1693.jpg?v=1464086031" alt="nqclymt" class="avatar">
                                        <span class="tx">nqclymt</span></a><time class="meta time" datetime="2016-05-09 16:29:53" title="2016年05月09日">18天前</time>
                                </div>
                            </div>
                        </article>
                        <article class="g-tablet-1-4 card sm post-10937 post type-post status-publish format-standard hentry category-acgmusic category-music-xj tag-21 tag-509">
                            <div class="card-bg">
                                <a href="http://www.91moe.com/moe10937.html" title="动漫音乐精选" class="thumbnail-container" target="_blank">
                                    <img class="thumbnail" src="http://img.91moe.com/46201453_10.gif" data-src="http://img.91moe.com/2016/04/43a602943835c7c4e7a41a0576d874a41.jpg" alt="动漫音乐精选" width="320" height="180"></a><a href="http://www.91moe.com/moe10937.html" title="动漫音乐精选" class="card-title" target="_blank"><h3>动漫音乐精选</h3>
                                    </a>
                                <div class="card-meta">
                                    <a href="http://www.91moe.com/moeauthor/100002" class="meta author" title="天才射鸡湿可乐" target="_blank">
                                        <img width="32" height="32" src="http://img.91moe.com/banben.jpg" data-src="http://www.91moe.com/wp-content/uploads/avatar/2.jpg?v=1447723839" alt="天才射鸡湿可乐" class="avatar">
                                        <span class="tx">天才射鸡湿可乐</span></a><time class="meta time" datetime="2016-04-23 11:32:05" title="2016年04月23日">1个月前</time>
                                </div>
                            </div>
                        </article>
                        <article class="g-tablet-1-4 card sm post-10895 post type-post status-publish format-standard has-post-thumbnail hentry category-acgmusic category-music-xj tag-511 tag-546">
                            <div class="card-bg">
                                <a href="http://www.91moe.com/moe10895.html" title="古风，墨明棋妙，" class="thumbnail-container" target="_blank">
                                    <img class="thumbnail" src="http://img.91moe.com/46201453_10.gif" data-src="http://img.91moe.com/2016/04/ad3d3c357eb259b0adde879c288b240b1-320x180.jpg" alt="古风，墨明棋妙，" width="320" height="180"></a><a href="http://www.91moe.com/moe10895.html" title="古风，墨明棋妙，" class="card-title" target="_blank"><h3>古风，墨明棋妙，</h3>
                                    </a>
                                <div class="card-meta">
                                    <a href="http://www.91moe.com/moeauthor/101693" class="meta author" title="nqclymt" target="_blank">
                                        <img width="32" height="32" src="http://img.91moe.com/banben.jpg" data-src="http://www.91moe.com/wp-content/uploads/avatar/1693.jpg?v=1464086031" alt="nqclymt" class="avatar">
                                        <span class="tx">nqclymt</span></a><time class="meta time" datetime="2016-04-23 00:00:11" title="2016年04月23日">1个月前</time>
                                </div>
                            </div>
                        </article>
                        <article class="g-tablet-1-4 card sm post-10554 post type-post status-publish format-standard has-post-thumbnail hentry category-acgmusic category-music-xj tag-517 tag-516 tag-515">
                            <div class="card-bg">
                                <a href="http://www.91moe.com/moe10554.html" title="天依老婆的歌" class="thumbnail-container" target="_blank">
                                    <img class="thumbnail" src="http://img.91moe.com/46201453_10.gif" data-src="http://img.91moe.com/2016/04/d7bd78563815a97dabbe708cc2b852b8-320x180.jpg" alt="天依老婆的歌" width="320" height="180"></a><a href="http://www.91moe.com/moe10554.html" title="天依老婆的歌" class="card-title" target="_blank"><h3>天依老婆的歌</h3>
                                    </a>
                                <div class="card-meta">
                                    <a href="http://www.91moe.com/moeauthor/101693" class="meta author" title="nqclymt" target="_blank">
                                        <img width="32" height="32" src="http://img.91moe.com/banben.jpg" data-src="http://www.91moe.com/wp-content/uploads/avatar/1693.jpg?v=1464086031" alt="nqclymt" class="avatar">
                                        <span class="tx">nqclymt</span></a><time class="meta time" datetime="2016-04-15 02:34:24" title="2016年04月15日">1个月前</time>
                                </div>
                            </div>
                        </article>
                        <article class="g-tablet-1-4 card sm post-10462 post type-post status-publish format-standard has-post-thumbnail hentry category-acgmusic tag-513 tag-511 tag-512 tag-79">
                            <div class="card-bg">
                                <a href="http://www.91moe.com/moe10462.html" title="剑三背景音乐【需要自取】" class="thumbnail-container" target="_blank">
                                    <img class="thumbnail" src="http://img.91moe.com/46201453_10.gif" data-src="http://img.91moe.com/2016/04/5814e30934a06147d0276c919e8aa9e4-320x180.jpg" alt="剑三背景音乐【需要自取】" width="320" height="180"></a><a href="http://www.91moe.com/moe10462.html" title="剑三背景音乐【需要自取】" class="card-title" target="_blank"><h3>剑三背景音乐【需要自取】</h3>
                                    </a>
                                <div class="card-meta">
                                    <a href="http://www.91moe.com/moeauthor/101693" class="meta author" title="nqclymt" target="_blank">
                                        <img width="32" height="32" src="http://img.91moe.com/banben.jpg" data-src="http://www.91moe.com/wp-content/uploads/avatar/1693.jpg?v=1464086031" alt="nqclymt" class="avatar">
                                        <span class="tx">nqclymt</span></a><time class="meta time" datetime="2016-04-12 11:46:04" title="2016年04月12日">1个月前</time>
                                </div>
                            </div>
                        </article>
                        <article class="g-tablet-1-4 card sm post-10271 post type-post status-publish format-standard has-post-thumbnail hentry category-acgmusic category-trmusic">
                            <div class="card-bg">
                                <a href="http://www.91moe.com/moe10271.html" title="[日系.治愈]最是你迷人的笑颜，萦绕我心间" class="thumbnail-container" target="_blank">
                                    <img class="thumbnail" src="http://img.91moe.com/46201453_10.gif" data-src="http://img.91moe.com/2016/04/868aad33eb12022370887c7ea5f6c1a7-320x180.jpg" alt="[日系.治愈]最是你迷人的笑颜，萦绕我心间" width="320" height="180"></a><a href="http://www.91moe.com/moe10271.html" title="[日系.治愈]最是你迷人的笑颜，萦绕我心间" class="card-title" target="_blank"><h3>[日系.治愈]最是你迷人的笑颜，萦绕我心间</h3>
                                    </a>
                                <div class="card-meta">
                                    <a href="http://www.91moe.com/moeauthor/102380" class="meta author" title="优雅不要污" target="_blank">
                                        <img width="32" height="32" src="http://img.91moe.com/banben.jpg" data-src="http://www.91moe.com/wp-content/uploads/avatar/2380.jpg?v=1456756560" alt="优雅不要污" class="avatar">
                                        <span class="tx">优雅不要污</span></a><time class="meta time" datetime="2016-04-03 11:01:57" title="2016年04月03日">1个月前</time>
                                </div>
                            </div>
                        </article>
                        <article class="g-tablet-1-4 card sm post-9859 post type-post status-publish format-standard has-post-thumbnail hentry category-acgmusic category-music-xj">
                            <div class="card-bg">
                                <a href="http://www.91moe.com/moe9859.html" title="情不知所起，一往情深。" class="thumbnail-container" target="_blank">
                                    <img class="thumbnail" src="http://img.91moe.com/46201453_10.gif" data-src="http://img.91moe.com/2016/03/d9bdbc07942147191b407869c193908f-320x180.jpg" alt="情不知所起，一往情深。" width="320" height="180"></a><a href="http://www.91moe.com/moe9859.html" title="情不知所起，一往情深。" class="card-title" target="_blank"><h3>情不知所起，一往情深。</h3>
                                    </a>
                                <div class="card-meta">
                                    <a href="http://www.91moe.com/moeauthor/100117" class="meta author" title="苍穹" target="_blank">
                                        <img width="32" height="32" src="http://img.91moe.com/banben.jpg" data-src="http://cn.gravatar.com/avatar/a49e8398bef86a158559287fac43452a?s=96&d=monsterid&r=g" alt="苍穹" class="avatar">
                                        <span class="tx">苍穹</span></a><time class="meta time" datetime="2016-03-25 18:28:56" title="2016年03月25日">2个月前</time>
                                </div>
                            </div>
                        </article>
                        <article class="g-tablet-1-4 card sm post-9764 post type-post status-publish format-standard hentry category-acgmusic category-music-xj">
                            <div class="card-bg">
                                <a href="http://www.91moe.com/moe9764.html" title="【日系】高燃抖腿必备神曲 ｜ 精选②" class="thumbnail-container" target="_blank">
                                    <img class="thumbnail" src="http://img.91moe.com/46201453_10.gif" data-src="http://p3.music.126.net/XND-nbE2kjnCx6fD-VXN4g==/3297435382656348.jpg" alt="【日系】高燃抖腿必备神曲 ｜ 精选②" width="320" height="180"></a><a href="http://www.91moe.com/moe9764.html" title="【日系】高燃抖腿必备神曲 ｜ 精选②" class="card-title" target="_blank"><h3>【日系】高燃抖腿必备神曲 ｜ 精选②</h3>
                                    </a>
                                <div class="card-meta">
                                    <a href="http://www.91moe.com/moeauthor/100001" class="meta author" title="Freddy@Moe" target="_blank">
                                        <img width="32" height="32" src="http://img.91moe.com/banben.jpg" data-src="http://www.91moe.com/wp-content/uploads/avatar/1.jpg?v=1457783121" alt="Freddy@Moe" class="avatar">
                                        <span class="tx">Freddy@Moe</span></a><time class="meta time" datetime="2016-03-23 00:00:18" title="2016年03月23日">2个月前</time>
                                </div>
                            </div>
                        </article>
                    </div>
                    <a href="http://www.91moe.com/moe/acgmusic" class="below-more btn btn-block btn-default" target="_blank">更多ACG音乐 <i class="fa fa-caret-right"></i></a>
                </div>--%>
            </div>
            <!---->

            <div id="sidebar-container" class="g-desktop-1-4">
                <div id="sidebar" class="widget-area" role="complementary">
                    <%--<aside id="widget_adbox-5">
                        <div class="widget widget_adbox">
                            <div class="adbox">
                                91萌直播<div id="player" style="width: 100%; height: 200px;">
                                    <script type="text/javascript" charset="utf-8" src="http://yuntv.letv.com/player/live/blive.js"></script>
                                    <script>var player = new CloudLivePlayer(); player.init({ activityId: "A2016032900001tc" });</script>
                                </div>
                            </div>
                        </div>
                    </aside>--%>

                    <!--今日热门-->
                    <aside id="widget_rank-4">
                        <div class="widget widget_rank">
                            <div class="heading ">
                                <h2 class="widget-title"><i class="fa fa-bar-chart"></i>今日热门</h2>
                            </div>
                            <ul class="list-group list-group-img widget-orderby-views">
                                <asp:Repeater runat="server" ID="repHot">
                                    <ItemTemplate>
                                        <li class="list-group-item "><a class="list-group-item-bg media" href="/Pages/ShowManage/view.aspx?nid=<%#Eval("WorksId") %>&type=works" title="<%#Eval("WorksTitle") %>" target="_blank">
                                            <div class="media-left">
                                                <div class="thumbnail-container">
                                                    <img class="thumbnail" src="/Style/img/46201453_10.gif" data-src="<%#GetCover(Eval("cover").ToString()) %>" alt="<%#Eval("WorksTitle") %>" width="320" height="180">
                                                </div>
                                            </div>
                                            <div class="media-body">
                                                <h3 class="media-heading"><%#Eval("WorksTitle") %></h3>
                                                <div class="metas row">
                                                    <div class="view meta g-phone-1-2"><i class="fa fa-play-circle"></i><%#Eval("GoodNo") %></div>
                                                    <div class="comments meta g-phone-1-2"><i class="fa fa-comment"></i><%#GetCommentNumber(Eval("Worksid").ToString()) %></div>
                                                </div>
                                            </div>
                                        </a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </aside>
                    <!---->
                    <!--随机推荐-->
                    <aside id="widget_rank-5">
                        <div class="widget widget_rank">
                            <div class="heading ">
                                <h2 class="widget-title"><i class="fa fa-random"></i>随机推荐</h2>
                            </div>
                            <ul class="list-group list-group-img widget-orderby-random">
                                <asp:Repeater runat="server" ID="repRand">
                                    <ItemTemplate>
                                        <li class="list-group-item "><a class="list-group-item-bg media" href="/Pages/ShowManage/view.aspx?nid=<%#Eval("WorksId") %>&type=works" title="<%#Eval("WorksTitle") %>" target="_blank">
                                            <div class="media-left">
                                                <div class="thumbnail-container">
                                                    <img class="thumbnail" src="/Style/img/46201453_10.gif" data-src="<%#GetCover(Eval("cover").ToString()) %>" alt="<%#Eval("WorksTitle") %>" width="320" height="180">
                                                </div>
                                            </div>
                                            <div class="media-body">
                                                <h3 class="media-heading"><%#Eval("WorksTitle") %></h3>
                                                <div class="metas row">
                                                    <div class="view meta g-phone-1-2"><i class="fa fa-play-circle"></i><%#Eval("GoodNo") %></div>
                                                    <div class="comments meta g-phone-1-2"><i class="fa fa-comment"></i><%#GetCommentNumber(Eval("Worksid").ToString()) %></div>
                                                </div>
                                            </div>
                                        </a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </aside>
                    <!---->
                    <!--排行榜-->
                    <asp:Repeater runat="server" ID="repRankList" OnItemDataBound="repRankList_ItemDataBound">
                        <ItemTemplate>
                            <aside id="widget_rank-6-<%#Eval("id") %>">
                                <div class="widget widget_rank">
                                    <div class="heading ">
                                        <h2 class="widget-title"><i class="fa fa-bar-chart"></i>第<%#Eval("order") %><%#Eval("typeText") %>排行榜</h2>
                                    </div>
                                    <ul class="list-group list-group-img widget-orderby-views">
                                        <asp:Repeater runat="server" ID="repRank">
                                            <ItemTemplate>
                                                <li class="list-group-item "><a class="list-group-item-bg media" href="/Pages/ShowManage/view.aspx?nid=<%#Eval("WorksId") %>&type=works" title="<%#Eval("WorksTitle") %>" target="_blank">
                                                    <div class="media-left">
                                                        <div class="thumbnail-container">
                                                            <img class="thumbnail" src="/Style/img/46201453_10.gif" data-src="<%#GetCover(Eval("cover").ToString()) %>" alt="<%#Eval("WorksTitle") %>" width="320" height="180">
                                                        </div>
                                                    </div>
                                                    <div class="media-body">
                                                        <h3 class="media-heading"><%#Eval("WorksTitle") %></h3>
                                                        <div class="metas row">
                                                            <div class="view meta g-phone-1-2"><i class="fa fa-play-circle"></i><%#Eval("GoodNo") %></div>
                                                            <%--点赞数--%>
                                                            <div class="comments meta g-phone-1-2"><i class="fa fa-comment"></i><%#GetCommentNumber(Eval("Worksid").ToString()) %></div>
                                                            <%--评论数--%>
                                                        </div>
                                                    </div>
                                                </a></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </aside>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <aside id="widget_rank-6-<%#Eval("id") %>">
                                <div class="widget widget_rank">
                                    <div class="heading ">
                                        <h2 class="widget-title"><i class="fa fa-bar-chart"></i><%#Eval("order") %><%#Eval("typeText") %>排行榜</h2>
                                    </div>
                                    <ul class="list-group list-group-img widget-orderby-views">
                                        <asp:Repeater runat="server" ID="repRank">
                                            <ItemTemplate>
                                                <li class="list-group-item "><a class="list-group-item-bg media" href="/Pages/NoteManage/view.aspx?noteId=<%#Eval("Worksid") %>&uid=<%#Eval("User_id") %>" title="<%#Eval("WorksTitle") %>" target="_blank">
                                                    <div class="media-left">
                                                        <div class="thumbnail-container">
                                                            <img class="thumbnail" src="/Style/img/46201453_10.gif" data-src="<%#GetCover(Eval("cover").ToString()) %>" alt="<%#Eval("WorksTitle") %>" width="320" height="180">
                                                        </div>
                                                    </div>
                                                    <div class="media-body">
                                                        <h3 class="media-heading"><%#Eval("WorksTitle") %></h3>
                                                        <div class="metas row">
                                                            <div class="view meta g-phone-1-2"><i class="fa fa-play-circle"></i><%#Eval("GoodNo") %></div>
                                                            <%--点赞数--%>
                                                            <div class="comments meta g-phone-1-2"><i class="fa fa-comment"></i><%#GetCommentNumber(Eval("Worksid").ToString()) %></div>
                                                            <%--评论数--%>
                                                        </div>
                                                    </div>
                                                </a></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </aside>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                    <!---->

                    <%--<aside id="widget_hot_tags-6">
                        <div class="widget widget_hot_tags">
                            <div class="heading ">
                                <h2 class="widget-title"><a title="查看标签索引" href="http://www.91moe.com/tags-index"><i class="fa fa-tags"></i>热门标签 &raquo;</a></h2>
                            </div>
                            <div class="widget-content"><a class="hot-tag" href="http://www.91moe.com/moetag/%e7%b2%be%e9%80%89" style="font-size: 20pt; color: rgb(75,90,180);">精选</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e7%bb%98%e7%94%bb" style="font-size: 16.975pt; color: rgb(116,78,156);">绘画</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e6%8f%92%e7%94%bb" style="font-size: 16.4pt; color: rgb(109,95,171);">插画</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e8%90%9d%e8%8e%89" style="font-size: 13.175pt; color: rgb(176,117,61);">萝莉</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e6%95%99%e7%a8%8b" style="font-size: 12.6pt; color: rgb(90,117,101);">教程</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e7%a6%8f%e5%88%a9" style="font-size: 12.575pt; color: rgb(133,149,166);">福利</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e6%95%99%e5%ad%a6" style="font-size: 12.5pt; color: rgb(57,52,54);">教学</a><a class="hot-tag" href="http://www.91moe.com/moetag/cosplay" style="font-size: 12.425pt; color: rgb(70,135,197);">cosplay</a><a class="hot-tag" href="http://www.91moe.com/moetag/gif" style="font-size: 11.9pt; color: rgb(126,55,123);">gif</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e7%be%8e%e5%9b%be" style="font-size: 11.7pt; color: rgb(79,87,174);">美图</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e7%bb%85%e5%a3%ab" style="font-size: 11.6pt; color: rgb(174,101,122);">绅士</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e6%81%8b%e7%88%b1" style="font-size: 11.5pt; color: rgb(102,81,97);">恋爱</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e8%88%b0%e9%98%9fcollection" style="font-size: 11.35pt; color: rgb(155,196,194);">舰队Collection</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e6%b8%b8%e6%88%8f" style="font-size: 11.35pt; color: rgb(149,120,118);">游戏</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e6%a0%a1%e5%9b%ad" style="font-size: 11.325pt; color: rgb(140,64,57);">校园</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e6%88%98%e6%96%97" style="font-size: 11.3pt; color: rgb(90,61,98);">战斗</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e5%86%92%e9%99%a9" style="font-size: 11.25pt; color: rgb(154,141,107);">冒险</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e5%90%8e%e5%ae%ab" style="font-size: 11.25pt; color: rgb(184,188,60);">后宫</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e6%88%91%e7%9a%84%e5%a6%b9%e5%a6%b9%e5%93%aa%e6%9c%89%e8%bf%99%e4%b9%88%e5%8f%af%e7%88%b1" style="font-size: 11.175pt; color: rgb(84,128,79);">我的妹妹哪有这么可爱</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e7%94%bb%e5%b8%88" style="font-size: 11.15pt; color: rgb(195,66,133);">画师</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e7%a7%91%e5%b9%bb" style="font-size: 11.15pt; color: rgb(178,145,109);">科幻</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e6%90%9e%e7%ac%91" style="font-size: 11.15pt; color: rgb(85,51,111);">搞笑</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e5%a5%87%e5%b9%bb" style="font-size: 11.125pt; color: rgb(58,142,73);">奇幻</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e4%b8%9c%e4%ba%ac%e5%96%b0%e7%a7%8d" style="font-size: 11.125pt; color: rgb(72,54,124);">东京喰种</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e9%83%bd%e5%b8%82" style="font-size: 11.125pt; color: rgb(110,139,164);">都市</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e5%8d%96%e8%82%89" style="font-size: 11.125pt; color: rgb(87,134,91);">卖肉</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e6%9c%ac%e5%ad%90" style="font-size: 11.075pt; color: rgb(86,57,83);">本子</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e8%90%8c%e5%a6%b9%e5%ad%90" style="font-size: 11.05pt; color: rgb(89,163,187);">萌妹子</a><a class="hot-tag" href="http://www.91moe.com/moetag/%e8%85%bf%e6%8e%a7" style="font-size: 11.025pt; color: rgb(199,167,64);">腿控</a><a class="hot-tag" href="http://www.91moe.com/moetag/lovelive" style="font-size: 11pt; color: rgb(51,151,116);">LoveLive</a></div>
                        </div>
                    </aside>--%>
                    <%--<aside id="widget_comments-2">
                        <div class="widget widget_comments">
                            <div class="heading ">
                                <h2 class="widget-title"><i class="fa fa-comments-o"></i>近期吐槽</h2>
                            </div>
                            <ul class="list-group">
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe12373.html#comment-865" title="【pixiv】绅士周榜2016522">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://www.91moe.com/wp-content/uploads/avatar/3861.jpg?v=1462076795" src="http://img.91moe.com/banben.jpg" alt="彼岸千桜" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">彼岸千桜</span><time datetime="2016-05-28T09:44:52+00:00"><small>7小时前</small></time></h3>
                                        <div class="text">我感到恐惧 [图片]</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe11721.html#comment-864" title="Afterschool of the 5th year (Kantoku) - PANTY&times;PANTY">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://www.91moe.com/wp-content/uploads/avatar/3861.jpg?v=1462076795" src="http://img.91moe.com/banben.jpg" alt="彼岸千桜" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">彼岸千桜</span><time datetime="2016-05-28T09:43:58+00:00"><small>7小时前</small></time></h3>
                                        <div class="text">DuangDuangDuang [图片]</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe5623.html#comment-863" title="冬天到了萌妹纸都萌萌哒">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://q.qlogo.cn/qqapp/101270795/224BD410B535C76710450F9487E3AD5A/100" src="http://img.91moe.com/banben.jpg" alt="茧墨阿座化" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">茧墨阿座化</span><time datetime="2016-05-27T21:04:03+00:00"><small>19小时前</small></time></h3>
                                        <div class="text">结果不能下载么(*´艸`*)我的天呐</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe11925.html#comment-862" title="【RPG】猪头人的复仇">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://www.91moe.com/wp-content/uploads/avatar/3986.jpg?v=1462447174" src="http://img.91moe.com/banben.jpg" alt="九妖白月光" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">九妖白月光</span><time datetime="2016-05-27T19:17:23+00:00"><small>21小时前</small></time></h3>
                                        <div class="text">@樱之恋 好的，链接：http://pan.baidu.com/s/1&hellip;</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe7153.html#comment-861" title="OWAKADO系列 数学作业">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://www.91moe.com/wp-content/uploads/avatar/3861.jpg?v=1462076795" src="http://img.91moe.com/banben.jpg" alt="彼岸千桜" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">彼岸千桜</span><time datetime="2016-05-27T16:54:10+00:00"><small>1天前</small></time></h3>
                                        <div class="text">赞赞赞 [图片]</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe11925.html#comment-860" title="【RPG】猪头人的复仇">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://q.qlogo.cn/qqapp/101270795/486C752A504BF49487A6CB8A9EC096F7/100" src="http://img.91moe.com/banben.jpg" alt="樱之恋" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">樱之恋</span><time datetime="2016-05-27T13:55:36+00:00"><small>1天前</small></time></h3>
                                        <div class="text">求补档</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe11788.html#comment-859" title="【合集】雯雅婷">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://www.91moe.com/wp-content/uploads/avatar/3986.jpg?v=1462447174" src="http://img.91moe.com/banben.jpg" alt="九妖白月光" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">九妖白月光</span><time datetime="2016-05-26T13:09:30+00:00"><small>2天前</small></time></h3>
                                        <div class="text">@匿名 链接：http://pan.baidu.com/s/1eRF3&hellip;</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe11925.html#comment-858" title="【RPG】猪头人的复仇">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://www.91moe.com/wp-content/uploads/avatar/3986.jpg?v=1462447174" src="http://img.91moe.com/banben.jpg" alt="九妖白月光" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">九妖白月光</span><time datetime="2016-05-26T13:06:54+00:00"><small>2天前</small></time></h3>
                                        <div class="text">@匿名 提取密码就是</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe11925.html#comment-857" title="【RPG】猪头人的复仇">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://www.91moe.com/wp-content/uploads/avatar/3986.jpg?v=1462447174" src="http://img.91moe.com/banben.jpg" alt="九妖白月光" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">九妖白月光</span><time datetime="2016-05-26T13:06:33+00:00"><small>2天前</small></time></h3>
                                        <div class="text">@半夜挊管 能玩啊</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe11788.html#comment-856" title="【合集】雯雅婷">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://cn.gravatar.com/avatar/?s=96&amp;d=monsterid&amp;r=g" src="http://img.91moe.com/banben.jpg" alt="匿名" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">匿名</span><time datetime="2016-05-26T12:56:46+00:00"><small>2天前</small></time></h3>
                                        <div class="text">炸了求补档</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe12244.html#comment-855" title="《天夜特辑》">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://www.91moe.com/wp-content/uploads/avatar/305.jpg?v=1456633537" src="http://img.91moe.com/banben.jpg" alt="希Oitapika&deg;" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">希Oitapika&deg;</span><time datetime="2016-05-23T12:15:51+00:00"><small>5天前</small></time></h3>
                                        <div class="text">@分裂 是的</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe12244.html#comment-854" title="《天夜特辑》">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://q.qlogo.cn/qqapp/101270795/204E67C79A2019A458B7F482C68EDC2F/100" src="http://img.91moe.com/banben.jpg" alt="分裂" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">分裂</span><time datetime="2016-05-23T09:43:45+00:00"><small>5天前</small></time></h3>
                                        <div class="text">这是千夜的女儿啊～</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/91mb-get#comment-851" title="91萌---萌币--使用说明">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://cn.gravatar.com/avatar/a10d0ab8a5964e303f1414fe6dd726fc?s=96&amp;d=monsterid&amp;r=g" src="http://img.91moe.com/banben.jpg" alt="版本" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">版本</span><time datetime="2016-05-22T17:21:34+00:00"><small>5天前</small></time></h3>
                                        <div class="text">00</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe11671.html#comment-850" title="【RPG】娼妇一行（无汉化）">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://cn.gravatar.com/avatar/?s=96&amp;d=monsterid&amp;r=g" src="http://img.91moe.com/banben.jpg" alt="匿名" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">匿名</span><time datetime="2016-05-22T14:03:15+00:00"><small>6天前</small></time></h3>
                                        <div class="text">下载这么多 然后评论0 啧啧啧</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe11788.html#comment-849" title="【合集】雯雅婷">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://www.91moe.com/wp-content/uploads/avatar/3986.jpg?v=1462447174" src="http://img.91moe.com/banben.jpg" alt="九妖白月光" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">九妖白月光</span><time datetime="2016-05-22T11:28:03+00:00"><small>6天前</small></time></h3>
                                        <div class="text">@匿名 好像没有解压密码吧</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe11788.html#comment-848" title="【合集】雯雅婷">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://cn.gravatar.com/avatar/?s=96&amp;d=monsterid&amp;r=g" src="http://img.91moe.com/banben.jpg" alt="匿名" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">匿名</span><time datetime="2016-05-22T10:52:24+00:00"><small>6天前</small></time></h3>
                                        <div class="text">解压码是什么？没有解压码下了也木有用啊</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe10589.html#comment-847" title="甲铁城的卡巴内瑞【无删减版】【更新至07集(熟肉)】【在线】">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://www.91moe.com/wp-content/uploads/avatar/1.jpg?v=1457783121" src="http://img.91moe.com/banben.jpg" alt="Freddy@Moe" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">Freddy@Moe</span><time datetime="2016-05-21T13:04:25+00:00"><small>7天前</small></time></h3>
                                        <div class="text">@姚 已经修复谢谢支持</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe10589.html#comment-846" title="甲铁城的卡巴内瑞【无删减版】【更新至07集(熟肉)】【在线】">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://cn.gravatar.com/avatar/?s=96&amp;d=monsterid&amp;r=g" src="http://img.91moe.com/banben.jpg" alt="姚" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">姚</span><time datetime="2016-05-21T00:14:38+00:00"><small>7天前</small></time></h3>
                                        <div class="text">缓存的话 第五集不好下 第六集望快一点上传</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe8963.html#comment-845" title="cos腿控绅士福利真视频【正片】&middot;&middot;&middot;">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://www.91moe.com/wp-content/uploads/avatar/4821.jpg?v=1463760072" src="http://img.91moe.com/banben.jpg" alt="蛋蛋" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">蛋蛋</span><time datetime="2016-05-21T00:07:41+00:00"><small>7天前</small></time></h3>
                                        <div class="text">视频挂掉了</div>
                                    </div>
                                </a></li>
                                <li class="list-group-item"><a class="media tooltip top" href="http://www.91moe.com/moe11797.html#comment-844" title="【pixiv】绅士周榜201657">
                                    <div class="media-left">
                                        <img class="avatar media-object" data-src="http://www.91moe.com/wp-content/uploads/avatar/4821.jpg?v=1463760072" src="http://img.91moe.com/banben.jpg" alt="蛋蛋" width="50" height="50" />
                                    </div>
                                    <div class="media-body">
                                        <h3 class="media-heading"><span class="author">蛋蛋</span><time datetime="2016-05-21T00:03:34+00:00"><small>7天前</small></time></h3>
                                        <div class="text">万恶的马赛克 [图片]</div>
                                    </div>
                                </a></li>
                            </ul>
                        </div>
                    </aside>--%>
                </div>
            </div>
        </div>
    </div>
    <!---->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>window.THEME_CONFIG = { "vars": { "locale": "zh_CN", "iden": "mx", "process_url": "http:\/\/www.91moe.com\/wp-admin\/admin-ajax.php" }, "lang": { "M01": "\u52a0\u8f7d\u4e2d\uff0c\u8bf7\u7a0d\u5019\u2026", "E01": "\u62b1\u6b49\uff0c\u670d\u52a1\u5668\u6b63\u5fd9\uff0c\u65e0\u6cd5\u54cd\u5e94\u4f60\u7684\u8bf7\u6c42\uff0c\u8bf7\u7a0d\u5019\u91cd\u8bd5\u3002" }, "theme_custom_slidebox": { "type": "scroller" } };</script>
    <script>
        $(window).load(function () {
            $('#sample_slider').swipeslider();
        });
    </script>
</asp:Content>
