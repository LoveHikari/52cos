using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Com.Cos.BLL;
using Com.Cos.Common;
using Com.Cos.IBLL;
using Com.Cos.Models;
using Com.Cos.Web.Areas.Cooperation.Models;

namespace Com.Cos.Web.Areas.Cooperation.Controllers
{
    /// <summary>
    /// 合作
    /// </summary>
    public class CooperationController : Controller
    {
        private ICooperationService _cooperationService;
        private IMemberService _memberService;
        private IImgService _imgService;

        public CooperationController()
        {
            _cooperationService = new CooperationService();
            _memberService = new MemberService();
            _imgService = new ImgService();
        }
        /// <summary>
        /// 列表页
        /// </summary>
        /// <param name="page">当前页</param>
        /// <returns></returns>
        // GET: Coo/CooList?p=1
        [AllowAnonymous]
        [ActionName("CooList")]
        public ActionResult Index(string p)
        {
            int page = p.ToInt32();
            page = page < 1 ? 1 : page;
            var cooperations = GetCooperation(page);
            ViewBag.Cooperations = cooperations;
            return View("Index");
        }
        /// <summary>
        /// 详情页
        /// </summary>
        /// <param name="id">合作id</param>
        /// <returns></returns>
        // GET: Coo/Detail/11
        public ActionResult Detail(int id)
        {
            var coo = _cooperationService.Find(id);
            coo.Cover = _imgService.Find(coo.Cover.ToInt32())?.ImgSmallUrl;
            string[] imgList = coo.ImgList.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < imgList.Length; i++)
            {
                imgList[i] = TWEBURL.WEB_URL_IMG + _imgService.Find(imgList[i].ToInt32())?.ImgBigUrl;
            }
            ViewBag.ImgList = imgList;
            ViewBag.Cooperation = coo;
            var user = _memberService.Find(coo.UserId.ToInt32());
            user.Portrait = TWEBURL.WEB_URL_IMG + user.Portrait;
            ViewBag.Member = user;
            return View("Detail");
        }

        /// <summary>
        /// 发布页
        /// </summary>
        /// <returns></returns>
        // GET: Coo/Publish
        [ActionName("Publish")]
        public ActionResult Create()
        {
            return View("Create");
        }
        /// <summary>
        /// 发布事件
        /// </summary>
        /// <param name="cooperationViewModel"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Publish")]
        public ActionResult Create(CooperationViewModel cooperationViewModel)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                int userId = Com.Cos.Common.Public.GetLoginUid();

                Com.Cos.Models.Cooperation cooperation = new Com.Cos.Models.Cooperation
                {
                    UserId = userId.ToString(),
                    Title = cooperationViewModel.Title,
                    EnrollEnd = cooperationViewModel.EnrollEnd,
                    Address = cooperationViewModel.Address,
                    Cont = cooperationViewModel.Cont,
                    RMBBudget = cooperationViewModel.Budget,
                    ImgList = cooperationViewModel.ImgList,
                    Cover = cooperationViewModel.Cover,
                    Will = cooperationViewModel.Will,
                    ReleaseTime = DateTime.Now,
                    Status = 1

                };
                cooperation = _cooperationService.Add(cooperation);
                if (cooperation.Id > 0)
                {
                    return Json(new Dictionary<string, string>() { { "status", "success" }, { "message", "发布成功" } });
                }
                return Json(new Dictionary<string, string>() { { "status", "error" }, { "message", "发布失败" } });
            }
            string error = errors.ToArray()[0].ErrorMessage;
            return Json(new Dictionary<string, string>() { { "status", "error" }, { "message", $"{error}" } });

        }

        #region 私有方法
        /// <summary>
        /// 获得列表页数据
        /// </summary>
        /// <param name="page">当前页</param>
        /// <returns></returns>
        private List<CooperationViewModel> GetCooperation(int page)
        {
            int totalRecord;
            var coos = _cooperationService.FindPageList(page, 6, out totalRecord);
            ViewBag.PageIndex = page;
            ViewBag.PageSize = 6;
            ViewBag.TotalRecord = totalRecord;
            List<CooperationViewModel> cooperationList = new List<CooperationViewModel>();
            foreach (var coo in coos)
            {
                Type type = coo.GetType();
                string coverId = type.GetProperty("Cover").GetValue(coo, null);
                if (string.IsNullOrEmpty(coverId))  //如果没有封面，则取第一张图片
                {
                    string imgList = type.GetProperty("ImgList").GetValue(coo, null);
                    string[] imgs = imgList.Split(',');
                    coverId = imgs[0];
                }
                string cover = _imgService.Find(coverId.ToInt32())?.ImgSmallUrl;

                cooperationList.Add(new CooperationViewModel
                {
                    Id = type.GetProperty("Id").GetValue(coo, null),
                    Cover = cover,
                    Cont = type.GetProperty("Cont").GetValue(coo, null),
                    Nickname = type.GetProperty("Nickname").GetValue(coo, null),
                    Portrait = type.GetProperty("Portrait").GetValue(coo, null),
                    ReleaseTime = type.GetProperty("ReleaseTime").GetValue(coo, null),
                    Title = type.GetProperty("Title").GetValue(coo, null),
                    Will = type.GetProperty("Will").GetValue(coo, null) == "0" ? "求" : "需"
                });
            }
            return cooperationList;
        }

        #endregion
    }
}