<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/AccountMaster.master" AutoEventWireup="true" CodeBehind="Bomb.aspx.cs" Inherits="Com.Cos.Web.Pages.HomeManage.Bomb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Style/css/frontend-logged-default.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form" runat="server">
    <div class="well">
        <p>欢迎来到轰炸小游戏。你可以消耗你的萌币去轰炸对手的萌币。轰炸之前，请看下列规则说明：</p>
        <ol>
            <li>如果你命中你轰炸的目标，你消耗的萌币将会返还并且获得你所轰炸的萌币数量。</li>
            <li>如果你没命中你轰炸的目标，目标将会获得你轰炸萌币数量的一半。</li>
            <li>轰炸有风险，轰炸须谨慎！小心对方会反击哦<small>（在反击前炸光他不就好了嘛XD）</small>。</li>
        </ol>
    </div>
    <form class="form-horizontal" action="javascript:;" method="post">
        <div class="form-group">
            <div class="g-tablet-2-5">
                <div class="bomb-area bomb-area-attacker">
                    <p>
                        <img id="bomb-attacker-avatar" src="<%=MemberEntity.Portrait %>" alt="头像" class="avatar" width="100" height="100">
                    </p>
                    <p class="bomb-area-meta">
                        <img src="/Style/img/integral.gif" alt="icon" width="15" height="15">
                        <strong id="bomb-attacker-points"><%=MemberEntity.integral %></strong>
                    </p>
                    <p class="bomb-area-meta">
                        <%=MemberEntity.nickname %>
                    </p>
                </div>
            </div>
            <!-- .g-tablet-2-5 -->

            <div class="g-tablet-1-5 bomb-area-points">
                <h4>轰炸数量</h4>
                <label for="bomb-point-5" class="label label-default label-success">
                    <img src="/Style/img/integral.gif" alt="icon" width="15" height="15">
                    5						
                    <input type="radio" name="points" id="bomb-point-5" class="bomb-points" value="5" checked hidden>
                </label>
                <label for="bomb-point-10" class="label label-default">
                    <img src="/Style/img/integral.gif" alt="icon" width="15" height="15">
                    10						
                    <input type="radio" name="points" id="bomb-point-10" class="bomb-points" value="10" hidden>
                </label>
                <label for="bomb-point-50" class="label label-default">
                    <img src="/Style/img/integral.gif" alt="icon" width="15" height="15">
                    50						
                    <input type="radio" name="points" id="bomb-point-50" class="bomb-points" value="50" hidden>
                </label>
                <label for="bomb-point-100" class="label label-default">
                    <img src="/Style/img/integral.gif" alt="icon" width="15" height="15">
                    100						
                    <input type="radio" name="points" id="bomb-point-100" class="bomb-points" value="100" hidden>
                </label>
                <label for="bomb-point-500" class="label label-default">
                    <img src="/Style/img/integral.gif" alt="icon" width="15" height="15">
                    500						
                    <input type="radio" name="points" id="bomb-point-500" class="bomb-points" value="500" hidden>
                </label>
                <label for="bomb-point-2000" class="label label-default">
                    <img src="/Style/img/integral.gif" alt="icon" width="15" height="15">
                    2000						
                    <input type="radio" name="points" id="bomb-point-2000" class="bomb-points" value="2000" hidden>
                </label>
            </div>
            <div class="g-tablet-2-5">
                <div class="bomb-area bomb-area-target">
                    <p>
                        <img id="bomb-target-avatar" src="/Upload/Portrait/1.jpg" alt="头像" class="avatar" width="100" height="100">
                    </p>
                    <p class="bomb-area-meta">
                        <img src="/Style/img/integral.gif" alt="icon" width="15" height="15">
                        <strong id="bomb-target-points">-
                        </strong>
                    </p>
                    <p class="bomb-area-meta" id="bomb-target-name">
                        -目标名称-
                    </p>
                    <p>
                        <span>
                            <input id="bomb-target" type="text" name="target" class="form-control" placeholder="目标 UID，例如：105844" value="" required>
                        </span>
                    </p>
                </div>
            </div>
            <!-- .row -->
        </div>
        <!-- .form-group -->
        <div class="form-group">
            <div class="g-desktop-1-1">
                <input type="text" class="form-control text-center" name="says" id="bomb-says" placeholder="出招不喊招数名吗？" maxlength="30">
            </div>
        </div>
        <div class="form-group">
            <div class="g-desktop-1-1">
                <input type="hidden" name="type" value="bomb">
                <button class="submit btn btn-success btn-lg btn-block" type="submit" data-loading-tx="正在轰炸中……" disabled>
                    <i class="fa fa-bomb"></i>
                    开始轰炸，BOOM！
                </button>
            </div>
        </div>
    </form>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>var active_menu="游戏"</script>
    <script>
        $(document).ready(function() {
            $('input[type="radio"]').click(function () {
                $(this).parent().addClass("label-success");
                $(this).parent().siblings().removeClass("label-success");
            });
        });
    </script>
</asp:Content>
