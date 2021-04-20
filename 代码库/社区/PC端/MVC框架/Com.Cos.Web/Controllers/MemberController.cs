using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Cos.BLL;
using Com.Cos.Common;
using Com.Cos.IBLL;
using Com.Cos.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Com.Cos.Web.Controllers
{
    /// <summary>
    /// 会员
    /// </summary>
    public class MemberController : Controller
    {

        private IMemberService _memberService;

        public MemberController()
        {
            _memberService = new MemberService();
        }

        /// <summary>
        /// 判断邮箱或手机是否已经存在
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [AllowAnonymous,AcceptVerbs(HttpVerbs.Get)]
        public ActionResult CheckEmail(string email)
        {
            bool b;
            if (RegexUtil.IsEmail(email))  //是email
            {
                b = _memberService.Exist("Email", email);
            }
            else
            {
                
                b = _memberService.Exist("Phone_mob", email);
            }
            if (b)
            {
                ModelState.AddModelError("Email", "已存在的邮箱或手机号");
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 判断邮箱是否存在
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <returns></returns>
        [Authorize, AcceptVerbs(HttpVerbs.Get)]
        public ActionResult CheckEmail2(string email)
        {
            int uid = Com.Cos.Common.Public.GetLoginUid();
            var user = _memberService.Find(m=>m.Email==email);

            return Json(user==null || user.User_id == uid, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 确认手机号是否是绑定的手机号
        /// </summary>
        /// <param name="phoneMobile"></param>
        /// <returns></returns>
        [Authorize,AcceptVerbs(HttpVerbs.Get)]
        public ActionResult CheckPhone(string phoneMobile)
        {
            int uid = Com.Cos.Common.Public.GetLoginUid();
            var user = _memberService.Find(uid);
            return Json(user.Phone_mob == phoneMobile, JsonRequestBehavior.AllowGet);
            
        }
        /// <summary>
        /// 判断手机号是否存在
        /// </summary>
        /// <param name="phoneMob">手机号</param>
        /// <returns></returns>
        [Authorize, AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ChekPhone2(string phoneMob)
        {
            int uid = Com.Cos.Common.Public.GetLoginUid();
            var user = _memberService.Find(m => m.Phone_mob == phoneMob);

            return Json(user == null || user.User_id == uid, JsonRequestBehavior.AllowGet);
        }
    }
}