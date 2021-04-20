<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="RentView.aspx.cs" Inherits="Com.Cos.Web.Pages.ShowManage.RentView" %>
<%@OutputCache Duration="120" VaryByParam="nid" Location="Client" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="Com.Cos.Api" %>

<%@ Register Src="~/Controls/PublisherInfo.ascx" TagPrefix="uc1" TagName="PublisherInfo" %>
<%@ Register Src="~/Controls/QuickNavigation.ascx" TagPrefix="uc1" TagName="QuickNavigation" %>
<%@ Register Src="~/Controls/HotLabel.ascx" TagPrefix="uc1" TagName="HotLabel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="g">
        <div class="row">
            <div id="main" class="main g-desktop-3-4">
                <!--左边正文部分-->
                <article id="post-86" class=" singular-post panel post-86 post type-post status-publish format-standard has-post-thumbnail hentry category-acgtuji category-hjhc tag-18 tag-19 tag-21 tag-20">
                    <h2 class="entry-title"><%=rentEntity.Title %></h2>
                    <header class="entry-header">
                        <span class="entry-meta post-category" title="分类">
                            <i class="fa fa-folder-open"></i>
                            <a href="/czlist-1.html" rel="category tag">出租</a>
                        </span>
                        <time class="entry-meta post-time" datetime="<%=rentEntity.AddTime.ToString("yyyy-MM-dd HH:mm:ss") %>" title="<%=rentEntity.AddTime.ToString("yyyy年MM月dd日") %>">
                            <i class="fa fa-clock-o"></i><%=WorksApi.GetTime(rentEntity.AddTime.ToString(CultureInfo.InvariantCulture)) %>
                        </time>
                        <a class="entry-meta post-author" href="/zl/gj-<%=uid %>.html" title="查看<%=uMemberEntity.nickname %>目录下的所有文章">
                            <i class="fa fa-user"></i>
                        </a>
                    </header>
                    <div class="entry-body">
                        <div class="entry-content content-reset">
                            物品名称：<span><%=rentEntity.ItemName %></span><br />
                            物品包括：<span><%=rentEntity.Constitute %></span><br />
                            物品来自：<span><%=rentEntity.Source %></span><br />
                            其他描述：<span><%=rentEntity.Describe %></span><br />
                            原价：<span><%=rentEntity.Price %></span>
                        </div>
                        <div class="entry-content content-reset">
                            <asp:Literal runat="server" ID="litCertificate"></asp:Literal>
                        </div>
                        <div class="entry-content content-reset">
                            <asp:Literal runat="server" ID="litImgList"></asp:Literal>
                        </div>
                        <footer class="entry-footer">
                            <div class="entry-tags">
                                <a href="javascript:void(0);" rel="tag">进行中</a>
                                <div class="ystep1"></div>
                            </div>
                        </footer>
                        <footer class="entry-footer">
                            <div style="display: inline">租赁价：</div>
                            <div class="">
                                <div class="button">
                                    <a href="javascript:void(0);" name="official" data-val="1" rel="tag">￥<%=rentEntity.Official %></a>
                                </div>
                                <div>
                                    <a href="javascript:void(0);" onclick="SignUp('<%=this.uid %>', '<%=this.rentEntity.Id %>')" rel="tag">兑换</a>
                                </div>
                            </div>
                        </footer>
                    </div>
                </article>

            </div>
            <!--右边-->
            <div id="sidebar-container" class="g-desktop-1-4">
                <div id="sidebar" class="widget-area" role="complementary">
                    <uc1:PublisherInfo runat="server" ID="PublisherInfo" />
                    <uc1:HotLabel runat="server" ID="HotLabel" />
                    <uc1:QuickNavigation runat="server" ID="QuickNavigation" />
                </div>
            </div>
            <!---->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>var menu_header = '分享'</script>
    <script src="../../plugins/layer/layer.js"></script>
    <script>
        $(document).ready(function () {

        });
        //兑换
        function SignUp(_userId, _rxId) {
            window.layer.open({
                type: 2,
                title: false,
                shadeClose: true,
                shade: 0.8,
                area: ['380px', '90%'],
                content: '/Pages/ShowManage/SelectAddress.aspx?t=rent&uid=' + _userId + "&exId=" + _rxId //iframe的url
            });

        }
    </script>
</asp:Content>