using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Com.Cos.Admin.Models;
using Com.Cos.Admin.Models.HomeViewModels;
using Com.Cos.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Com.Cos.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly ILoginIPService _loginIpService;
        public HomeController(IMemberService memberService,ILoginIPService loginIpService)
        {
            _memberService = memberService;
            _loginIpService = loginIpService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "0")]
        public IActionResult Welcome()
        {
            DateTime nowTime = DateTime.Now;
            HomeViewModel model = new HomeViewModel()
            {
                MemberCount = _memberService.GetUserCount(),
                TodayMemberCount = _memberService.GetUserCount(nowTime),
                YesterdayMemberCount = _memberService.GetUserCount(nowTime.AddDays(-1)),
                VipCount = _memberService.GetUserVipCount(),
                TodayVipCount = _memberService.GetUserVipCount(nowTime),
                YesterdayVipCount = _memberService.GetUserVipCount(nowTime.AddDays(-1)),
                LoginCount = _loginIpService.GetCount(),
                TodayLoginCount = _loginIpService.GetCount(nowTime),
                YesterdayLoginCount = _loginIpService.GetCount(nowTime.AddDays(-1))
            };
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult Download()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
