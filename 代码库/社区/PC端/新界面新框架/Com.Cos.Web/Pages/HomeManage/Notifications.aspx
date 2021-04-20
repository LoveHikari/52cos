<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/AccountMaster.master" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="Com.Cos.Web.Pages.HomeManage.Notifications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form" runat="server">
    <div class="row">
        <div class="account-dashboard account-dashboard-right g-tablet-3-5" style="width: 100%">
            <div class="panel">
                <div class="heading">
                    <i class="fa fa-clock-o"></i>
                    系统提醒
                </div>
                <ul class="list-group history-group">
                    <asp:Repeater runat="server" ID="Repeater1">
                        <ItemTemplate>
                            <li class="list-group-item">
                                <div class="media">
                                    <div class="media-body">
                                        <div class="media-heading">
                                            <%#Eval("Title") %>
                                        </div>
                                        <div class="media-object">
                                            <%#Eval("Body") %>
                                        </div>
                                        <div class="media-bottom">
                                            <%#Convert.ToDateTime(Eval("AddTime")).ToString("yyyy-MM-dd HH:mm:ss") %>
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div class="page-tip" runat="server" visible='<%#bool.Parse((Repeater1.Items.Count==0).ToString())%>'>
                                <div class="tip-status tip-status-small tip-status-info"><i class="fa fa-exclamation-circle fa-fw"></i>您暂无任何提醒。</div>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>var active_menu = "提醒"</script>
</asp:Content>
