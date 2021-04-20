using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Cos.Bll;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Web.Pages.App_Master
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected MemberEntity MemberEntity
        {
            set { ViewState["MemberEntity"] = value; }
            get
            {
                return ViewState["MemberEntity"] as MemberEntity;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CookieHelper.GetCookieValue("52cos", "user_id") != null && CookieHelper.GetCookieValue("52cos", "pwd") != "")
            {
                string userId = DEncryptUtils.DESDecrypt(CookieHelper.GetCookieValue("52cos", "user_id")).Replace("\0", "");
                string pwd = CookieHelper.GetCookieValue("52cos", "pwd");
                List<MemberEntity> list = MemberBll.Instance.GetModelList("User_id='" + userId + "' AND Password='" + pwd + "'");
                if (list.Count > 0)
                {
                    this.MemberEntity = list[0];

                    if (Session["UserInfo"] == null)
                    {
                        Session["UserInfo"] = this.MemberEntity;
                    }

                    //RecordIp(userId);
                    //UpdateLoginIp(userId);
                    //BindMenu();
                    //#region MyRegion
                    //string s = string.Format(@"<div class='tool tool-me'>
                    //                                <a href='/zl/zl-{1}.html'><!--用户主页地址-->
                    //                                 <img class='avatar' width='32' height='32' src='{0}' alt='avatar'><!--头像-->
                    //                                 <i class='fa fa-angle-down'></i>
                    //                                </a>
                    //                                <div class='box'>
                    //                                 <!-- points -->
                    //                                 <div class='box-points'>
                    //                                  <a href='/zl/zl-{1}.html' alt='0/10000'>
                    //                                   <img src='/Style/img/integral.gif' alt='' width='16' height='16'>
                    //                                   Level {5}
                    //                                  </a>
                    //                                 </div>
                    //                                 <div class='box-points'>
                    //                                  <a href='/yh/history.html'>
                    //                                   <img src='/Style/img/integral.gif' alt='' width='16' height='16' title='{2} 节操 {3} 热心 {4} CN币 {6} 身家'>
                    //                                   {2} 节操 {6} 身家
                    //                                  </a>
                    //                                 </div>
                    //                                 <ul>
                    //                                  <li class=''>
                    //                                   <a href='/yh/dashboard.html'>
                    //                                    <i class='fa fa-dashboard fa-fw'></i>
                    //                                    用户中心
                    //                                   </a>
                    //                                  </li>
                    //                                  <li class=''>
                    //                                   <a href='/yh/contributions.html'>
                    //                                    <i class='fa fa-paint-brush fa-fw'></i>
                    //                                    文章投稿
                    //                                   </a>
                    //                                  </li>
                    //                                  <li class=''>
                    //                                   <a href='/yh/mytg.html'>
                    //                                    <i class='fa fa-lightbulb-o fa-fw'></i>
                    //                                    我的投稿
                    //                                   </a>
                    //                                  </li>
                    //                                  <li class=''>
                    //                                   <a href='/yh/translate.html'>
                    //                                    <i class='fa fa-envelope fa-fw'></i>
                    //                                    私信
                    //                                   </a>
                    //                                  </li>
                    //                                  <li class=''>
                    //                                   <a href='/yh/bomb.html'>
                    //                                    <i class='fa fa-bomb fa-fw'></i>
                    //                                    轰炸小游戏
                    //                                   </a>
                    //                                  </li>
                    //                                  <li class=''>
                    //                                   <a href='/yh/notifications.html'>
                    //                                    <i class='fa fa-bell fa-fw'></i>
                    //                                    我的提醒
                    //                                   </a>
                    //                                  </li>
                    //                                  <li class=''>
                    //                                   <a href='/yh/history.html'>
                    //                                    <i class='fa fa-history fa-fw'></i>
                    //                                    积分历史
                    //                                   </a>
                    //                                  </li>
                    //                                  <li class=''>
                    //                                   <a href='/yh/settings.html'>
                    //                                    <i class='fa fa-cog fa-fw'></i>
                    //                                    我的设置
                    //                                   </a>
                    //                                  </li>
                    //                                  <li class=''>
                    //                                   <a href='/yh/medal.html'>
                    //                                    <i class='fa fa-bookmark fa-fw'></i>
                    //                                    勋章中心
                    //                                   </a>
                    //                                  </li>
                    //                                  <li class=''>
                    //                                   <a href='/yh/lottery.html'>
                    //                                    <i class='fa fa-yelp fa-fw'></i>
                    //                                    积分商城
                    //                                   </a>
                    //                                  </li>
                    //                                  <li class=''>
                    //                                   <a href='/yh/avatar.html'>
                    //                                    <i class='fa fa-github-alt fa-fw'></i>
                    //                                    我的头像
                    //                                   </a>
                    //                                  </li>
                    //                                        <li class=''>
                    //                                   <a href='/yh/recharge.html'>
                    //                                    <i class='fa fa-database'></i>
                    //                                    立刻充值
                    //                                   </a>
                    //                                  </li>
                    //                                        <li class=''>
                    //                                   <a href='/yh/exchange.html'>
                    //                                    <i class='fa fa-link'></i>
                    //                                    发布兑换
                    //                                   </a>
                    //                                  </li>
                    //                                  <li class=''>
                    //                                   <a href='/yh/password.html'>
                    //                                    <i class='fa fa-lock fa-fw'></i>
                    //                                    修改密码
                    //                                   </a>
                    //                                  </li>
                    //                                  <li><a href='/prompts.html'><i class='fa fa-sign-out fa-fw'></i>登出</a></li>
                    //                                 </ul>
                    //                                </div>
                    //                                </div>", 
                    //dt.Rows[0]["portrait"], userId, dt.Rows[0]["integral"], dt.Rows[0]["ardent"], dt.Rows[0]["CNbi"], dt.Rows[0]["Ugrade"], dt.Rows[0]["Shenjia"]);
                    //userbar.InnerHtml = s + "<a href=\"javascript:;\" class=\"tool search fa fa-search fa-2x\" data-toggle-target=\"#fm-search\" data-focus-target=\"#fm-search-s\" data-icon-active=\"fa-arrow-down\" data-icon-original=\"fa-search\" title=\"搜索\"></a>";
                    //#endregion
                }
            }
        }
        
        /// <summary>
        /// 记录IP
        /// </summary>
        private void RecordIp(string userId)
        {
            //查询今天是否是首次登录
            string ip = IpHelper.GetUserIp();
            DateTime nowTime = DateTime.Now;
            bool b = LoginIPBll.Instance.ExistsIp(userId, nowTime);
            if (!b)
            {
                //不存在
                //计算随机节操
                int integral = UtilityHelper.ReturnRandomIntegral();
                //记录Ip并加节操，热心+1，成长值+1
                LoginIPEntity loginIpEntity = new LoginIPEntity();
                loginIpEntity.User_id = userId;
                loginIpEntity.Last_ip = ip;
                loginIpEntity.Lastddress = ""; //IpHelper.GetstringIpAddress(ip);
                loginIpEntity.LastTime = nowTime;
                loginIpEntity.Status = 1;
                LoginIPBll.Instance.Add(loginIpEntity);
                MemberBll.Instance.UpdateIntegral(userId, "integral", integral.ToString()); //修改节操
                MemberBll.Instance.UpdateIntegral(userId, "ardent", "1"); //修改热心
                MemberBll.Instance.UpdateIntegral(userId, "Growth ", "1"); //修改会员成长值

                IntegralChangeEntity integralChangeEntity = new IntegralChangeEntity();
                integralChangeEntity.UserId = userId;
                integralChangeEntity.source = "dailyLogin";
                integralChangeEntity.Cnbi = "0";
                integralChangeEntity.integral = integral;
                integralChangeEntity.ardent = 1;
                integralChangeEntity.Growth = 1;
                integralChangeEntity.Status = 1;
                integralChangeEntity.AddTime = DateTime.Now;
                integralChangeEntity.Bean = "0";
                integralChangeEntity.ShenJia = 0;
                IntegralChangeBll.Instance.Add(integralChangeEntity);  //记录积分变更

                Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "layer.msg('恭喜您获得节操：+" + integral + "，热心：+1，成长值：+1');", true);
            }

        }

        private void UpdateLoginIp(string userId)
        {
            if (CookieHelper.GetCookieValue("52cos", "login") == null)
            {
                //修改ip
                MemberEntity memberEntity = MemberBll.Instance.GetModel(Convert.ToInt32(userId));
                memberEntity.Last_ip = IpHelper.GetUserIp();
                memberEntity.Last_login = DateTime.Now;
                memberEntity.Logins += 1;
                MemberBll.Instance.Update(memberEntity);
                Context.Response.Cookies.Add(new HttpCookie("login", "login"));
            }
        }
        /// <summary>
        /// 绑定模块
        /// </summary>
        private void BindMenu()
        {
            DataTable dt = MenuModuleBll.Instance.GetList(0, "ParentType='0001' AND Status=1", "RefType").Tables[0];
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
}