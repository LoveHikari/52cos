<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExchangeOperateControl.ascx.cs" Inherits="Com.Cos.Admin.Controls.ExchangeOperateControl" %>

<% if (ExamineName == "审核中")
    {%>
<a style="text-decoration: none" onclick="article_shenhe(this,'<%#Eval("Id") %>')" href="javascript:;" title="审核">审核</a>
<%}%>

<% else if (ExamineName == "已审核")
   {%>
    <a style="text-decoration: none" href="javascript:;" title="已审核">已审核</a>
<%}%>

<%else if(ExamineName == "回收中")
    {%>
<a class="c-primary" onclick="article_huishou(this,'<%#Eval("Id") %>')" href="javascript:;" title="确认回收">确认回收</a>
<%} %>

<%else if(ExamineName == "已兑换"){%>
<a style="text-decoration:none" onclick="article_start(this,'<%#Eval("Id") %>')" href="javascript:;" title="发布"><i class="Hui-iconfont"></i></a>
<%} %>

<%else if(ExamineName=="已结束") {%>
<a class="c-primary" onclick="article_shenqing(this,id)" href="javascript:;" title="申请上线">申请上线</a>
<%}%>

<%else{%>
<a style="text-decoration:none" onclick="article_stop(this,'<%#Eval("Id") %>')" href="javascript:;" title="下架"><i class="Hui-iconfont"></i></a>
<%} %>
