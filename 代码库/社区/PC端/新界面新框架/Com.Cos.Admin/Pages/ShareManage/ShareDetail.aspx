<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="ShareDetail.aspx.cs" Inherits="Com.Cos.Admin.Pages.ShareManage.ShareDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-10 col-lg-offset-1">
            <div class="ibox">
                <div class="ibox-content">
                    <div class="pull-right">
                        <asp:Literal runat="server" ID="litLabel"></asp:Literal>
                    </div>
                    <div class="text-center article-title">
                        <h1><%=ExchangeEntity.Title %></h1>
                    </div>
                    <%=WorksEntity.WorksContent %>

                    <hr>

                    <div class="row">
                        <div class="col-lg-12">
                            <h2>评论：</h2>
                            <asp:Repeater runat="server" ID="repReply">
                                <ItemTemplate>
                                    <div class="social-feed-box">
                                        <div class="social-avatar">
                                            <a href="#" class="pull-left">
                                                <img alt="image" src="<%#Eval("Portrait") %>">
                                            </a>
                                            <div class="media-body">
                                                <a href="#"><%#Eval("nickname") %>
                                                </a>
                                                <small class="text-muted"><%#GetTime(Eval("ReleaseTime").ToString()) %></small>
                                            </div>
                                        </div>
                                        <div class="social-body">
                                            <%#Eval("ReplyContent") %>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
