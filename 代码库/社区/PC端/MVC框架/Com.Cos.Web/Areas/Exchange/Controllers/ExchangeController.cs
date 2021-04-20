using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Cos.BLL;
using Com.Cos.Common;
using Com.Cos.IBLL;
using Com.Cos.Web.Areas.Cooperation.Models;
using Com.Cos.Web.Areas.Exchange.Models;

namespace Com.Cos.Web.Areas.Exchange.Controllers
{
    /// <summary>
    /// 兑换/分享
    /// </summary>
    public class ExchangeController : Controller
    {
        private readonly Com.Cos.IBLL.IExchangeService _exchangeService;
        private readonly Com.Cos.IBLL.IMemberService _memberService;
        private readonly Com.Cos.IBLL.IExchangeClassService _exchangeClassService;
        private readonly Com.Cos.IBLL.IExchangeExamineService _exchangeExamineService;
        private readonly Com.Cos.IBLL.IImgService _imgService;
        private readonly Com.Cos.IBLL.IMailingAddressService _mailingAddressService;

        private readonly int _userId;//登录的用户id
        private readonly Com.Cos.Models.Member _member;  //登录的用户

        public ExchangeController()
        {
            _exchangeService = new ExchangeService();
            _memberService = new MemberService();
            _exchangeClassService = new ExchangeClassService();
            _exchangeExamineService = new ExchangeExamineService();
            _imgService = new ImgService();
            _mailingAddressService = new MailingAddressService();

            _userId = Com.Cos.Common.Public.GetLoginUid();  //登录的用户id
            _member = _memberService.Find(_userId);  //登录的用户

            ViewBag.Classes = _exchangeClassService.FindList();  //全部兑换分类
            ViewBag.Examines = _exchangeExamineService.FindList();  //全部兑换状态

        }

        /// <summary>
        /// 列表页
        /// </summary>
        /// <param name="examineUsName">兑换状态英文名</param>
        /// <param name="classUsName">分类英文</param>
        /// <param name="p">当前页</param>
        /// <returns></returns>
        // GET: Exc/ExcList/ee/class?p=1
        [AllowAnonymous, AcceptVerbs(HttpVerbs.Get)]
        [ActionName("ExcList")]
        public ActionResult Index(string examineUsName, string classUsName, string p)
        {
            int page = p.ToInt32();  //当前页
            string examineId = _exchangeExamineService.Find(examineUsName)?.ExamineId;  //兑换状态id
            string classId = _exchangeClassService.Find(classUsName)?.ClassId.ToString();  //兑换状态id

            page = page < 1 ? 1 : page;
            var exchanges = GetExchange(page, examineId, classId);
            ViewBag.Exchanges = exchanges;
            ViewBag.ExamineUsName = examineUsName;
            ViewBag.ClassUsName = classUsName;
            return View("Index");
        }
        /// <summary>
        /// 详情页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Exc/Detail/1
        [Authorize, AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Detail(int id)
        {
            var exchange = _exchangeService.Find(id);
            exchange.Certificate = TWEBURL.WEB_URL_IMG + _imgService.Find(exchange.Certificate.ToInt32())?.ImgBigUrl;
            string[] imgs = exchange.ImgList.Split(',');
            exchange.ImgList = "";
            foreach (string img in imgs)
            {
                exchange.ImgList += TWEBURL.WEB_URL_IMG + _imgService.Find(img.ToInt32())?.ImgBigUrl + ",";
            }
            exchange.ImgList = exchange.ImgList.TrimEnd(',');
            exchange.Examine = exchange.Examine == null ? "0" : exchange.Examine == "0" ? "0" : exchange.Examine;
            exchange.ClassId = _exchangeClassService.Find(exchange.ClassId.ToInt32()).ClassName;

            ViewBag.Exchange = exchange;
            var member = _memberService.Find(exchange.UserId.ToInt32());  //发布该兑换信息的用户
            member.Portrait = TWEBURL.WEB_URL_IMG + member.Portrait;
            ViewBag.Member = member;
            return View("Detail");
        }
        /// <summary>
        /// 发布页
        /// </summary>
        /// <returns></returns>
        // GET: Exc/Publish
        [Authorize, AcceptVerbs(HttpVerbs.Get)]
        [ActionName("Publish")]
        public ActionResult Create()
        {
            return View("Create");
        }
        /// <summary>
        /// 发布事件
        /// </summary>
        /// <param name="exchangeViewModel"></param>
        /// <returns></returns>
        // POST: Exc/Publish
        [ValidateAntiForgeryToken, Authorize]
        [HttpPost, ActionName("Publish")]
        public ActionResult Create(ExchangeViewModel exchangeViewModel)
        {
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                int userId = Com.Cos.Common.Public.GetLoginUid();

                Com.Cos.Models.Exchange exchange = new Cos.Models.Exchange
                {
                    UserId = userId.ToString(),
                    Title = exchangeViewModel.Title,
                    ItemName = exchangeViewModel.ItemName,
                    ItemCharacter = exchangeViewModel.ItemCharacter,
                    Constitute = exchangeViewModel.Constitute,
                    Source = exchangeViewModel.Source,
                    Price = exchangeViewModel.Price,
                    ClassId = exchangeViewModel.ClassId,
                    Describe = exchangeViewModel.Describe,
                    //Valuation1 = exchangeViewModel.Valuation1,
                    //Valuation2 = exchangeViewModel.Valuation2,
                    //Valuation3 = exchangeViewModel.Valuation3,
                    //Certificate = exchangeViewModel.Certificate,
                    ImgList = exchangeViewModel.ImgList,
                    Cover = exchangeViewModel.Cover,
                    AddTime = DateTime.Now,
                    Status = 1

                };
                exchange = _exchangeService.Add(exchange);
                if (exchange.Id > 0)
                {
                    return Json(Public.MessageJson(1, "发布成功"));
                }
                return Json(Public.MessageJson(0, "修改失败"));
            }
            return PartialView("_PartialCreate", exchangeViewModel);
        }
        /// <summary>
        /// 确认订单
        /// </summary>
        /// <param name="id">兑换id</param>
        /// <param name="type">订单类型，0为兑换，1为租借</param>
        /// <returns></returns>
        // GET: Exc/ConfirmOrder/1
        [Authorize, AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ConfirmOrder(int id, int type)
        {
            var exchange = _exchangeService.Find(id);
            ViewBag.Member = _member;
            ViewBag.Id = id.ToString();
            ViewBag.Type = type.ToString();
            ViewBag.Exchange = exchange;
            GetAddress();
            GetVip();
            return View("ConfirmOrder");
        }

        /// <summary>
        /// 兑换事件
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: Exc/Detail
        [Authorize, HttpPost]
        public ActionResult Detail(FormCollection collection)
        {

            int eid = collection.Get("Eid").ToInt32();  //该兑换id
            var exchange = _exchangeService.Find(eid);
            if (exchange.Examine != "3")
            {
                return Json(Com.Cos.Common.Public.MessageJson(0, "该兑换不在兑换状态!"));
            }

            return Json(Com.Cos.Common.Public.MessageJson(1, ""));
        }
        /// <summary>
        /// 确认订单
        /// </summary>
        /// <returns></returns>
        // POST: Exc/ConfirmOrder
        [ValidateAntiForgeryToken]
        [Authorize, AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ConfirmOrder(ConfirmOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                string subjet = "";
                if (model.Type == 0)  //兑换
                {
                    subjet = "兑换订单";
                }
                if (model.Type == 1)  //租借
                {
                    subjet = "租借订单";
                }
                string submit = Com.Cos.Common.AlipayHelper.BuildRequest(_userId.ToString(), model.Money, subjet, model.Id.ToString(),model.Address,model.Deposit,model.Method);
                return Content(submit, "text/html");
            }
            return View("ConfirmOrder", model);
        }
        #region 私有方法

        /// <summary>
        /// 获得列表页数据
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="examineId">兑换状态id</param>
        /// <param name="classId">兑换分类id</param>
        /// <returns></returns>
        private List<ExchangeViewModel> GetExchange(int page, string examineId, string classId)
        {
            int totalRecord;
            var excs = _exchangeService.FindPageList(page, 8, examineId, classId, out totalRecord);
            ViewBag.PageIndex = page;
            ViewBag.PageSize = 6;
            ViewBag.TotalRecord = totalRecord;
            List<ExchangeViewModel> exchangeList = new List<ExchangeViewModel>();
            foreach (var exc in excs)
            {
                Type type = exc.GetType();
                string coverId = type.GetProperty("Cover").GetValue(exc, null);
                if (string.IsNullOrEmpty(coverId))  //如果没有封面，则取第一张图片
                {
                    string imgList = type.GetProperty("ImgList").GetValue(exc, null);
                    string[] imgs = imgList.Split(',');
                    coverId = imgs[0];
                }
                string cover = _imgService.Find(coverId.ToInt32())?.ImgSmallUrl;

                exchangeList.Add(new ExchangeViewModel
                {
                    Id = type.GetProperty("Id").GetValue(exc, null),
                    Cover = TWEBURL.WEB_URL_IMG + cover,
                    Nickname = type.GetProperty("Nickname").GetValue(exc, null),
                    Portrait = TWEBURL.WEB_URL_IMG + type.GetProperty("Portrait").GetValue(exc, null),
                    Title = type.GetProperty("Title").GetValue(exc, null),
                    ItemName = type.GetProperty("ItemName").GetValue(exc, null),
                    ItemCharacter = type.GetProperty("ItemCharacter").GetValue(exc, null),
                    Constitute = type.GetProperty("Constitute").GetValue(exc, null),
                    Source = type.GetProperty("Source").GetValue(exc, null),
                    Price = type.GetProperty("Price").GetValue(exc, null),
                    ClassId = type.GetProperty("ClassId").GetValue(exc, null),
                    Describe = type.GetProperty("Describe").GetValue(exc, null),
                    //Valuation1 = type.GetProperty("Valuation1").GetValue(exc, null),
                    //Valuation2 = type.GetProperty("Valuation2").GetValue(exc, null),
                    //Valuation3 = type.GetProperty("Valuation3").GetValue(exc, null),
                    //Certificate = type.GetProperty("Certificate").GetValue(exc, null),
                    ImgList = type.GetProperty("ImgList").GetValue(exc, null),
                    AddTime = type.GetProperty("AddTime").GetValue(exc, null)
                });
            }
            return exchangeList;
        }
        /// <summary>
        /// 获得登录用户的通讯地址列表
        /// </summary>
        private void GetAddress()
        {

            var adds = _mailingAddressService.FindList(_userId).ToList();
            ViewBag.Addresses = adds;
        }

        private void GetVip()
        {
            if (_member.Etime >= DateTime.Now && _member.RemainingConversions > 0)
            {
                ViewBag.Vip = true;
            }
            else
            {
                ViewBag.Vip = false;
            }
            ViewBag.User = _member;
        }
        #endregion
    }
}