using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Cos.BLL;

namespace Com.Cos.Web.Areas.Activity.Controllers
{
    /// <summary>
    /// 活动控制器
    /// </summary>
    public class ActivityController : Controller
    {
        private readonly Com.Cos.IBLL.IMemberService _memberService;
        private readonly Com.Cos.IBLL.ILotteryService _lotteryService;

        private readonly Com.Cos.Models.Member _member;  //登录用户
        private readonly int _userId;
        public ActivityController()
        {
            _memberService = new Com.Cos.BLL.MemberService();
            _lotteryService = new LotteryService();

            _userId = Com.Cos.Common.Public.GetLoginUid();
            _member = _memberService.Find(_userId);
        }
        /// <summary>
        /// 抽奖页面
        /// </summary>
        /// <returns></returns>
        // GET: Activity/Lottery
        [Authorize]
        public ActionResult Lottery()
        {
            //获得抽奖次数
            var count = _lotteryService.Count(l => l.UserId == _userId && l.Status > 0 && string.IsNullOrEmpty(l.PrizeName));


            ViewBag.Count = count;

            return View("Lottery");
        }
        [Authorize]
        public ActionResult LotteryRecord()
        {
            var lotterys = _lotteryService.FindList(l => l.UserId == _userId && l.Status > 0 && !string.IsNullOrEmpty(l.PrizeName));

            ViewBag.Lotterys = lotterys;
            return View("LotteryRecord");
        }
        [Authorize]
        public ActionResult AddLottery(FormCollection collection)
        {
            string prize = collection.Get("Prize");
            var lottery = _lotteryService.Find(l => l.UserId == _userId && l.Status > 0 && string.IsNullOrEmpty(l.PrizeName));
            lottery.GetTime = DateTime.Now;
            lottery.PrizeId = 0;
            lottery.PrizeName = prize;
            _lotteryService.Update(lottery);
            return null;
        }
    }
}