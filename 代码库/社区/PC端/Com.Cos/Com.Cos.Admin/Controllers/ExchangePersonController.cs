using Com.Cos.Admin.Models.ExchangePersonViewModels;
using Com.Cos.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Com.Cos.Admin.Models;

namespace Com.Cos.Admin.Controllers
{
    [Authorize]
    public class ExchangePersonController : Controller
    {
        private readonly IExchangePersonService _exchangePersonService;
        public ExchangePersonController(IExchangePersonService exchangePersonService)
        {
            _exchangePersonService = exchangePersonService;
        }
        public IActionResult Index()
        {
            var dto = _exchangePersonService.FindList();
            List<ExchangePersonViewModel> modelList = new List<ExchangePersonViewModel>();
            dto.ForEach(e=>modelList.Add(ConvertHelper.ChangeType<ExchangePersonViewModel>(e)));
            ViewBag.EpList = modelList;

            return View();
        }


        /// <summary>
        /// 提交物流单号
        /// </summary>
        /// <param name="epId"></param>
        /// <param name="logistic">物流单号</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateLogistic(int epId,string logistic)
        {
            bool b =_exchangePersonService.UpdateLogistic(epId, logistic);

            var msg = new MessageBase()
            {
                Status = b.ToString().ToLower()
            };
            return Json(msg);
        }
    }
}