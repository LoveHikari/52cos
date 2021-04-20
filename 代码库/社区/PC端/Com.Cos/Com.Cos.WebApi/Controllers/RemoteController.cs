using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Com.Cos.WebApi.Controllers
{
    /// <summary>
    /// 验证控制器，返回为false时触发提示
    /// </summary>
    [Produces("application/json")]
    [Route("api/Remote")]
    public class RemoteController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly ILoginCodeService _loginCodeService;
        private readonly IVoucherService _voucherService;
        public RemoteController(CosDbContext dbContext)
        {
            _memberService = new MemberService(dbContext);
            _loginCodeService = new LoginCodeService(dbContext);
            _voucherService = new VoucherService(dbContext);
        }

        /// <summary>
        /// 检查用户是否已经存在
        /// </summary>
        /// <param name="type"></param>
        /// <param name="userName"></param>
        /// <returns>不存在为true</returns>
        private async Task<object> CheckExist(string userName, string type)
        {
            bool b = await _memberService.ExistAsync(type, userName) == 0;
            return new JsonResult(b);
        }
        /// <summary>
        /// 验证验证码是否过期
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="code">短信验证码</param>
        /// <returns>无效为false</returns>
        private async Task<object> VerifyCode(string code, string phone)
        {
            bool b = await _loginCodeService.FindAsync(phone, code);
            return new JsonResult(b);
        }
        /// <summary>
        /// 检查支付宝账号是否已经存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>不存在为true</returns>
        private async Task<object> CheckAlipay(string userName)
        {
            bool b = await _memberService.ExistAsync("alipay", userName) == 0;
            return new JsonResult(b);
        }
        /// <summary>
        /// 检查是否是会员且是否有兑换次数
        /// </summary>
        /// <returns></returns>
        private async Task<object> IsVip(int userId, string examine)
        {
            if (examine == "会员租赁")
            {
                var dto = await _memberService.FindAsync(userId);
                if (dto.IsVip && dto.Surplus > 0)
                {
                    return new JsonResult(true);
                }
                else
                {
                    return new JsonResult(false);
                }
            }

            return new JsonResult(true);
        }

        /// <summary>
        /// 兑换码是否存在
        /// </summary>
        /// <param name="code">兑换码</param>
        /// <returns></returns>
        private async Task<object> CheckVoucher(string code)
        {
            bool b = await _voucherService.ExistAsync(code);
            return Json(b);
        }

        /// <summary>
        /// 兑换码是否存在
        /// </summary>
        /// <param name="voucherId">兑换码id</param>
        /// <param name="userId">用户id</param>
        /// <param name="examine">兑换方式</param>
        /// <returns></returns>
        private async Task<object> CheckVoucher(int voucherId, int userId, string examine)
        {
            if (examine == "兑换券")
            {
                bool b = await _voucherService.ExistAsync(voucherId, userId);
                return Json(b);
            }
            return Json(true);
        }
    }
}