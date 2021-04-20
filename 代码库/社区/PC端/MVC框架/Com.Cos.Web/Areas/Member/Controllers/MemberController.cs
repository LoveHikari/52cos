using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Com.Cos.BLL;
using Com.Cos.Common;
using Com.Cos.IBLL;
using Com.Cos.Models.Config;
using Com.Cos.Web.Areas.Member.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Com.Cos.Web.Areas.Member.Controllers
{
    public class MemberController : Controller
    {
        #region 私有属性
        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }
        #endregion
        private readonly Com.Cos.IBLL.IMemberService _memberService;
        private readonly Com.Cos.IBLL.IRechargeRecordService _rechargeRecordService;
        private readonly Com.Cos.IBLL.IExchangeService _exchangeService;
        private readonly Com.Cos.IBLL.IIntegralSourceService _integralSourceService;
        private readonly Com.Cos.IBLL.IExchangeExamineService _exchangeExamineService;
        private readonly Com.Cos.IBLL.IImgService _imgService;
        private readonly Com.Cos.IBLL.ICooperationService _cooperationService;

        private readonly int _userId;
        private readonly Com.Cos.Models.Member _member;

        public MemberController()
        {
            _memberService = new MemberService();
            _rechargeRecordService = new RechargeRecordService();
            _exchangeService = new ExchangeService();
            _integralSourceService = new IntegralSourceService();
            _exchangeExamineService = new ExchangeExamineService();
            _imgService = new ImgService();
            _cooperationService = new CooperationService();

            _userId = Com.Cos.Common.Public.GetLoginUid();
            _member = _memberService.Find(_userId);
        }

        #region Action
        /// <summary>
        /// 身家充值
        /// </summary>
        /// <returns></returns>
        //GET: User/Recharge
        [Authorize, AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Recharge()
        {
            return View();
        }

        /// <summary>
        /// 会员充值
        /// </summary>
        /// <returns></returns>
        // GET: User/BuyVip
        [Authorize, AcceptVerbs(HttpVerbs.Get)]
        public ActionResult BuyVip()
        {
            return View();
        }
        /// <summary>
        /// 用户中心/仪表板
        /// </summary>
        /// <returns></returns>
        // GET: User/Dashboard
        [ActionName("Dashboard"), Authorize, AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            int userId = Com.Cos.Common.Public.GetLoginUid();
            var user = _memberService.Find(userId);
            ViewBag.User = user;
            return View("Index");
        }
        /// <summary>
        /// 积分历史
        /// </summary>
        /// <returns></returns>
        // GET: User/History
        [Authorize, AcceptVerbs(HttpVerbs.Get)]
        public ActionResult History()
        {
            int userId = Com.Cos.Common.Public.GetLoginUid();
            int totalRecord;
            var bills = _rechargeRecordService.FindPageList(1, 10, out totalRecord, r => r.Status > 0 && r.UserId == userId.ToString(), "AddTime", false).ToList();
            for (int i = 0; i < bills.Count; i++)
            {
                string sorce = bills[i].Source;
                var integralSource = _integralSourceService.Find(p => p.RefValue == sorce);
                bills[i].Source = integralSource == null ? bills[i].Source : integralSource.RefText;
            }
            ViewBag.Bills = bills;

            return View();

        }
        /// <summary>
        /// 我的设置/账号设置
        /// </summary>
        /// <returns></returns>
        [Authorize, AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Account()
        {
            var member = new Com.Cos.Web.Areas.Member.Models.AccountViewModel
            {
                Nickname = _member.nickname,
                Email = _member.Email,
                RealName = _member.Real_name,
                Gender = _member.Gender,
                Birthday = _member.Birthday,
                PhoneMob = _member.Phone_mob,
                Describe = _member.Describe
            };
            _member.Portrait = Com.Cos.Common.TWEBURL.WEB_URL_IMG + _member.Portrait;
            ViewBag.Member = _member;
            return View("Account", member);
        }
        /// <summary>
        /// 我的头像
        /// </summary>
        /// <returns></returns>
        [Authorize, AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Avatar()
        {
            int uid = Com.Cos.Common.Public.GetLoginUid();
            var user = _memberService.Find(uid);
            ViewBag.User = user;

            return View("Avatar");
        }
        /// <summary>
        /// 修改手机
        /// </summary>
        /// <returns></returns>
        // GET: User/Phone
        public ActionResult Phone()
        {
            return PartialView("Phone");
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        // GET: User/Password
        public ActionResult Password()
        {
            return View("Password");
        }

        /// <summary>
        /// 我的发布
        /// </summary>
        /// <returns></returns>
        // // GET: User/Publish
        [Authorize, AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Publish()
        {
            string userId = Com.Cos.Common.Public.GetLoginUid().ToString();
            int totalRecord;
            var exchanges = _exchangeService.FindPageList(1, 5, out totalRecord, e => e.UserId == userId, "AddTime", false).ToList();
            ViewBag.PageIndex = 1;
            ViewBag.PageSize = 5;
            ViewBag.TotalRecord = totalRecord;
            for (int i = 0; i < exchanges.Count; i++)
            {
                exchanges[i].Examine = _exchangeExamineService.Find(exchanges[i].Examine.ToInt32()).ExamineName;
                string coverId = exchanges[i].Cover;
                if (string.IsNullOrEmpty(coverId))  //如果没有封面，则取第一张图片
                {
                    string imgList = exchanges[i].ImgList;
                    string[] imgs = imgList.Split(',');
                    coverId = imgs[0];
                }
                string cover = TWEBURL.WEB_URL_IMG + _imgService.Find(coverId.ToInt32())?.ImgSmallUrl;
                exchanges[i].Cover = cover;

            }
            ViewBag.Exchanges = exchanges;
            return View("Publish");
        }
        /// <summary>
        /// 我的发布-兑换
        /// </summary>
        /// <returns></returns>
        [Authorize, AcceptVerbs(HttpVerbs.Get)]
        public ActionResult PublishExchange(string p)
        {
            int page = p.ToInt32();  //当前页
            page = page < 1 ? 1 : page;
            string userId = Com.Cos.Common.Public.GetLoginUid().ToString();
            int totalRecord;
            var exchanges = _exchangeService.FindPageList(page, 5, out totalRecord, e => e.UserId == userId, "AddTime", false).ToList();
            for (int i = 0; i < exchanges.Count; i++)
            {
                exchanges[i].Examine = _exchangeExamineService.Find(exchanges[i].Examine.ToInt32()).ExamineName;
                string coverId = exchanges[i].Cover;
                if (string.IsNullOrEmpty(coverId))  //如果没有封面，则取第一张图片
                {
                    string imgList = exchanges[i].ImgList;
                    string[] imgs = imgList.Split(',');
                    coverId = imgs[0];
                }
                string cover = TWEBURL.WEB_URL_IMG + _imgService.Find(coverId.ToInt32())?.ImgSmallUrl;
                exchanges[i].Cover = cover;

            }
            var model = new PublishViewModel { Model = exchanges, PageSize = 5, PageIndex = page, TotalRecord = totalRecord };
            return PartialView("_PartialPublishExchange", model);
        }
        /// <summary>
        /// 我的发布-合作
        /// </summary>
        /// <returns></returns>
        [Authorize, AcceptVerbs(HttpVerbs.Get)]
        public ActionResult PublishCooperation(string p)
        {
            int page = p.ToInt32();  //当前页
            page = page < 1 ? 1 : page;
            string userId = Com.Cos.Common.Public.GetLoginUid().ToString();
            int totalRecord;
            var coos = _cooperationService.FindPageList(page, 5, out totalRecord, e => e.UserId == userId, "ReleaseTime", false).ToList();
            for (int i = 0; i < coos.Count; i++)
            {
                string coverId = coos[i].Cover;
                if (string.IsNullOrEmpty(coverId))  //如果没有封面，则取第一张图片
                {
                    string imgList = coos[i].ImgList;
                    string[] imgs = imgList.Split(',');
                    coverId = imgs[0];
                }
                string cover = TWEBURL.WEB_URL_IMG + _imgService.Find(coverId.ToInt32())?.ImgSmallUrl;
                coos[i].Cover = cover;

            }
            var model = new PublishViewModel { Model = coos, PageSize = 5, PageIndex = page, TotalRecord = totalRecord };
            return PartialView("_PartialPublishCooperation", model);
        }
        /// <summary>
        /// 我的参与
        /// </summary>
        /// <returns></returns>
        // GET: User/Participate
        [Authorize, AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Participate()
        {
            int userId = Com.Cos.Common.Public.GetLoginUid();
            int totalRecord;
            var exchanges = _exchangeService.FindPageList(1, 5, out totalRecord, ex => ex.UserId == userId.ToString(), "Id", false).ToList();
            ViewBag.PageIndex = 1;
            ViewBag.PageSize = 5;
            ViewBag.TotalRecord = totalRecord;
            for (int i = 0; i < exchanges.Count; i++)
            {
                string coverId = exchanges[i].Cover;
                if (string.IsNullOrEmpty(coverId))  //如果没有封面，则取第一张图片
                {
                    string imgList = exchanges[i].ImgList;
                    string[] imgs = imgList.Split(',');
                    coverId = imgs[0];
                }
                string cover = TWEBURL.WEB_URL_IMG + _imgService.Find(coverId.ToInt32())?.ImgSmallUrl;
                exchanges[i].Cover = cover;

            }
            ViewBag.Exchanges = exchanges;
            return View("Participate");
        }
        /// <summary>
        /// 我的参与-兑换
        /// </summary>
        /// <returns></returns>
        // GET: User/ParticipateExchange
        [Authorize, AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ParticipateExchange(string p)
        {
            int page = p.ToInt32();  //当前页
            page = page < 1 ? 1 : page;
            int userId = Com.Cos.Common.Public.GetLoginUid();
            int totalRecord;
            var exchanges = _exchangeService.FindPageList(page, 5, out totalRecord, ex => ex.UserId == userId.ToString(), "Id", false).ToList();
            ViewBag.PageIndex = 1;
            ViewBag.PageSize = 5;
            ViewBag.TotalRecord = totalRecord;
            for (int i = 0; i < exchanges.Count; i++)
            {
                string coverId = exchanges[i].Cover;
                if (string.IsNullOrEmpty(coverId))  //如果没有封面，则取第一张图片
                {
                    string imgList = exchanges[i].ImgList;
                    string[] imgs = imgList.Split(',');
                    coverId = imgs[0];
                }
                string cover = TWEBURL.WEB_URL_IMG + _imgService.Find(coverId.ToInt32())?.ImgSmallUrl;
                exchanges[i].Cover = cover;

            }
            ViewBag.Exchanges = exchanges;
            var model = new PublishViewModel { Model = exchanges, PageSize = 5, PageIndex = page, TotalRecord = totalRecord };
            return PartialView("_PartialParticipateExchange", model);
        }

        /// <summary>
        /// 我的参与-合作
        /// </summary>
        /// <returns></returns>
        // GET: User/ParticipateExchange
        [Authorize, AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ParticipateCooperation(string p)
        {
            int page = p.ToInt32();  //当前页
            page = page < 1 ? 1 : page;
            int userId = Com.Cos.Common.Public.GetLoginUid();
            int totalRecord;
            var coos = _cooperationService.FindPageList(page, 5, out totalRecord, ex => ex.UserId == userId.ToString(), "Id", false).ToList();
            ViewBag.PageIndex = 1;
            ViewBag.PageSize = 5;
            ViewBag.TotalRecord = totalRecord;
            for (int i = 0; i < coos.Count; i++)
            {
                string coverId = coos[i].Cover;
                if (string.IsNullOrEmpty(coverId))  //如果没有封面，则取第一张图片
                {
                    string imgList = coos[i].ImgList;
                    string[] imgs = imgList.Split(',');
                    coverId = imgs[0];
                }
                string cover = TWEBURL.WEB_URL_IMG + _imgService.Find(coverId.ToInt32())?.ImgSmallUrl;
                coos[i].Cover = cover;

            }
            ViewBag.coos = coos;
            var model = new PublishViewModel { Model = coos, PageSize = 5, PageIndex = page, TotalRecord = totalRecord };
            return PartialView("_PartialParticipateCooperation", model);
        }
        #endregion

        #region HttpPost

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="rechargeViewModel"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [Authorize, HttpPost]
        public ActionResult Recharge(RechargeViewModel rechargeViewModel)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                int userId = Com.Cos.Common.Public.GetLoginUid();
                string submit = Com.Cos.Common.AlipayHelper.BuildRequest(userId.ToString(), rechargeViewModel.RechargeMethod, rechargeViewModel.Subject);
                return Content(submit, "text/html");
            }
            if (rechargeViewModel.Subject == "身家充值")
            {
                return View("Recharge");
            }
            else
            {
                return View("BuyVip");
            }


        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken, Authorize, HttpPost]
        public ActionResult Password(PasswordViewModel model)
        {

            if (TempData["SMSCode"] == null || TempData["SMSCode"].ToString() != model.SMSCode.ToUpper())
            {
                ModelState.AddModelError("SMSCode", "短信验证码不正确");
                return PartialView("_PartialPassword", model);
            }
            if (ModelState.IsValid)
            {
                int uid = Com.Cos.Common.Public.GetLoginUid();
                var user = _memberService.Find(uid);
                if (user.Password != DEncryptUtils.Encrypt3DES(model.OldPassword))
                {
                    ModelState.AddModelError("OldPassword", "密码错误");
                    return PartialView("_PartialPassword", model);
                }
                else
                {
                    user.Password = DEncryptUtils.Encrypt3DES(model.Password);
                    bool b = _memberService.Update(user);
                    if (b)
                    {
                        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                        return Json(new Dictionary<string, string>() { { "status", "success" }, { "message", "修改成功" } });
                    }
                    else
                    {
                        return Json(new Dictionary<string, string>() { { "status", "error" }, { "message", "修改失败" } });
                    }
                }
            }

            return PartialView("_PartialPassword", model);
        }
        /// <summary>
        /// 修改我的设置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken, Authorize, HttpPost]
        public ActionResult Account(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                int uid = Com.Cos.Common.Public.GetLoginUid();
                var user = _memberService.Find(uid);
                user.nickname = model.Nickname;
                user.Email = model.Email;
                user.Real_name = model.RealName;
                user.Gender = model.Gender;
                user.Birthday = model.Birthday;
                user.Describe = model.Describe;
                bool b = _memberService.Update(user);
                if (b)
                {
                    return Json(Public.MessageJson(1, "修改成功"));
                }
                else
                {
                    return Json(Public.MessageJson(0, "修改失败"));
                }
            }
            return PartialView("_PartialAccount", model);
        }
        /// <summary>
        /// 修改手机号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken, Authorize, HttpPost]
        public ActionResult Phone(PhoneViewModel model)
        {
            if (TempData["SMSCode"] == null || TempData["SMSCode"].ToString() != model.SMSCode.ToUpper())
            {
                ModelState.AddModelError("SMSCode", "短信验证码不正确");
                return PartialView("_PartialPhone", model);
            }
            if (ModelState.IsValid)
            {

                int uid = Com.Cos.Common.Public.GetLoginUid();
                var user = _memberService.Find(m => m.Phone_mob == model.PhoneMob);
                if (user != null && user.User_id != uid)
                {
                    ModelState.AddModelError("PhoneMob", "手机号已存在");
                    return PartialView("_PartialPhone", model);
                }

                user = _memberService.Find(uid);
                user.Phone_mob = model.PhoneMob;
                bool b = _memberService.Update(user);
                if (b)
                {
                    return Json(Public.MessageJson(1, "修改成功"));
                }
                else
                {
                    return Json(Public.MessageJson(0, "修改失败"));
                }
            }
            return PartialView("_PartialPhone", model);
        }
        /// <summary>
        /// 修改头像
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: User/Avatar
        [Authorize, HttpPost]
        public ActionResult Avatar(FormCollection collection)
        {
            string imgBase64 = collection.Get("Base64");
            if (string.IsNullOrEmpty(imgBase64))
            {
                return Json(Public.MessageJson(1, "修改成功"));
            }
            int uid = Com.Cos.Common.Public.GetLoginUid();
            try
            {
                var user = _memberService.Find(uid);
                user.Portrait = UploadFile.UploadImg(imgBase64, Com.Cos.Models.Config.UploadConfig.Instance.PortraitPath);
                if (_memberService.Update(user))
                {
                    return Json(Public.MessageJson(1, "修改成功"));
                }
                else
                {
                    return Json(Public.MessageJson(0, "修改失败"));
                }
            }
            catch (Exception ex)
            {
                Com.Cos.Common.WriteLogHelper.WriteError(ex);
                throw;
            }


        }

        ///// <summary>
        ///// 获得我参与的数据
        ///// </summary>
        ///// <param name="view">视图名</param>
        ///// <param name="page">当前页</param>
        ///// <returns></returns>
        //[Authorize, HttpHead, ChildActionOnly]
        //public ActionResult GetParticipateData(string view, string page)
        //{
        //    int userId = Com.Cos.Common.Public.GetLoginUid();
        //    if (view == "Exchange")
        //    {
        //        var exchanges = _exchangeService.FindList(ex => ex.UserId == userId.ToString(), "Id", false);
        //        return PartialView("_PartialParticipateExchange", exchanges);
        //    }
        //    else
        //    {
        //        var cooperations = _exchangeService.FindList(ex => ex.UserId == userId.ToString(), "Id", false);
        //        return PartialView("_PartialParticipateCooperation", cooperations);
        //    }

        //}
        #endregion
    }
}
