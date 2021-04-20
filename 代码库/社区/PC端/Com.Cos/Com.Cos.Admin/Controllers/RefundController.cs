using Com.Cos.Admin.Models;
using Com.Cos.Admin.Models.RefundViewModels;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure.Ali;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using Com.Cos.Infrastructure;

namespace Com.Cos.Admin.Controllers
{
    /// <summary>
    /// 退还押金控制器
    /// </summary>
    public class RefundController : Controller
    {
        private readonly IRefundService _refundService;

        public RefundController(IRefundService refundService)
        {
            _refundService = refundService;
        }
        public IActionResult Index()
        {
            var dtoList = _refundService.FindList();
            List<RefundViewModel> modelList = new List<RefundViewModel>();

            dtoList.ForEach(r =>
            {
                modelList.Add(new RefundViewModel()
                {
                    AddTime = r.AddTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Status = r.Status,
                    Id = r.Id,
                    UserId = r.UserId,
                    Nickname = r.Nickname,
                    Account = r.Account,
                    Deposit = r.Deposit,
                    Money = r.Money,
                    AccountType = r.AccountType == "alipay" ? "支付宝" : r.AccountType,
                    Type = r.Type
                });
            });
            ViewBag.RefundList = modelList;
            return View();
        }

        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="id">退款id</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Refund(int id)
        {
            MessageBase result = new MessageBase();
            var dto = _refundService.Find(id);
            string s = AliPaySdk.FundTrans(dto.Account, dto.RealName, dto.Money.ToString(CultureInfo.InvariantCulture), dto.OutBizNo);
            if (s == "10000")
            {
                this._refundService.UpdateDeposit(id);
                result.Status = "true";
            }
            else
            {
                result.Status = Permanent.FAILED;
                result.Message = s;
            }

            return Json(result);
        }
    }
}