using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Com.Cos.Admin.Models;
using Com.Cos.Admin.Models.AccountViewModels;
using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Com.Cos.Admin.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private IAdminMemberService _adminMemberService;

        public AccountController(IAdminMemberService adminMemberService)
        {
            _adminMemberService = adminMemberService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm]LoginViewModel model, string returnUrl = null)
        {
            MessageBase result = new MessageBase();
            //ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                AdminMemberDto dto = _adminMemberService.Find(model.UserName, model.Password);
                if (dto.Id > 0)
                {
                    var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()),
                        new Claim(ClaimTypes.Name, dto.UserName),
                        new Claim("Nickname", dto.Nickname),
                        new Claim(ClaimTypes.Role, dto.Authority.ToString())
                    }, CookieAuthenticationDefaults.AuthenticationScheme));
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user, new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.Now.Add(TimeSpan.FromDays(180))
                    });
                    return Json(result);
                }
                else
                {
                    result.Status = "false";
                    return Json(result);
                }

            }
            return View();
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AccessDenied(string returnUrl = null)
        {
            return View();
        }
    }
}