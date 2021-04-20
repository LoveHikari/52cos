<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="Author.aspx.cs" Inherits="Com.Cos.Web.Pages.AuthorManage.Author" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="g">
        <h3 class="crumb-title">
            <img alt='' src='<%=MemberEntity.Portrait %>?v=<%=MemberEntity.User_id %>' srcset='<%=MemberEntity.Portrait %>?v=<%=MemberEntity.User_id %> 2x' class='avatar avatar-96 photo' height='96' width='96' />
            <%=MemberEntity.nickname %> - <small>资料</small>
        </h3>
        <nav class="nav">
            <a class=" active " href="/Pages/AuthorManage/Author.aspx?id=<%=MemberEntity.User_id %>">
                <i class="fa fa-newspaper-o fa-fw"></i>
                资料			</a>
            <a class="" href="/Pages/AuthorManage/AuthorWorks.aspx?id=<%=MemberEntity.User_id %>">
                <i class="fa fa-file-text fa-fw"></i>
                稿件			</a>
            <a class="" href="/Pages/AuthorManage/AuthorComments.aspx?id=<%=MemberEntity.User_id %>">
                <i class="fa fa-comments fa-fw"></i>
                评论			</a>
            <a class="" href="/Pages/AuthorManage/AuthorRates.aspx?id=<%=MemberEntity.User_id %>">
                <i class="fa fa-wpforms"></i>
                评分集			</a>
        </nav>
        <div class="panel">
            <div class="content">
                <fieldset class="author-profile">
                    <legend>
                        <i class="fa fa-newspaper-o"></i>
                        基本资料
                    </legend>
                    <table class="table">
                        <tbody>
                            <%--<tr>
                                <th>
                                    <abbr title="唯一的标识（不能被更改）">UID</abbr></th>
                                <td>
                                    <a href="/Pages/AuthorManage/Author.aspx?id=<%=MemberEntity.User_id %>" title="/Pages/AuthorManage/Author.aspx?id=<%=MemberEntity.User_id %>">100037
                                    </a>
                                </td>
                            </tr>--%>
                            <tr>
                                <th>昵称</th>
                                <td>
                                    <strong><%=MemberEntity.nickname %></strong>
                                </td>
                            </tr>
                            <tr>
                                <th>认证</th>
                                <td>
                                    <span class="label label-default">作者</span>
                                </td>
                            </tr>
                            <tr>
                                <th>等级</th>
                                <td>
                                    <span class="label label-default">Level <%=MemberEntity.Ugrade %></span>
                                </td>
                            </tr>
                            <tr>
                                <th>注册时间</th>
                                <td><%=MemberEntity.Reg_time?.ToString("yyyy-MM-dd HH:mm:ss") %></td>
                            </tr>
                            <tr>
                                <th>描述</th>
                                <td><%=MemberEntity.Describe %></td>
                            </tr>
                        </tbody>
                    </table>
                </fieldset>
                <!-- Statistics -->
                <fieldset class="author-profile">
                    <legend>
                        <i class="fa fa-pie-chart"></i>
                        统计</legend>
                    <table class="table">
                        <tbody>
                            <tr>
                                <th>稿件</th>
                                <td><a href="/Pages/AuthorManage/AuthorWorks.aspx?id=<%=MemberEntity.User_id %>"><%=GetArticleNum() %>
                                </a></td>
                            </tr>
                            <tr>
                                <th>评论</th>
                                <td>
                                    <a href="/Pages/AuthorManage/AuthorComments.aspx?id=<%=MemberEntity.User_id %>"><%=GetReplyNum() %>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <th>节操</th>
                                <td>
                                    <a href="/Pages/HomeManage/Bomb.aspx">
                                        <i class="fa fa-bomb"></i>
                                        <%=MemberEntity.integral %>						</a>
                                </td>
                            </tr>
                            <tr>
                                <th>私信</th>
                                <td>
                                    <a href="/Pages/HomeManage/Translate.aspx" rel="nofollow" target="_blank">
                                        <i class="fa fa-envelope"></i>发送私信
                                    </a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
