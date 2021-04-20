using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Web.Http;
using Api.Models;
using Com.Cos.Api;
using Com.Cos.Bll;
using Com.Cos.Entity;
using Com.Cos.Utility;

namespace Api.Controllers
{
    /// <summary>
    /// 会员
    /// </summary>
    [AllowAnonymous]
    [Authorize]
    public class MemberController : ApiController
    {
        /// <summary>
        /// 登录验证
        /// api/Member/LoginValidate?acc={1@qq.com}&amp;pwd={123456}
        /// </summary>
        /// <param name="acc">注册邮箱或手机号</param>
        /// <param name="pwd">未加密的密码</param>
        /// <returns></returns>
        // POST api/Member/LoginValidate?acc=1@qq.com&pwd=123456
        [AcceptVerbs("POST")]
        public object LoginValidate(string acc, string pwd)
        {
            if (RegexUtil.IsEmail(acc))
            {
                DataTable dt = MemberBll.Instance.GetList("Email='" + acc + "' AND Password='" + DEncryptUtils.Encrypt3DES(pwd) + "'").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return new Dictionary<string, string>() { { "status", "200" }, { "UserId", dt.Rows[0]["User_id"].ToString() } };
                }
                else
                {
                    return new Dictionary<string, string>() { { "status", "400" }, { "message", "邮箱或密码不正确" } };
                }
            }
            else
            {
                DataTable dt = MemberBll.Instance.GetList("Phone_mob='" + acc + "' AND Password='" + DEncryptUtils.Encrypt3DES(pwd) + "'").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return new Dictionary<string, string>() { { "status", "200" }, { "UserId", dt.Rows[0]["User_id"].ToString() } };
                }
                else
                {
                    return new Dictionary<string, string>() { { "status", "400" }, { "message", "手机号或密码不正确" } };
                }
            }
            
        }

        /// <summary>
        /// 注册
        /// api/Member/Register?nickname={昵称}&amp;acc={1@qq.com}&amp;pwd={123456}
        /// </summary>
        /// <param name="nickname">昵称</param>
        /// <param name="acc">邮箱或手机号</param>
        /// <param name="pwd">密码（未加密）</param>
        /// <returns></returns>
        // POST api/Member/Register?nickname=昵称&acc=1@qq.com&pwd=123456
        [AcceptVerbs("POST")]
        public object Register(string nickname, string acc, string pwd)
        {
            if (RegexUtil.IsEmail(acc))
            {
                DataTable dt = MemberBll.Instance.GetList("Email='" + acc + "'").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return new Dictionary<string, string>() { { "status", "400" }, { "message", "该邮箱已被注册" } };
                }
            }
            else
            {
                DataTable dt = MemberBll.Instance.GetList($"Phone_mob='{acc}'").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return new Dictionary<string, string>() { { "status", "403" }, { "message", "该手机号已经注册" } };
                }
            }
            
            string status = MemberApi.Register(nickname, acc, pwd);
            return new Dictionary<string, string>() { { "status", "200" }, { "message", status } };
        }
        /// <summary>
        /// 判断邮箱是否已经被注册
        /// api/Member/EmailVerification?email={1@qq.com}
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <returns>{"status":400,"message":"该邮箱已被注册"}</returns>
        // POST api/Member/EmailVerification?email=1@qq.com
        [AcceptVerbs("POST")]
        public object EmailVerification(string email)
        {
            if (!RegexUtil.IsEmail(email))
            {
                return new Dictionary<string, string>() { { "status", "400" }, { "message", "邮箱不符合规范" } };
            }
            
            DataTable dt = MemberBll.Instance.GetList("Email='" + email + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return new Dictionary<string, string>() { { "status", "403" }, { "message", "该邮箱已被注册" } };
            }
            else
            {
                return new Dictionary<string, string>() { { "status", "200" }, { "message", "该邮箱未被注册" } };
            }
        }

        /// <summary>
        /// 修改密码
        /// api/Member/UpdatePassword?userId={1}&amp;oldPwd={123456}&amp;newPwd={1234}
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="oldPwd">原始密码（未加密）</param>
        /// <param name="newPwd">新密码（未加密）</param>
        /// <returns>{"status":400,"message":"修改成功"}</returns>
        // POST api/Member/UpdatePassword?userId=1&oldPwd=123456&newPwd=1234
        [AcceptVerbs("POST")]
        public object UpdatePassword(string userId, string oldPwd, string newPwd)
        {
            MemberEntity memberEntity = MemberBll.Instance.GetModel(Convert.ToInt32(userId));
            if (memberEntity != null)
            {
                if (memberEntity.Password == DEncryptUtils.Encrypt3DES(oldPwd))
                {
                    memberEntity.Password = DEncryptUtils.Encrypt3DES(newPwd);
                    if (MemberBll.Instance.Update(memberEntity))
                    {
                        return new Dictionary<string, string>() { { "status", "200" }, { "message", "修改成功" } };
                    }
                    else
                    {
                        return new Dictionary<string, string>() { { "status", "400" }, { "message", "修改失败" } };
                    }

                }
                else
                {
                    return new Dictionary<string, string>() { { "status", "400" }, { "message", "原始密码错误" } };
                }
            }
            else
            {
                return new Dictionary<string, string>() { { "status", "400" }, { "message", "未找到用户" } };
            }
        }

        /// <summary>
        /// 第三方登录，例：
        /// api/Member/ThirdPartyLogin?cn={qq}&amp;tuid={12532}&amp;nickname={昵称}&amp;figureurl={头像}
        /// </summary>
        /// <param name="cn">第三方，例：qq</param>
        /// <param name="tuid">第三方uid</param>
        /// <param name="nickname">第三方昵称</param>
        /// <param name="figureurl">第三方头像</param>
        /// <returns>{"status":"200","userId":"30"}</returns>
        // POST api/Member/ThirdPartyLogin?cn=qq&tuid=12532&nickname=昵称&figureurl=头像
        [AcceptVerbs("POST")]
        public object ThirdPartyLogin(string cn, string tuid, string nickname, string figureurl)
        {
            string strWhere = "1=1 ";
            if (cn.ToLower() == "qq")
            {
                strWhere += $"and im_qq='{tuid}' ";
            }
            else
            {
                strWhere += $"and Im_msn='{tuid}' ";
            }
            DataTable dt = MemberBll.Instance.GetList(strWhere).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return new Dictionary<string, string>() { { "status", "200" }, { "userId", dt.Rows[0]["User_id"].ToString() } };
            }
            MemberEntity memberEntity = new MemberEntity();
            memberEntity.User_name = "";
            if (cn == "qq")
            {
                memberEntity.Im_qq = tuid;
            }
            else
            {
                memberEntity.Im_msn = tuid;
            }
            memberEntity.Email = "";
            memberEntity.Real_name = "";
            memberEntity.Gender = "";
            memberEntity.Birthday = "";
            memberEntity.Phone_tel = "";
            memberEntity.Phone_mob = "";
            memberEntity.In_skype = "";
            memberEntity.Im_yahoo = "";
            memberEntity.Im_aliww = "";
            memberEntity.Reg_time = null;
            memberEntity.nickname = nickname;
            memberEntity.Portrait = figureurl;
            memberEntity.Password = "";
            memberEntity.Logins = 0;
            memberEntity.Ugrade = 1;
            memberEntity.Status = 1;
            memberEntity.reward = 0;
            memberEntity.CNbi = 0;
            memberEntity.integral = 0;
            memberEntity.ardent = 0;
            memberEntity.Growth = 0;
            memberEntity.Shenjia = 0;

            int id = MemberBll.Instance.Add(memberEntity);
            return new Dictionary<string, string>() { { "status", "200" }, { "userId", id.ToString() } };
        }
        
        /// <summary>
        /// 获得合作实体信息
        /// api/Member/GetMemberEntity/{1}
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        // GET api/Member/GetMemberEntity/1
        [AcceptVerbs("GET")]
        public object GetMemberEntity(int id)
        {
            MemberEntity memberEntity = MemberBll.Instance.GetModel(id);
            memberEntity.Portrait = memberEntity.Portrait.Replace("\\","/");
            if (memberEntity == null)
            {
                return new KeyValuePair<string, StatusEnum>("status", StatusEnum.empty);
            }
            return new DataTableModels
            {
                Dt = memberEntity,
                Status = StatusEnum.success
            };
        }

    }
}
