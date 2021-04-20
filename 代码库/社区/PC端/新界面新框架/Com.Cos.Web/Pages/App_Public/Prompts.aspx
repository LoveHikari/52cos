<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="Prompts.aspx.cs" Inherits="Com.Cos.Web.Pages.App_Public.Prompts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 80px;"></div>
    <div style="width: 600px; margin: 0 auto;">
        <div>
            <p>恭喜，你已成功退出！</p>
            <br />
            <br />
            <br />
            <a href="/Pages/App_Public/Index.aspx">如果您的浏览器没有自动跳转，请点击这里</a>
            <script language="javascript">setTimeout("window.location.href ='/Pages/App_Public/Index.aspx';", 2000);</script>
        </div>
    </div>
    <div style="height: 500px;"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
