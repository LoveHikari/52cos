using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Com.Cos.Bll;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Com.Cos.Web.Service.HomeManage
{
    /// <summary>
    /// UpdateSettings 的摘要说明
    /// 我的设置保存操作
    /// </summary>
    public class UpdateSettings : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string userId = context.Request.Form["user[userId]"];
            string nickname = context.Request.Form["user[nickname]"];
            string email = context.Request.Form["user[email]"];
            string real_name = context.Request.Form["user[Real_name]"];
            string gender = context.Request.Form["user[gender]"];
            string year = context.Request.Form["user[year]"];
            string month = context.Request.Form["user[month]"];
            string day = context.Request.Form["user[day]"];
            string phone_mob = context.Request.Form["user[Phone_mob]"];
            string qq = context.Request.Form["user[qq]"];
            string description = context.Request.Form["user[description]"];
            string s = "{\"status\":\"error\"}";
            bool b = false;
            //判断是否已经存在昵称
            DataTable dt = MemberBll.Instance.GetList("nickname='"+nickname+"'").Tables[0];
            if (dt.Rows.Count > 0 && dt.Rows[0]["User_id"].ToString() != userId)
            {
                //已经存在
                s = "{\"status\":\"exist\"}";
            }
            else
            {
                MemberEntity memberEntity = MemberBll.Instance.GetModel(Convert.ToInt32(userId));
                memberEntity.nickname = nickname;
                memberEntity.Email = email;
                memberEntity.Real_name = real_name;
                memberEntity.Gender = gender;
                memberEntity.Birthday = year.PadLeft(4, '0') + "-" + month.PadLeft(2, '0') + "-" + day.PadLeft(2, '0');
                memberEntity.Phone_mob = phone_mob;
                memberEntity.Im_qq = qq;
                memberEntity.Describe = description;
                b = MemberBll.Instance.Update(memberEntity);
                if (b)
                {
                    s = "{\"status\":\"success\"}";
                }
            }

            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            context.Response.Write(s);
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