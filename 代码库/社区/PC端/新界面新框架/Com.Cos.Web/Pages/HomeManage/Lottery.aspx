<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/AccountMaster.master" AutoEventWireup="true" CodeBehind="Lottery.aspx.cs" Inherits="Com.Cos.Web.Pages.HomeManage.Lottery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Style/css/frontend-logged-default.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form" runat="server">
    <div class="content">
        <div class="well">
            <p>欢迎来到萌币商城！您可以消耗萌币去赢取兑换奖励，开始之前请阅读下列条目：</p>
            <ol>
                <li>可以兑换你想要得东西哟。</li>
                <li>也可以做做欧洲人。</li>
            </ol>
        </div>
        <form action="javascript:;" method="post" id="fm-lottery">
            <div class="form-group my-info">
                <span class="meta">
                    <img class="avatar" src="http://www.91moe.com/wp-content/uploads/avatar/37.jpg?v=1450054012" alt="子不语" width="16" height="16">
                    <span class="author">子不语</span>
                </span>
                <span class="meta">
                    <img src="/Style/img/integral.gif" alt="point-icon" width="16" height="16">
                    <span id="point-count">28</span><span id="modify-count"></span>
                </span>
            </div>
            <div class="form-group">
                <input type="radio" class="lottery-item" name="id" id="lottery-item-1462971671619" data-target="lottery-box-1462971671619" value="1462971671619" required>
                <label id="lottery-box-1462971671619" for="lottery-item-1462971671619" class="lottery-box">
                    <span class="icon">
                        <img src="/Style/img/integral.gif" alt="icon" width="16" height="16"></span>
                    <span class="name">抽取永久Svip权限 </span>
                    <span class="remaining">剩余：99</span>
                    <span class="des"><font size="5px"><strong><font color=\"red\"><p>100萌币抽取一次SVIP特权</p></font></strong></font>
                        <img src="/Style/img/shop/svip.jpg" style="max-width: 100%" height="150" />
                    </span>

                </label>
                <input type="radio" class="lottery-item" name="id" id="lottery-item-1462970932952" data-target="lottery-box-1462970932952" value="1462970932952" required>
                <label id="lottery-box-1462970932952" for="lottery-item-1462970932952" class="lottery-box">
                    <span class="icon"><i class="fa fa-yelp fa-fw"></i></span>
                    <span class="name">兑换永久vip权限 </span>
                    <span class="remaining">剩余：999</span>
                    <span class="des"><font size="5px"><strong><font color=\"red\"><p>10000萌币购买VIP特权</p></font></strong></font>
                        <img src="/Style/img/shop/vip.jpg" style="max-width: 100%" height="150" />
                    </span>

                </label>
                <input type="radio" class="lottery-item" name="id" id="lottery-item-1457634870797" data-target="lottery-box-1457634870797" value="1457634870797" required>
                <label id="lottery-box-1457634870797" for="lottery-item-1457634870797" class="lottery-box">
                    <span class="icon"><i class="fa fa-yelp fa-fw"></i></span>
                    <span class="name">【cn】Super Sonico圣诞索尼子手办 </span>
                    <span class="remaining">剩余：2</span>
                    <span class="des"><font size="5px"><strong><font color=\"red\"><p>200萌币抽一次</p></font></strong></font><img src="/Style/img/shop/2689855278_734705901.jpg" style="max-width: 100%" height="150" />
                        <img src="/Style/img/shop/2689855278_734705901.jpg" style="max-width: 100%" height="150" />
                        <img src="/Style/img/shop/2689855278_734705901.jpg" style="max-width: 100%" height="150" />
                    </span>

                </label>
                <input type="radio" class="lottery-item" name="id" id="lottery-item-1457635089861" data-target="lottery-box-1457635089861" value="1457635089861" required>
                <label id="lottery-box-1457635089861" for="lottery-item-1457635089861" class="lottery-box">
                    <span class="icon"><i class="fa fa-yelp fa-fw"></i></span>
                    <span class="name">【cn】粘土524# 土间埋 干物妹小埋手办 可替换脸Q版公仔模型 </span>
                    <span class="remaining">剩余：2</span>
                    <span class="des"><font size="5px"><strong><font color=\"red\"><p>200萌币抽一次</p></font></strong></font><img src="/Style/img/shop/2689855278_734705901.jpg" style="max-width: 100%" height="150" />
                        <img src="/Style/img/shop/2689855278_734705901.jpg" style="max-width: 100%" height="150" />
                    </span>

                </label>
                <input type="radio" class="lottery-item" name="id" id="lottery-item-1457636092248" data-target="lottery-box-1457636092248" value="1457636092248" required>
                <label id="lottery-box-1457636092248" for="lottery-item-1457636092248" class="lottery-box">
                    <span class="icon"><i class="fa fa-yelp fa-fw"></i></span>
                    <span class="name">【cn】初音未来 97#雪初音 Q版手办 特别版 换脸粘土人 </span>
                    <span class="remaining">剩余：2</span>
                    <span class="des"><font size="5px"><strong><font color=\"red\"><p>200萌币抽一次</p></font></strong></font><img src="/Style/img/shop/2689855278_734705901.jpg" style="max-width: 100%" height="150" />
                        <img src="/Style/img/shop/2689855278_734705901.jpg" style="max-width: 100%" height="150" />
                        <img src="/Style/img/shop/2689855278_734705901.jpg" style="max-width: 100%" height="150" />
                        <img src="/Style/img/shop/2689855278_734705901.jpg" style="max-width: 100%" height="150" />
                    </span>

                </label>
            </div>
            <div class="form-group">
                <button type="submit" class="submit btn btn-success btn-block btn-lg" data-loading-tx="加载中，请稍候…">
                    <i class="fa fa-check"></i>
                    祝您好运！			
                </button>
                <input type="hidden" name="type" value="start">
            </div>
        </form>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>var active_menu="商城"</script>
</asp:Content>
