<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="Agreement.aspx.cs" Inherits="Com.Cos.Web.Pages.NavigationManage.Agreement" %>

<%@ Register Src="~/Controls/QuickNavigation.ascx" TagPrefix="uc1" TagName="QuickNavigation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="g">
        <div class="row">
            <div id="main" class="main g-desktop-3-4">
                <!--左边正文部分-->
                <article id="post-86" class=" singular-post panel post-86 post type-post status-publish format-standard has-post-thumbnail hentry category-acgtuji category-hjhc tag-18 tag-19 tag-21 tag-20">
                    <h2 class="entry-title"><%=QuickNavigationEntity.Title %></h2>
                    <div class="entry-body">
                        <%=QuickNavigationEntity.Cont %>
                    </div>
                </article>

            </div>
            <!--右边-->
            <div id="sidebar-container" class="g-desktop-1-4">
                <div id="sidebar" class="widget-area" role="complementary">
                    <uc1:QuickNavigation runat="server" ID="QuickNavigation" />
                </div>
            </div>
            <!---->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    
</asp:Content>
