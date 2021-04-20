using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Admin.Models.MemberViewModels;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Com.Cos.Admin.Controllers
{
    public class MemberController : Controller
    {
        private readonly IBackMemberService _backMemberService;
        public MemberController(IBackMemberService backMemberService)
        {
            this._backMemberService = backMemberService;
        }
        public IActionResult Index()
        {
            var dtoList = _backMemberService.FindList();
            var modelList = new List<MemberListViewModel>();
            foreach (MemberDto dto in dtoList)
            {
                modelList.Add(new MemberListViewModel()
                {
                    Id = dto.Id,
                    Nickname = dto.Nickname,
                    Gender = dto.Gender,
                    PhoneMob = dto.PhoneMob,
                    IsVip = dto.IsVip,
                    AddTime = dto.AddTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Address = dto.Address
                });
            }
            ViewBag.MemberList = modelList;
            return View();
        }

        public IActionResult Refund()
        {

            return View();
        }
    }
}