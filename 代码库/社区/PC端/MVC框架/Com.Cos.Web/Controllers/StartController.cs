using Com.Cos.BLL;
using Com.Cos.Common;
using Com.Cos.IBLL;
using Com.Cos.Models;
using Com.Cos.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using Com.Cos.DAL;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Com.Cos.Web.Controllers
{
    public class StartController : Controller
    {
        #region 私有属性
        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }
        #endregion

        public UserManager<ApplicationUser> UserManager { get; private set; }

        private readonly IMemberService _memberService;
        private readonly ISlideService _slideService;
        private readonly IExchangeService _exchangeService;
        private readonly IImgService _imgService;
        private readonly ICooperationService _cooperationService;
        private readonly ILotteryService _lotteryService;
        private readonly IExchangeExamineService _exchangeExamineService;

        public StartController()
        {
            _memberService = new MemberService();
            _slideService = new SlideService();
            _exchangeService = new ExchangeService();
            _imgService = new ImgService();
            _cooperationService = new CooperationService();
            _lotteryService = new LotteryService();
            _exchangeExamineService = new ExchangeExamineService();

            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            UserManager.UserValidator = new UserValidator<ApplicationUser>(UserManager) { AllowOnlyAlphanumericUserNames = false };
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        // GET: Start
        [AllowAnonymous, HttpGet]
        public ActionResult Index()
        {
            GetSlide();

            GetNewExchange();
            GetNewCooperation();
            GetExchane();

            int userId = Com.Cos.Web.PublicInfo.GetLoginUid();
            var member = _memberService.Find(userId);
            if (member != null)
            {
                member.Portrait = Com.Cos.Common.TWEBURL.WEB_URL_IMG + member.Portrait;
            }


            ViewBag.Member = member;

            return View("Index");
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        // GET: Start/Login
        [AllowAnonymous, HttpGet]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                string url = Request.UrlReferrer?.AbsoluteUri;
                if (url?.IndexOf(Url.Action("Login", "Start", new { Area = "" }) ?? "", StringComparison.CurrentCulture) > -1)
                {
                    url = Url.Action("Index", "Start", new { Area = "" });
                }
                return Content(RegisterClientScript.AlertRedirect("您已登录！", url));
            }
            if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))  //如果是登录验证重定向过来的
            {
                ViewBag.IsReturn = 1;
            }
            return View("Login");
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        // GET: Start/Register
        [AllowAnonymous, HttpGet]
        public ActionResult Register()
        {
            return View("Register");
        }

        #region 第三方登录
        /// <summary>
        /// QQ登录
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [AllowAnonymous, HttpGet]
        public ActionResult TencentLogin(string returnUrl)
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("TencentLoginCallback", "Start",
                    new { Area = "", returnUrl = returnUrl })
            };
            HttpContext.GetOwinContext().Authentication.Challenge(properties, "Tencent");
            return new HttpUnauthorizedResult();
        }
        #endregion

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginViewModel">post上来的数据</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel loginViewModel)
        {

            if (TempData["VerificationCode"] == null || TempData["VerificationCode"].ToString() != loginViewModel.VerificationCode?.ToUpper())
            {
                ModelState.AddModelError("VerificationCode", "验证码不正确");
                return View("Login", loginViewModel);
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {

                Member user = _memberService.Find(loginViewModel.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("UserName", "用户名不存在");
                    return View("Login", loginViewModel);
                }
                else if (user.Password == DEncryptUtils.Encrypt3DES(loginViewModel.Password))
                {
                    var identity = _memberService.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignIn(
                        new AuthenticationProperties() { IsPersistent = loginViewModel.RememberMe }, identity);
                    //return RedirectToAction("Index", "Start");
                    //return Json(new Dictionary<string, string>() { { "status", "success" }, { "message", "登录成功" } });
                    ViewBag.Message = "success";
                    return View("Login", loginViewModel);
                }
                else
                {
                    ModelState.AddModelError("Password", "密码错误");
                    return View("Login", loginViewModel);
                }

            }
            ViewBag.Message = "error";
            return View("Login", loginViewModel);
            //return Json(new Dictionary<string, string>() { { "status", "error" }, { "message", "错误请求" } });

        }
        /// <summary>
        /// 注册页注册
        /// </summary>
        /// <param name="registerViewModel">提交过来的数据</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (TempData["VerificationCode"] == null || TempData["VerificationCode"].ToString() != registerViewModel.VerificationCode.ToUpper())
            {
                ModelState.AddModelError("VerificationCode", "验证码不正确");
                return View("Register", registerViewModel);
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                Member member = new Member
                {
                    User_name = "",
                    Portrait = "/Upload/Portrait/1.jpg",
                    Last_login = DateTime.Now,
                    Last_ip = "1.1.1.1",
                    nickname = registerViewModel.NickName,
                    Password = DEncryptUtils.Encrypt3DES(registerViewModel.Password),
                    Status = 1,
                    Reg_time = DateTime.Now
                };
                string str = registerViewModel.Email;
                if (RegexUtil.IsMobilePhone(str)) //是用手机号注册
                {
                    if (TempData["SMSCode"] == null || TempData["SMSCode"].ToString() != registerViewModel.SMSCode.ToUpper())
                    {
                        ModelState.AddModelError("SMSCode", "短信验证码不正确");
                        return View("Register", registerViewModel);
                    }
                    member.Phone_mob = str;
                }
                else //邮箱注册
                {
                    member.Email = str;
                }
                using (TransactionScope ts = new TransactionScope())
                {
                    member = _memberService.Add(member);
                    var lottery = new Lottery()
                    {
                        AcId = 0,
                        AddTime = DateTime.Now,
                        LotteryCode = "0",
                        UserId = member.User_id,
                        Status = 1
                    };
                    _lotteryService.Add(lottery);
                    ts.Complete();
                }

                if (member.User_id > 0)
                {
                    //return Json(new Dictionary<string, string>() { { "status", "success" }, { "message", "注册成功" } });

                    ViewBag.IsShow = 1;
                    return View("Register", registerViewModel);
                }
                else
                {
                    //ModelState.AddModelError("", "注册失败！");
                    //return JavaScript("alert('服务器异常，请稍后再试!');");
                    ViewBag.Message = "error";
                    return View("Register", registerViewModel);
                }
            }
            ViewBag.Message = "error";
            return View("Register", registerViewModel);
        }
        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SignOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //return Redirect(Url.Content("~/"));
            return Json(new Dictionary<string, string>() { { "status", "success" }, { "message", "成功退出" } });
        }

        #region 第三方登录回调
        /// <summary>
        /// QQ登录回调
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<ActionResult> TencentLoginCallback(string returnUrl)
        {
            //获得第三方用户信息
            ExternalLoginInfo loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();

            if (loginInfo == null)  //如果第三方用户信息获取失败
            {
                return RedirectToAction("Login", "Start", new { Area = "" });
            }
            //根据信息查询用户登入表AspNetUserLogins,如果在这个表中找不到数据说明这个用户第一次登入
            var user = await UserManager.FindAsync(loginInfo.Login);
            //那么开始创建新用户
            Member member;
            if (user == null)
            {
                user = new ApplicationUser
                {
                    Email = loginInfo.Email ?? "无",
                    UserName = loginInfo.DefaultUserName ?? GenerateUserName()

                };
                //创建AspNetUsers
                IdentityResult result = await UserManager.CreateAsync(user);

                if (!result.Succeeded)
                {
                    //return View("Error", result.Errors);
                    return null;
                }
                else
                {
                    //创建AspNetUserLogins
                    result = await UserManager.AddLoginAsync(user.Id, loginInfo.Login);
                    if (!result.Succeeded)
                    {
                        //return View("Error", result.Errors);
                        return null;
                    }

                    //保存到数据库
                    string openId = loginInfo.Login.ProviderKey;
                    using (TransactionScope ts = new TransactionScope())
                    {
                        member = new Member
                        {
                            Email = loginInfo.Email,
                            Password = "fW9nWZY/ntY=",
                            Im_qq = openId,
                            Reg_time = DateTime.Now,
                            Logins = 0,
                            Ugrade = 1,
                            Portrait = "/Upload/Portrait/1.jpg",
                            Status = 1,
                            nickname = loginInfo.DefaultUserName ?? GenerateUserName(),
                            User_name = loginInfo.DefaultUserName ?? GenerateUserName()
                        };
                        member = _memberService.Add(member);
                        var lottery = new Lottery()
                        {
                            AcId = 0,
                            AddTime = DateTime.Now,
                            LotteryCode = "0",
                            UserId = member.User_id,
                            Status = 1
                        };
                        _lotteryService.Add(lottery);
                        ts.Complete();
                    }
                       
                }
            }
            else
            {
                member = _memberService.Find(m => m.Im_qq == loginInfo.Login.ProviderKey);
            }
            //如果这个用户已经存在了,从数据库中获得数据进行登入,并把第三方提供的Claim加到这个用户中,实现授权
            var identity = _memberService.CreateIdentity(member, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(
                new AuthenticationProperties() { IsPersistent = false }, identity);
            return Redirect(returnUrl ?? "/");
        }

        #endregion

        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous, AcceptVerbs(HttpVerbs.Get)]
        public ActionResult VerificationCode()
        {
            string verificationCode = RandomHelper.CreateVerificationText(4);
            Bitmap img = ImageHelper.CreateVerificationImage(verificationCode, 65, 30);
            img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            TempData["VerificationCode"] = verificationCode.ToUpper();
            return null;
        }
        /// <summary>
        /// 手机验证码
        /// </summary>
        /// <param name="recNum">接收号码</param>
        /// <returns>{"status":200,"code":123456}</returns>
        [AcceptVerbs(HttpVerbs.Post), AllowAnonymous]
        public ActionResult MobVerificationCode(string recNum)
        {
            Random ran = new Random();
            string code = ran.RandomNumber(6, true);
            string paramString = "{\"code\":\"" + code + "\",\"product\":\"幻幻社区\"}";
            WcfModuleService.IModuleService moduleService = new WcfModuleService.ModuleServiceClient();
            string status = moduleService.SingleSendSms("幻幻平台", "SMS_25255316", recNum, paramString);
            TempData["SMSCode"] = code;
            //return Json(new Dictionary<string, string>() { { "status", status }, { "code", code } });
            return null;
        }

        #region 私有方法

        /// <summary>
        /// 获得首页滚动轮播
        /// </summary>
        private void GetSlide()
        {
            var slides = _slideService.Find(1);  //首页滚动轮播
            ViewBag.Slides = slides;
        }
        /// <summary>
        /// 获取最新发布的5条兑换
        /// </summary>
        private void GetNewExchange()
        {
            var exchangeList = _exchangeService.FindList(5).AsEnumerable().Select(g => new ExchangeViewModel()
            {
                Official = g.Official,
                Portrait = g.Portrait,
                Cover = g.Cover,
                Id = g.Id,
                ImgList = g.ImgList,
                Examine = g.Examine==null? "审核中" : ((ExchangeExamine)_exchangeExamineService.Find(((string)g.Examine).ToInt32())).ExamineName,
                Nickname = g.Nickname,
                Title = g.Title
            }).ToList();
            for (int i = 0; i < exchangeList.Count; i++)
            {
                var ex = exchangeList[i];
                string coverId = ex.Cover;
                if (string.IsNullOrEmpty(coverId))  //如果没有封面，则取第一张图片
                {
                    string imgList = ex.ImgList;
                    string[] imgs = imgList.Split(',');
                    coverId = imgs[0];
                }
                string cover = TWEBURL.WEB_URL_IMG + _imgService.Find(coverId.ToInt32())?.ImgSmallUrl;
                exchangeList[i].Cover = cover;
            }
            ViewBag.Exchanges = exchangeList;
        }
        /// <summary>
        /// 获取最新6条合作
        /// </summary>
        private void GetNewCooperation()
        {
            var cooperationList = _cooperationService.FindList(6).AsEnumerable().Select(g => new CooperationViewModel()
            {
                Portrait = g.Portrait,
                Cover = g.Cover,
                Id = g.Id,
                ImgList = g.ImgList,
                Nickname = g.Nickname,
                Title = g.Title,
                Address = g.Address,
                Budget = g.Budget,
                Cont = g.Cont,
                EnrollEnd = g.EnrollEnd,
                ReleaseTime = g.ReleaseTime,
                Will = g.Will
            }).ToList();
            for (int i = 0; i < cooperationList.Count; i++)
            {
                var coo = cooperationList[i];
                string coverId = coo.Cover;
                if (string.IsNullOrEmpty(coverId))  //如果没有封面，则取第一张图片
                {
                    string imgList = coo.ImgList;
                    string[] imgs = imgList.Split(',');
                    coverId = imgs[0];
                }
                string cover = TWEBURL.WEB_URL_IMG + _imgService.Find(coverId.ToInt32())?.ImgSmallUrl;
                cooperationList[i].Cover = cover;
            }
            ViewBag.Coos = cooperationList;
        }
        /// <summary>
        /// 获取兑换区4条兑换
        /// </summary>
        private void GetExchane()
        {
            var exchangeList = _exchangeService.FindRanList(4).AsEnumerable().Select(g => new ExchangeViewModel()
            {
                Official = g.Official,
                Portrait = g.Portrait,
                Cover = g.Cover,
                Id = g.Id,
                ImgList = g.ImgList,
                Examine = g.Examine == null ? "审核中" : ((ExchangeExamine)_exchangeExamineService.Find(((string)g.Examine).ToInt32())).ExamineName,
                Nickname = g.Nickname,
                Title = g.Title
            }).ToList();
            for (int i = 0; i < exchangeList.Count; i++)
            {
                var ex = exchangeList[i];
                string coverId = ex.Cover;
                if (string.IsNullOrEmpty(coverId))  //如果没有封面，则取第一张图片
                {
                    string imgList = ex.ImgList;
                    string[] imgs = imgList.Split(',');
                    coverId = imgs[0];
                }
                string cover = TWEBURL.WEB_URL_IMG + _imgService.Find(coverId.ToInt32())?.ImgSmallUrl;
                exchangeList[i].Cover = cover;
            }

            ViewBag.Exchanges2 = exchangeList;
        }
        /// <summary>
        /// 生成用户名
        /// </summary>
        /// <returns></returns>
        private string GenerateUserName()
        {
            long date = Com.Cos.Common.DateTimeHelper.ConvertDateTimeInt(DateTime.Now);
            return "幻幻" + date;
        }
        #endregion


    }


}