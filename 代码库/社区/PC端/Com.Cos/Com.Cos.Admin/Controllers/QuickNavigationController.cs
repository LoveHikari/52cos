using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Admin.Models;
using Com.Cos.Admin.Models.QuickNavigationViewModels;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Com.Cos.Admin.Controllers
{
    [Authorize]
    public class QuickNavigationController : Controller
    {
        private readonly IQuickNavigationService _quickNavigationService;
        public QuickNavigationController(IQuickNavigationService quickNavigationService)
        {
            _quickNavigationService = quickNavigationService;
        }
        // GET: QuickNavigation
        public IActionResult Index()
        {
            var dtoList = _quickNavigationService.FindList();
            List<QuickNavigationListViewModel> modelList = new List<QuickNavigationListViewModel>();
            dtoList.ForEach(q => modelList.Add(new QuickNavigationListViewModel()
            {
                Id = q.Id,
                Title = q.Title,
                AddTime = q.AddTime.ToString("yyyy-MM-dd HH:mm:ss")
            }));

            ViewBag.QnList = modelList;
            return View();
        }

        //// GET: QuickNavigation/Edit/5
        //public IActionResult Edit(int id)
        //{
        //    var dto = _quickNavigationService.Find(id);
        //    QuickNavigationViewModel model = ConvertHelper.ChangeType<QuickNavigationViewModel>(dto);
        //    return View(model);
        //}

        //// POST: QuickNavigation/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(QuickNavigationViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dto = ConvertHelper.ChangeType<QuickNavigationDto>(model);

        //        MessageBase result = new MessageBase()
        //        {
        //            Status = _quickNavigationService.Update(dto).ToString().ToLower()
        //        };

        //        return Json(result);
        //    }
            
        //    return View();

        //}
    }
}