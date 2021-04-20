using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.Cos.Web.Service.App_Public
{
    /// <summary>
    /// QQToken 的摘要说明
    /// QQ登录受理
    /// </summary>
    public class QQToken : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //string 
            //if (string.IsNullOrEmpty(context.Request.QueryString["code"]))
            //{
            //    //Response.Redirect("/login.aspx", true);
            //    context.Response.Write("<script>alert('请先登录！');window.close();</script>");
            //    context.Response.End();
            //}
            //else
            //{
            //    string code = Request.QueryString["code"];
            //    string QQTOKEN = SinaQQ.QQApi.GetGetAuth(code);
            //    if (string.IsNullOrEmpty(QQTOKEN))
            //    {
            //        Response.Write("<script>alert('QQ验证失败，请稍候重试1！');window.close();</script>");
            //        Response.End();
            //    }
            //    string qqusertoken = SinaQQ.QQApi.GetTokenVal(QQTOKEN); //取得koent
            //    if (string.IsNullOrEmpty(qqusertoken))
            //    {
            //        Response.Write("<script>alert('QQ验证失败，请稍候重试2！');window.close();</script>");
            //        Response.End();
            //    }
            //    string openid = SinaQQ.QQApi.GetOpenId(qqusertoken);//取得QQopenid
            //    if (string.IsNullOrEmpty(openid))
            //    {
            //        Response.Write("<script>alert('QQ验证失败，请稍候重试3！');window.close();</script>");
            //        Response.End();
            //    }



            //    if (Api.Member.Cookies.IsLogin())
            //    {
            //        //已经登录的绑定QQ帐号
            //        int efuuid = Api.Member.MemberBll.QQUidToEfuUid(openid);
            //        if (efuuid == 0)
            //        {
            //            //没有绑定帐号就绑定
            //            bool tb1 = Api.Member.MemberBll.QQUserSet(Api.Member.Cookies.Uid(), openid, qqusertoken);
            //            if (tb1)
            //            {
            //                //Msg.Show("绑定QQ帐号成功！", "/2013/");
            //                Response.Write("<script>alert('绑定QQ帐号成功！');window.opener.location.href=\"/2013/\";window.close();</script>");

            //                Response.End();
            //            }
            //            else
            //            {
            //                Response.Write("<script>alert('绑定QQ帐号失败！');window.opener.location.href=\"/2013/\";window.close();</script>");

            //                Response.End();
            //            }
            //        }
            //        else
            //        {
            //            //绑定后就登录成功
            //            string gourl;
            //            if (Session["gourl1"] != null)
            //            {
            //                gourl = Session["gourl1"].ToString();
            //            }
            //            else
            //            {
            //                gourl = "/2013/default.aspx";
            //            }
            //            //Msg.Show("登录成功!", gourl);
            //            Response.Write("<script>window.opener.location.href=\"" + gourl + "\";window.close();</script>");

            //            Response.End();
            //        }
            //    }
            //    else
            //    {


            //        //没有登录
            //        int efuuid = Api.Member.MemberBll.QQUidToEfuUid(openid);
            //        if (efuuid == 0)
            //        {
            //            SinaQQ.UserInfo qquser = SinaQQ.QQApi.GetUserInfo(qqusertoken, openid);//取得qq用户信息
            //            if (qquser == null)
            //            {
            //                //Msg.Show("QQ验证失败，请稍候重试！", "/login.aspx");
            //                Response.Write("<script>alert('QQ验证失败，请稍候重试4！');window.close();</script>");

            //                Response.End();
            //            }

            //            //没有efu帐号，创建一个EFU帐号
            //            //创建一个个人会员
            //            efuuid = RegUser(qqusertoken, openid, qquser);

            //            if (efuuid == 0)
            //            {
            //                // Msg.Show("创建中国服装网用户资料失败，请稍候重试！", "/login.aspx");
            //                Response.Write("<script>alert('创建中国服装网用户资料失败，请稍候重试！');window.close();</script>");

            //                Response.End();
            //            }
            //        }

            //        //更新Token
            //        Api.Member.MemberBll.QQTokenSet(efuuid, qqusertoken);

            //        //使用UID登录中服的会员
            //        BoolStr bls = Api.Member.MemberBll.Login(efuuid);
            //        if (bls.OK)
            //        {
            //            string gourl = Request.QueryString["state"];
            //            if (string.IsNullOrEmpty(gourl))
            //            {
            //                gourl = "/2013/default.aspx";
            //            }
            //            //Msg.Show(bls.Msg, gourl);
            //            Response.Write("<script>window.opener.location.href=\"" + gourl + "\";window.close();</script>");
            //            Response.End();
            //        }
            //        else
            //        {
            //            //Msg.Show(bls.Msg, "/login.aspx");
            //            Response.Write("<script>alert('" + bls.Msg + "');window.close();</script>");

            //            Response.End();
            //        }

            //        //没有登录 end
            //    }

            //}
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}