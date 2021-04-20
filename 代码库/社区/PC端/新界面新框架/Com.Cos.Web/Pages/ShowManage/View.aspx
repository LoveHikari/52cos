<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Com.Cos.Web.Pages.ShowManage.View" %>
<%@ Import Namespace="Com.Cos.Utility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/plugins/sweetalert/sweetalert.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="/plugins/mo/fonts/font-awesome-4.5.0/css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="/plugins/mo/css/icons.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="g">
        <div class="row">
            <div id="main" class="main g-desktop-3-4">
                <!--左边正文部分-->
                <asp:Literal runat="server" ID="litWork"></asp:Literal>
                
                <!---->
                <!--发表评论-->
                <div id="respond" class="panel">
                    <div class="content">

                        <div id="respond-must-login" class="hide-on-logged <%=User_id!=null?"none":"" %>">
                            <div class="tip-status tip-status-small tip-status-info">
                                <i class="fa fa-exclamation-circle fa-fw"></i>
                                <a href="/Pages/App_Public/Login.aspx">登录后才能评论哦！
                                </a>
                            </div>
                        </div>

                        <form id="commentform" action="/Service/ShowManage/Reply.ashx" method="post" class="comment-form media ">
                            <div class="media">
                                <input type="hidden" name="comment_post_ID" id="comment_post_ID" value="<%=worksId %>">
                                <input type="hidden" name="comment_parent" id="comment_parent" value="<%=type %>">
                                <div class="media-left hidden-phone">
                                    <img id="respond-avatar" src="<%=UMemberEntity?.Portrait %>" tppabs="/Upload/Portrait/1.jpg" alt="<%=UMemberEntity?.nickname %>" class="media-object avatar" width="100" height="100">
                                </div>
                                <div class="media-body">
                                    <div class="form-group form-group-textarea">
                                        <textarea name="comment" id="comment-form-comment" class="form-control" rows="3" placeholder="Hi, 有什么要说的吗？" title="没什么好说的吗？" required></textarea>
                                    </div>
                                    <div class="form-group btn-group-submit">
                                        <div class="comment-emotion-area-pop">
                                            <div id="theme_comment_emotion-kaomoji" class="pop">
                                                <a href="javascript:;" data-content="(⊙⊙！)">(⊙⊙！)</a>
                                                <a href="javascript:;" data-content="ƪ(&oline;&epsilon;&oline;&ldquo;)ʃƪ(">ƪ(&oline;&epsilon;&oline;&ldquo;)ʃƪ(</a>
                                                <a href="javascript:;" data-content="&Sigma;(&deg;Д&deg;;">&Sigma;(&deg;Д&deg;;</a>
                                                <a href="javascript:;" data-content="눈_눈">눈_눈</a>
                                                <a href="javascript:;" data-content="(๑&gt;◡&lt;๑)">(๑&gt;◡&lt;๑)</a>
                                                <a href="javascript:;" data-content="(❁&acute;▽`❁)">(❁&acute;▽`❁)</a>
                                                <a href="javascript:;" data-content="(,,Ծ▽Ծ,,)">(,,Ծ▽Ծ,,)</a>
                                                <a href="javascript:;" data-content="（⺻▽⺻ ）">（⺻▽⺻ ）</a>
                                                <a href="javascript:;" data-content="乁( ◔ ౪◔)「">乁( ◔ ౪◔)「</a>
                                                <a href="javascript:;" data-content="ლ(^o^ლ)">ლ(^o^ლ)</a>
                                                <a href="javascript:;" data-content="(◕ܫ◕)">(◕ܫ◕)</a>
                                                <a href="javascript:;" data-content="凸(= _=)凸">凸(= _=)凸</a>
                                            </div>
                                            <div id="theme_comment_emotion-img" class="pop">
                                                <a href="javascript:;" data-content="[脸红]">
                                                    <img data-url="http://ww2.sinaimg.cn/large/686ee05djw1eu8ijxc3p7g201c01c3yd.gif" alt="脸红" width="50" height="50" src="data:image/gif;base64,R0lGODlhAQABAPAAAO7u7v///yH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" title="脸红"></a>
                                                <a href="javascript:;" data-content="[杯具]">
                                                    <img data-url="http://ww1.sinaimg.cn/large/686ee05djw1eu8ikpw34jg201e01emx1.gif" alt="杯具" width="50" height="50" src="data:image/gif;base64,R0lGODlhAQABAPAAAO7u7v///yH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" title="杯具"></a>
                                                <a href="javascript:;" data-content="[亚历山大]">
                                                    <img data-url="http://ww1.sinaimg.cn/large/686ee05djw1eu8iliwosmg201e01e74h.gif" alt="亚历山大" width="50" height="50" src="data:image/gif;base64,R0lGODlhAQABAPAAAO7u7v///yH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" title="亚历山大"></a>
                                                <a href="javascript:;" data-content="[想要]">
                                                    <img data-url="http://ww1.sinaimg.cn/large/686ee05djw1eu8ilzci2jg202s02sglo.gif" alt="想要" width="50" height="50" src="data:image/gif;base64,R0lGODlhAQABAPAAAO7u7v///yH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" title="想要"></a>
                                                <a href="javascript:;" data-content="[吃惊]">
                                                    <img data-url="http://ww1.sinaimg.cn/large/686ee05djw1eu8j1vay4ej204h049jrb.jpg" alt="吃惊" width="50" height="50" src="data:image/gif;base64,R0lGODlhAQABAPAAAO7u7v///yH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" title="吃惊"></a>
                                                <a href="javascript:;" data-content="[好样的]">
                                                    <img data-url="http://ww3.sinaimg.cn/large/686ee05djw1eu8iomh5cbg203g03cdgx.gif" alt="好样的" width="50" height="50" src="data:image/gif;base64,R0lGODlhAQABAPAAAO7u7v///yH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" title="好样的"></a>
                                            </div>
                                        </div>
                                        <a href="javascript:;" class="comment-emotion-pop-btn" data-target="#theme_comment_emotion-kaomoji" title="颜文字"><i class="fa fa-font"></i></a>
                                        <a href="javascript:;" class="comment-emotion-pop-btn" data-target="#theme_comment_emotion-img" title="图片表情"><i class="fa fa-smile-o"></i></a>
                                        <button type="submit" class="submit btn btn-success" title="发表评论">
                                            <i class="fa fa-check"></i>
                                            发表评论
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <!---->
                <!--评论列表-->
                <div id="comments" class="panel comment-wrapper <%=commentNum<=0?"none":"" %>">
                    <div class='heading'>
                        <h2 class='have-comments-title title'>
                            <i class='fa fa-comments'></i>
                            <span id='comment-number-86'><%=commentNum %></span>
                            评论 </h2>
                    </div>

                    <ul id="comment-list-10589" class="comment-list">
                        <asp:Repeater runat="server" ID="repReply">
                            <ItemTemplate>
                                <li class="comment byuser comment-author-100001 bypostauthor even thread-even depth-1 media is-post-author" id="comment-712">
                                    <div id="comment-body-712" class="comment-body">
                                        <div class="media-left">
                                            <a href="/Pages/AuthorManage/Author.aspx?id=<%#Eval("User_id") %>" class="avatar-link" target="_blank">
                                                <img alt="" src="<%#Eval("Portrait") %>" srcset="<%#Eval("Portrait") %> 2x" class="avatar avatar-50 photo" height="50" width="50"></a>
                                        </div>
                                        <div class="media-body">
                                            <div class="comment-content">
                                                <%#Eval("ReplyContent") %>
                                            </div>
                                            <h4 class="media-heading"><span class="comment-meta-data author"><a href="/Pages/AuthorManage/Author.aspx?id=<%#Eval("User_id") %>" rel="external nofollow" class="url"><%#Eval("nickname") %></a></span><time class="comment-meta-data time" datetime="<%#Eval("ReleaseTime") %>"><%#UtilityHelper.GetTime(Eval("ReleaseTime").ToString()) %></time></h4>
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>

                    <a href="#respond" class="btn btn-success btn-lg btn-block"><i class="fa fa-edit"></i>我要吐槽</a>
                </div>
                <!---->
            </div>
            <!--右边-->
            <div id="sidebar-container" class="g-desktop-1-4">
                <div id="sidebar" class="widget-area" role="complementary">
                    <aside id="theme_widget_author-2">
                        <div class="widget theme_widget_author">
                            <div id="widget-author-card" class="widget-container content">
                                <a href="/Pages/AuthorManage/Author.aspx?id=<%=MemberEntity.User_id %>" class="author-link" title="查看作者资料">
                                    <img alt='' src="<%=MemberEntity.Portrait %>" srcset='<%=MemberEntity.Portrait %> 2x' class='avatar avatar-100 photo' height='100' width='100' /><h3 class="author-card-name"><%=MemberEntity.nickname %></h3>
                                    <small class="label label-primary">认证作者</small></a><p class="author-card-description" title="<%=MemberEntity.Describe %>"><%=MemberEntity.Describe %></p>
                                <div class="author-card-meta-links">
                                    <a class="tooltip" href="/Pages/AuthorManage/AuthorWorks.aspx?id=<%=MemberEntity.User_id %>" title="查看作者的文章" target="_blank"><span class="tx"><i class="fa fa-fw fa-file-text"></i></span><span class="count"><%=GetArticleNum() %></span></a>
                                    <a class="tooltip" href="/Pages/AuthorManage/AuthorComments.aspx?id=<%=MemberEntity.User_id %>" title="查看作者的评论" target="_blank"><span class="tx"><i class="fa fa-fw fa-comments"></i></span><span class="count"><%=GetReplyNum() %></span></a>
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

                    <aside id="widget_hot_tags-5">
                        <div class="widget widget_hot_tags">
                            <div class="heading ">
                                <h2 class="widget-title">
                                    <a title="查看标签索引" href="tags-index.htm" tppabs="http://www.91moe.com/tags-index">
                                        <i class="fa fa-tags"></i>热门标签 &raquo;
                                    </a>
                                </h2>
                            </div>
                            <div class="widget-content">
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 20pt; color: rgb(108,95,98);">精选</a>
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 16.966292134831pt; color: rgb(73,189,199);">绘画</a>
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 16.359550561798pt; color: rgb(176,155,113);">插画</a>
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 13.073033707865pt; color: rgb(151,63,163);">萝莉</a>
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 12.491573033708pt; color: rgb(71,54,181);">福利</a>
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 12.466292134831pt; color: rgb(180,151,65);">教程</a>
                                <a class="hot-tag" href="javascript:void(0);"  style="font-size: 12.365168539326pt; color: rgb(152,149,68);">教学</a>
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 12.289325842697pt; color: rgb(56,129,123);">cosplay</a>
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 11.758426966292pt; color: rgb(160,162,69);">gif</a>
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 11.556179775281pt; color: rgb(186,126,198);">美图</a>
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 11.455056179775pt; color: rgb(91,140,140);">绅士</a>
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 11.35393258427pt; color: rgb(91,180,114);">恋爱</a>
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 11.202247191011pt; color: rgb(152,187,187);">舰队Collection</a>
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 11.202247191011pt; color: rgb(148,78,186);">游戏</a>
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 11.176966292135pt; color: rgb(166,93,157);">校园</a>
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 11.151685393258pt; color: rgb(94,182,110);">战斗</a>
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 11.101123595506pt; color: rgb(56,94,99);">冒险</a>
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 11.101123595506pt; color: rgb(82,103,176);">后宫</a>
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 11.025280898876pt; color: rgb(173,183,192);">我的妹妹哪有这么可爱</a>
                                <a class="hot-tag" href="javascript:void(0);" style="font-size: 11pt; color: rgb(70,158,124);">画师</a>
                            </div>
                        </div>
                    </aside>
                    <aside id="nav_menu-7">
                        <div class="widget widget_nav_menu">
                            <div class="heading ">
                                <h2 class="widget-title">快捷导航</h2>
                            </div>
                            <div class="menu-container">
                                <ul id="menu" class="menu">
                                    <li id="menu-item-9166" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-9166"><a href="javascript:void(0);">投稿须知</a></li>
                                    <li id="menu-item-9167" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-9167"><a href="javascript:void(0);">萌币使用说明</a></li>
                                    <li id="menu-item-4990" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-4990"><a href="javascript:void(0);">加入我们</a></li>
                                    <li id="menu-item-4991" class="menu-item menu-item-type-post_type menu-item-object-page menu-item-4991"><a href="javascript:void(0);">赞助我们</a></li>
                                    <li id="menu-item-4992" class="menu-item menu-item-type-custom menu-item-object-custom menu-item-4992"><a href="javascript:void(0);">关于我们</a></li>
                                </ul>
                            </div>
                        </div>
                    </aside>
                </div>
            </div>
            <!---->
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script src="/plugins/sweetalert/sweetalert.min.js"></script>
    <script src="/plugins/mo/js/mo.min.js"></script>
    <script src="../../Style/js/view-like.js"></script>
    <script src="../../plugins/layer/layer.js?v=2.3"></script>
    <script>
        $(document).ready(function () {
            //发表评论
            $('#commentform').bind('submit', function () {
                var $logbut = $("button", this);
                $logbut.attr("disabled", !0);
                ajaxSubmit(this, function (res) {
                    var msg = eval("("+res+")");
                    if (msg.status == "success") {
                        swal({
                            title: "",
                            text: '回复成功',
                            timer: 3000,
                            showConfirmButton: false
                        });
                        location.reload();
                    } else {
                        swal("小2提醒您", "回复失败", "error");
                        $logbut.attr("disabled", !!0);
                    }
                }, function () {
                    swal("小2提醒您", "系统繁忙，请稍后再试", "error");
                    $logbut.attr("disabled", !!0);
                });
                return false;
            });

            //点赞
            $(document).on("click", "#post-good-btn", function () {
                var _userId = '<%=this.User_id%>';
                var _worksId = '<%=this.worksId%>';
                if (_userId == "") {
                    swal("小2提醒您", "请登录后点赞！", "error");
                    return false;
                }
                $.post("/Service/ShowManage/GoodClick.ashx", {UserId: _userId, WorksId: _worksId}, function (res) {
                    if (res > 0) {
                        layer.msg('节操+1，热心+1，成长值+1');
                    } else {
                        layer.msg('您已经赞过了呦！');
                    }
                }).error(function () { swal("小2提醒您", "系统繁忙，请稍后再试", "error"); });
            });

            //打赏
            $(document).on("click", ".post-point-btn", function () {
                var _userId = '<%=this.User_id%>';
                var _worksId = '<%=this.worksId%>';
                var _uid = '<%=_memberEntity.User_id%>';
                var _money = $(this).attr("data-points");
                console.info("_userId=" + _userId);
                if (_userId == "") {
                    swal("小2提醒您", "请登录后打赏！", "error");
                    return false;
                }
                if (_userId == _uid) {
                    swal("小2提醒您", "不能给自己打赏！", "error");
                    return false;
                }
                $.post("/Service/ShowManage/RewardClick.ashx", { UserId: _userId, WorksId: _worksId, Money: _money, Uid: _uid }, function (res) {
                    if (res > 0) {
                        layer.msg('节操+1，热心+1，成长值+'+_money*10+'，CN币-'+_money+'');
                    } else {
                        layer.msg('您的CN币不足，请充值后再打赏！');
                    }
                }).error(function () { swal("小2提醒您", "系统繁忙，请稍后再试", "error"); });
            });
        });
    </script>
</asp:Content>
