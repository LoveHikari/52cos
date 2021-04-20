<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="ShareView.aspx.cs" Inherits="Com.Cos.Admin.Pages.ShareManage.ShareView" %>

<%@ Import Namespace="Com.Cos.Api" %>
<%@ Import Namespace="Com.Cos.Utility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-9" style="width: 1000px">
            <div class="wrapper wrapper-content animated fadeInUp">
                <div class="ibox">
                    <div class="ibox-content">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="m-b-md">
                                    <%=show == "editor"?"<a href=\"javascript:Save();\" class=\"btn btn-white btn-xs pull-right\">保存</a>":"" %>
                                    <h2><%=ExchangeEntity.Title %></h2>
                                </div>
                                <dl class="dl-horizontal">
                                    <dt>状态：</dt>
                                    <dd><span class="label label-primary"><%=GetExamineText(ExchangeEntity.Examine) %></span>
                                        <% if (show != "editor")
                                           {
                                               Response.Write("<div style='display: none'>");
                                           }
                                        %>
                                        <a href="javascript:SetStatus('2')"><span class="label label-primary">进入审核期</span></a>
                                        <a href="javascript:SetStatus('3')"><span class="label label-primary">确认回收</span></a>
                                        <a href="javascript:SetStatus('4')"><span class="label label-primary">开放兑换</span></a>
                                        <a href="javascript:SetStatus('5')"><span class="label label-primary">确认发货</span></a>
                                        <a href="javascript:SetStatus('1')"><span class="label label-primary">进入公投中</span></a>
                                        <% if (show != "editor")
                                           {
                                            Response.Write("</div>");
                                            }%>
                                    </dd>
                                </dl>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-5">
                                <dl class="dl-horizontal">
                                    <dt>发布人：</dt>
                                    <dd><%=MemberApi.GetNickname(ExchangeEntity.UserId) %></dd>
                                    <dt>估价1：</dt>
                                    <dd><%=ExchangeEntity.Valuation1 %></dd>
                                    <dt>估价2：</dt>
                                    <dd><%=ExchangeEntity.Valuation2 %></dd>
                                    <dt>估价3：</dt>
                                    <dd><%=ExchangeEntity.Valuation3 %></dd>
                                    <dt>原价：</dt>
                                    <dd><%=ExchangeEntity.Price %></dd>
                                    <dt>兑换人：</dt>
                                    <dd class="project-people">
                                        <a href="javascript:;" style="<%=string.IsNullOrEmpty(ExchangeEntity.ExchangePerson)?"display: none;": ""%>">
                                            <img alt="" class="img-circle" title="<%=MemberApi.GetNickname(ExchangeEntity.ExchangePerson) %>" src="<%=UrlConfig.Instance._Web_sq + MemberApi.GetPortraitUrl(ExchangeEntity.ExchangePerson) %>">
                                        </a>

                                    </dd>
                                </dl>
                            </div>
                            <div class="col-sm-7" id="cluster_info">
                                <dl class="dl-horizontal">
                                    <dt>创建于：</dt>
                                    <dd><%=ExchangeEntity.AddTime.ToString("yyyy年MM月dd日 HH:mm:ss") %></dd>
                                    <dt>投票1：</dt>
                                    <dd><%=ExchangeEntity.Vote1 %></dd>
                                    <dt>投票2：</dt>
                                    <dd><%=ExchangeEntity.Vote2 %></dd>
                                    <dt>投票3：</dt>
                                    <dd><%=ExchangeEntity.Vote3 %></dd>
                                    <dt>官方价：</dt>
                                    <dd><%=show == "editor"? "<input type='text' id='txt_official' value='"+ExchangeEntity.Official+"' />": ExchangeEntity.Official %></dd>
                                    <dt>排队人员：</dt>
                                    <dd class="project-people">
                                        <asp:Repeater runat="server" ID="repQueuePerson">
                                            <ItemTemplate>
                                                <a href="project_detail.html">
                                                    <img alt="" class="img-circle" title="<%#MemberApi.GetNickname(Eval("UserId").ToString()) %>" src="<%#UrlConfig.Instance._Web_sq + MemberApi.GetPortraitUrl(Eval("UserId").ToString()) %>">
                                                </a>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </dd>
                                </dl>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <dl class="dl-horizontal">
                                    <dt>当前进度</dt>
                                    <dd>
                                        <div class="progress progress-striped active m-b-sm">
                                            <div style="width: <%=int.Parse(ExchangeEntity.Examine)/7.0*100%>%;" class="progress-bar"></div>
                                        </div>
                                        <small>当前已完成总进度的 <strong><%=(int.Parse(ExchangeEntity.Examine)/7.0*100).ToString("0")%>%</strong></small>
                                    </dd>
                                </dl>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>
        var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
        $(document).ready(function () {

        });
        //设置状态
        function SetStatus(param) {
            $.post("/Service/ShareManage/SetShareExamine.ashx", { ExId: '<%=ExchangeEntity.Id%>', Examine: param}, function (res) {
                var msg = eval("(" + res + ")");
                if (msg.status == "success") {
                    alert("修改成功");
                    location.reload();
                } else {
                    alert("修改失败");
                }
            }).error(function (){alert("系统出错");});
        }
        //保存官方价
        function Save(param) {
            var _exId = '<%=ExchangeEntity.Id%>';
            var _official = $('#txt_official').val();
            $.post("/Service/ShareManage/SaveOffical.ashx", {ExId: _exId, Official: _official}, function(res) {
                var msg = eval("(" + res + ")");
                if (msg.status == "success") {
                    alert("保存成功");
                    parent.location.reload();
                    parent.layer.close(index);
                } else {
                    alert("修改失败");
                }
            }).error(function () { alert("系统出错"); });
        }
    </script>
</asp:Content>
