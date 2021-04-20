using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Cos.Common;

namespace Com.Cos.Admin.Service.MemberManage
{
    /// <summary>
    /// AddMember 的摘要说明
    /// </summary>
    public class AddMember : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string s = "";
            int userId = context.Request.Form.Get("id").ToInt32();
            string password = context.Request.Form.Get("password");  //密码
            string sex = context.Request.Form.Get("sex");  //性别
            string mobile = context.Request.Form.Get("mobile");  //手机
            string email = context.Request.Form.Get("email");  //邮箱
            string realname = context.Request.Form.Get("realname");  //真实姓名
            string nickname = context.Request.Form.Get("nickname");  //昵称
            string shenjia = context.Request.Form.Get("shenjia"); //身家
            string conversions = context.Request.Form.Get("conversions"); //兑换总次数
            string remainingConversions = context.Request.Form.Get("remainingConversions");  //兑换剩余次数
            string stime = context.Request.Form.Get("stime"); //会员开始时间
            string etime = context.Request.Form.Get("etime");  //会员结束时间
            string birthday = context.Request.Form.Get("birthday");  //生日
            string describe = context.Request.Form.Get("describe");   //个人描述

            Com.Cos.IBLL.IMemberService memberService = new Com.Cos.BLL.MemberService();
            var member = memberService.Find(m => m.Phone_mob == mobile);
            if (member != null && member.User_id != userId)
            {
                s = Com.Cos.Common.Public.MessageJson(false, "手机号已经存在！");
            }
            else
            {
                if (member == null) //新增
                {
                    member = new Com.Cos.Models.Member()
                    {
                        User_name = "",
                        Password = Com.Cos.Common.DEncryptUtils.Encrypt3DES(password),
                        Gender = sex,
                        Phone_mob = mobile,
                        Email = email,
                        Real_name = realname,
                        nickname = nickname,
                        Shenjia = shenjia.ToDecimal(),
                        Conversions = conversions.ToInt32(),
                        RemainingConversions = remainingConversions.ToInt32(),
                        Stime = stime.ToDateTime2(),
                        Etime = etime.ToDateTime2(),
                        Birthday = birthday,
                        Describe = describe,
                        Reg_time = DateTime.Now,
                        Status = 1
                    };
                    member = memberService.Add(member);
                    if (member.User_id > 0)
                    {
                        s = Com.Cos.Common.Public.MessageJson(true, "保存成功");
                    }
                    else
                    {
                        s = Com.Cos.Common.Public.MessageJson(false, "保存失败");
                    }
                }
                else  //修改
                {
                    member.Password = Com.Cos.Common.DEncryptUtils.Encrypt3DES(password);
                    member.Gender = sex;
                    member.Phone_mob = mobile;
                    member.Email = email;
                    member.Real_name = realname;
                    member.nickname = nickname;
                    member.Shenjia = shenjia.ToDecimal();
                    member.Conversions = conversions.ToInt32();
                    member.RemainingConversions = remainingConversions.ToInt32();
                    member.Stime = stime.ToDateTime2();
                    member.Etime = etime.ToDateTime2();
                    member.Birthday = birthday;
                    member.Describe = describe;
                    if (memberService.Update(member))
                    {
                        s = Com.Cos.Common.Public.MessageJson(true, "修改成功");
                    }
                    else
                    {
                        s = Com.Cos.Common.Public.MessageJson(false, "修改失败");
                    }
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