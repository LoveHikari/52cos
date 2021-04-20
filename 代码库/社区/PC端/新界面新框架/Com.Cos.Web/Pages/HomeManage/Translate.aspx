<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/AccountMaster.master" AutoEventWireup="true" CodeBehind="Translate.aspx.cs" Inherits="Com.Cos.Web.Pages.HomeManage.Translate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel='stylesheet' id='frontend-css' href='/Style/css/frontend-logged-default.css' type='text/css' media='all' />
    <style>
        /* 半透明的遮罩层 */
.overlay {
    background: #000;
    filter: alpha(opacity=50); /* IE的透明度 */
    opacity: 0.5;  /* 透明度 */
    position: absolute;
    top: 20%;
    left: 20%;
    width: 100%;
    height: 100%;
    z-index: 100; /* 此处的图层要大于页面 */

}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="form" runat="server">
    <div class="row">
        <div class="g-tablet-1-6">
            <nav id="pm-tab" class="pm-tab">
                <a id="pm-tab-new" href="javascript:;" data-uid="new" class="active">
                    <i class="fa fa-plus fa-fw"></i>&nbsp;新建私信					</a>

                <a id="pm-tab-100036" href="javascript:;" data-uid="100036" data-url="#" class="">

                    <img src="#" alt="头像" class="avatar" width="24" height="24">

                    <span class="author">足控怎么办啊</span>

                    <b class="close">&times;</b>

                </a>


                <a id="pm-tab-100038" href="javascript:;" data-uid="100038" data-url="#" class="">

                    <img src="#" alt="头像" class="avatar" width="24" height="24">

                    <span class="author">JRK</span>

                    <b class="close">&times;</b>

                </a>

            </nav>
        </div>
        <div class="g-tablet-5-6">
            <div class="pm-dialog-container">
                <!-- pm-new -->
                <form action="javascript:;" id="pm-dialog-new" class="pm-dialog">
                    <p class="well">添加接收者 UID 以发送私信。</p>
                    <div class="form-group">
                        <input type="number" name="pm[new-receiver-id]" id="pm-dialog-content-new" class="form-control text-center" placeholder="接收者 UID，例如：105844" title="请输入接收者 UID" required min="1">
                    </div>
                    <div class="form-group">
                        <button type="submit" class="btn btn-success btn-block">下一步 <i class="fa fa-chevron-right"></i></button>
                    </div>
                </form>

                <form action="javascript:;" id="pm-dialog-100036" class="pm-dialog">

                    <div class="form-group pm-dialog-list">
                    </div>

                    <div class="form-group">

                        <input type="text" id="pm-dialog-content-100036" name="content" class="pm-dialog-conteng form-control" placeholder="回车发送私信。" required title="私信内容" autocomplete="off">
                    </div>

                    <div class="form-group">

                        <button class="btn btn-success btn-block" type="submit"><i class="fa fa-check"></i>&nbsp;发送私信</button>

                    </div>

                </form>


                <form action="javascript:;" id="pm-dialog-100038" class="pm-dialog">

                    <div class="form-group pm-dialog-list">
                    </div>

                    <div class="form-group">

                        <input type="text" id="pm-dialog-content-100038" name="content" class="pm-dialog-conteng form-control" placeholder="回车发送私信。" required title="私信内容" autocomplete="off">
                    </div>

                    <div class="form-group">

                        <button class="btn btn-success btn-block" type="submit"><i class="fa fa-check"></i>&nbsp;发送私信</button>

                    </div>

                </form>

            </div>
        </div>
        <!-- col -->
    </div>
    <!-- .row -->
    
    <div class="overlay">敬请期待</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>var active_menu="私信"</script>
</asp:Content>
