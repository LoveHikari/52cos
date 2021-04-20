<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/AccountMaster.master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="Com.Cos.Web.Pages.HomeManage.History" %>
<%@ Import Namespace="Com.Cos.Utility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form" runat="server">
    <div class="panel">
        <div class="content">
            积分能换许多东西哦。	
            <div class="media">
                <div style="display: table-cell">
                    <div class="media-left">
                        <img class="media-object" src="/Style/img/integral.gif" alt="节操">
                    </div>
                    <div class="media-body">
                        <h4 class="media-heading">
                            <strong class="total-point"><%=MemberEntity.integral %></strong>
                        </h4>
                    </div>
                </div>
                <%--<div style="display: table-cell">
                    <div class="media-left">
                        <img class="media-object" src="/Style/img/integral.gif" alt="热心">
                    </div>
                    <div class="media-body">
                        <h4 class="media-heading">
                            <strong class="total-point"><%=MemberEntity.ardent %></strong>
                        </h4>
                    </div>
                </div>
                <div style="display: table-cell">
                    <div class="media-left">
                        <img class="media-object" src="/Style/img/integral.gif" alt="CN币">
                    </div>
                    <div class="media-body">
                        <h4 class="media-heading">
                            <strong class="total-point"><%=MemberEntity.CNbi %></strong>
                        </h4>
                    </div>
                </div>--%>
                <div style="display: table-cell">
                    <div class="media-left">
                        <img class="media-object" src="/Style/img/integral.gif" alt="身家">
                    </div>
                    <div class="media-body">
                        <h4 class="media-heading">
                            <strong class="total-point"><%=string.Format("{0:F2}", MemberEntity.Shenjia) %></strong>
                        </h4>
                    </div>
                </div>
            </div>
            <!-- .media -->
        </div>
        <!-- .content -->
        <ul class="list-group history-group">
            <asp:Repeater runat="server" ID="repIntCha">
                <ItemTemplate>
                    <li class="list-group-item">
                        <span class="point-icon"><i class="fa fa-2x fa-fw <%#SetImg(Eval("source").ToString()) %>"></i></span>
                        <span class="point-value plus">节操 <%#SetIntegral(Eval("integral").ToString()) %></span>
                        <%--<span class="point-value plus">热心 <%#SetIntegral(Eval("ardent").ToString()) %></span>
                        <span class="point-value plus">CN币 <%#SetIntegral(Eval("Cnbi").ToString()) %></span>--%>
                        <span class="point-value plus">身家 <%#SetIntegral(Eval("Shenjia").ToString()) %></span>
                        <span class="history-text"><%#GetIntegralSource(Eval("source").ToString()) %></span>
                        <span class="history-time"><%#UtilityHelper.GetTime(Eval("AddTime").ToString()) %></span>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>

    </div>
    <!-- .panel -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>var active_menu="历史"</script>
</asp:Content>
