<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/App_Master/SiteMaster.Master" AutoEventWireup="true" CodeBehind="MemberInfo.aspx.cs" Inherits="Com.Cos.Admin.Pages.MemberManage.MemberInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <asp:Repeater runat="server" ID="repMember">
            <ItemTemplate>
                <div class="col-sm-4">
                    <div class="contact-box">
                        <a href="/Pages/MemberManage/MemberProfile.aspx?id=<%#Eval("User_id") %>">
                            <div class="col-sm-4">
                                <div class="text-center">
                                    <img alt="image" class="img-circle m-t-xs img-responsive" src="<%#Eval("Portrait") %>">
                                    <div class="m-t-xs font-bold"><%#"Level " + Eval("Ugrade") %></div>
                                    <div class="m-t-xs font-bold"><%#"Level " + Eval("Ugrade") %></div>
                                </div>
                            </div>
                            <div class="col-sm-8">
                                <h3><strong><%#Eval("nickname") %></strong><i class="fa <%#SetGender(Eval("Gender").ToString()) %>"></i></h3>
                                <p><i class="fa fa-map-marker"></i>甘肃·兰州</p>
                                <address>
                                    <strong>Baidu, Inc.</strong><br>
                                    E-mail:<%#Eval("Email") %><br>
                                    Weibo:<a href="#">http://weibo.com/xxx</a><br>
                                    <abbr title="Phone">Tel:</abbr>
                                    <%#Eval("Phone_mob") %>
                       
                                </address>
                            </div>
                            <div class="clearfix"></div>
                        </a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
    <script>
        $(document).ready(function(){$(".contact-box").each(function(){animationHover(this,"pulse")})});
    </script>
</asp:Content>
