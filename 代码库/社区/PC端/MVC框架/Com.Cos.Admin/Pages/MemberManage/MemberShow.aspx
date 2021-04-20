<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="MemberShow.aspx.cs" Inherits="Com.Cos.Admin.Pages.MemberManage.MemberShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cl pd-20" style=" background-color:#5bacb6">
	<img class="avatar size-XL l" src="<%:Com.Cos.Common.TWEBURL.WEB_URL_IMG + Member.Portrait %>">
	<dl style="margin-left:80px; color:#fff">
		<dt>
			<span class="f-18"><%:Member.nickname %></span>
			<span class="pl-10 f-12">身家：<%:Member.Shenjia %></span>
		</dt>
		<dd class="pt-10 f-12" style="margin-left:0"><%:Member.Describe==""?"这家伙很懒，什么也没有留下":Member.Describe %></dd>
	</dl>
</div>
<div class="pd-20">
	<table class="table">
		<tbody>
			<tr>
				<th class="text-r" width="80">性别：</th>
				<td><%:Com.Cos.Common.Public.GetGender(Member.Gender) %></td>
			</tr>
			<tr>
				<th class="text-r">手机：</th>
				<td><%:Member.Phone_mob %></td>
			</tr>
			<tr>
				<th class="text-r">邮箱：</th>
				<td><%:Member.Email %></td>
			</tr>
			<tr>
				<th class="text-r">地址：</th>
				<td>北京市 海淀区</td>
			</tr>
			<tr>
				<th class="text-r">注册时间：</th>
				<td><%:Member.Reg_time %></td>
			</tr>
            <tr>
				<th class="text-r">会员等级：</th>
				<td><%:Member.Lv %></td>
			</tr>
			<tr>
				<th class="text-r">会员时间：</th>
				<td><%:Member.Stime %> - <%:Member.Etime %></td>
			</tr>
		</tbody>
	</table>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
