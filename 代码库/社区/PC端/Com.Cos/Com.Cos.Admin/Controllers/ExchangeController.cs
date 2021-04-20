using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Com.Cos.Admin.Models;
using Com.Cos.Admin.Models.ExchangeViewModels;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Com.Cos.Admin.Controllers
{
    [Authorize]
    public class ExchangeController : Controller
    {
        private readonly IExchangeService _exchangeService;
        private readonly ILogisticService _logisticService;
        private readonly IExchangeClassService _exchangeClassService;
        private readonly IExchangeExamineService _exchangeExamineService;

        public ExchangeController(IExchangeService exchangeService, ILogisticService logisticService, IExchangeClassService exchangeClassService, IExchangeExamineService exchangeExamineService)
        {
            this._exchangeService = exchangeService;
            this._logisticService = logisticService;
            this._exchangeClassService = exchangeClassService;
            this._exchangeExamineService = exchangeExamineService;
        }

        // GET: Exchange
        [AllowAnonymous]
        public ActionResult Index()
        {
            var dtoList = _exchangeService.FindList();
            List<ExchageListViewModel> modelList = new List<ExchageListViewModel>();
            dtoList.ForEach(p =>
            {
                modelList.Add(ConvertHelper.ChangeType<ExchageListViewModel>(p));
            });

            ViewData["TotalCount"] = modelList.Count;
            ViewData["Exchages"] = modelList;
            return View();
        }

        //// GET: Exchange/Logistic
        //public IActionResult Logistic(string logisticCode)
        //{
        //    var dto = _logisticService.FindList(logisticCode);
        //    List<LogisticViewModel> modelList = new List<LogisticViewModel>();
        //    dto.ForEach(l => modelList.Add(ConvertHelper.ChangeType<LogisticViewModel>(l)));
        //    ViewBag.Logistic = logisticCode;
        //    ViewBag.LogisticList = modelList;
        //    return View();
        //}

        //// GET: Exchange/Details/5
        //public ActionResult Details(int id)
        //{

        //    //var dto = _exchangeService.Find(id, 0);
        //    //var model = new ExchangeDetailViewModel()
        //    //{
        //    //    AddTime = dto.AddTime.ToString("yyyy-MM-dd HH:mm:ss"),
        //    //    Constitute = dto.Constitute,
        //    //    Describe = dto.Describe,
        //    //    Id = dto.Id,
        //    //    Official = dto.Official,
        //    //    Price = dto.Price,
        //    //    Source = dto.Source,
        //    //    Title = dto.Title,
        //    //    Cover = dto.Cover,
        //    //    ImgList = dto.ImgDtoList.Select(img => "http://img.52cos.cn" + img.ImgPath).ToList()
        //    //};
        //    //ViewBag.ClassList = new SelectList(_exchangeClassService.FindList(), "Id", "ClassName", dto.ClassId);
        //    //ViewBag.ExamineList = new SelectList(_exchangeExamineService.FindList(), "Id", "ExamineName", dto.ExamineId);

        //    return View(model);
        //}

        //// GET: Exchange/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    var dto = _exchangeService.Find(id, 0);
        //    var model = new ExchangeDetailViewModel()
        //    {
        //        AddTime = dto.AddTime.ToString("yyyy-MM-dd HH:mm:ss"),
        //        Constitute = dto.Constitute,
        //        Describe = dto.Describe,
        //        Id = dto.Id,
        //        Official = dto.Official,
        //        Price = dto.Price,
        //        Source = dto.Source,
        //        Title = dto.Title,
        //        Cover = dto.Cover,
        //        ImgList = dto.ImgDtoList.Select(img => "http://img.52cos.cn" + img.ImgPath).ToList()
        //    };
        //    ViewBag.ClassList = new SelectList(_exchangeClassService.FindList(), "Id", "ClassName", dto.ClassId);
        //    ViewBag.ExamineList = new SelectList(_exchangeExamineService.FindList(), "Id", "ExamineName", dto.ExamineId);

        //    return View(model);
        //}
        //// POST: Exchange/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, ExchangeDetailViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dto = ConvertHelper.ChangeType<ExchangeDto>(model);

        //        MessageBase result = new MessageBase()
        //        {
        //            Status = _exchangeService.Update2(id, dto).ToString().ToLower()
        //        };

        //        return Json(result);
        //    }
        //    return View();
        //}






        ///// <summary>
        ///// 修改兑换状态
        ///// </summary>
        ///// <param name="id">兑换id</param>
        ///// <param name="examine">兑换状态</param>
        ///// <param name="official">最终值</param>
        ///// <returns></returns>
        //// POST: /Exchange/UpdateExamine
        //[HttpPost, ActionName("UpdateExamine")]
        //public ActionResult UpdateExamine(int id, string examine, string official)
        //{
        //    bool b = _exchangeService.UpdateExamine(id, examine, official);

        //    var msg = new MessageBase()
        //    {
        //        Status = b.ToString().ToLower()
        //    };
        //    return Json(msg);
        //}
        ///// <summary>
        ///// 删除
        ///// </summary>
        ///// <param name="id">兑换id</param>
        ///// <returns></returns>
        //// POST: Exchange/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    MessageBase msg = new MessageBase();
        //    this._exchangeService.Delete2(id);
        //    msg.Status = "true";
        //    return Json(msg);
        //}
        ///// <summary>
        ///// 推荐
        ///// </summary>
        ///// <param name="id">兑换id</param>
        ///// <param name="status"></param>
        ///// <returns></returns>
        //// POST: /Exchange/Recommend
        //[HttpPost, ActionName("Recommend")]
        //public ActionResult Recommend(int id, int status)
        //{
        //    MessageBase result = new MessageBase();
        //    this._exchangeService.Recommend(id, status);

        //    return Json(result);
        //}

        //// GET: Exchange/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Exchange/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Exchange/ExchangeDataJson
        [HttpGet,ActionName("ExchangeDataJson")]
        [AllowAnonymous]
        public async Task<ActionResult> ExchangeDataJson(int page, int limit)
        {
            var v = await _exchangeService.FindListAsync(page, limit);

            var r = new
            {
                Code = 0,
                Msg = "",
                Count = v.pageDto.TotalRecord,
                Data = v.dto
            };
            return new JsonResult(r);
        }

    }
}