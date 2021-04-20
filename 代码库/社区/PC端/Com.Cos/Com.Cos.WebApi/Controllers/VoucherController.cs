using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Cos.Application.Interfaces;
using Com.Cos.WebApi.Models.VoucherViewModels;
using Com.Cos.WebApi.ResultModels;
using Com.Cos.WebApi.ResultModels.VoucherResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Com.Cos.WebApi.Controllers
{
    /// <summary>
    /// 兑换码控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/Vouchers")]
    public class VoucherController : Controller
    {
        private readonly IVoucherService _voucherService;
        public VoucherController(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }
        /// <summary>
        /// 兑换兑换码
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST api/Vouchers/30
        [HttpPost("{userId:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Post(int userId,[FromBody]VoucherViewModel model)
        {
            MessageBase2 result = new MessageBase2();
            await _voucherService.ExchangeAsync(userId,model.Code);
            return result;
        }
        /// <summary>
        /// 分页获得列表
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数据数</param>
        /// <returns></returns>
        // GET api/Vouchers/30?pageIndex=1&pageSize=10
        [HttpGet("{userId:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Get(int userId,int pageIndex, int pageSize)
        {
            MessageBase2 result = new MessageBase2();
            var v = await _voucherService.FindListAsync(pageIndex, pageSize, userId);

            var page = ConvertHelper.ChangeType<MessagePageBase2>(v.pageDto);

            List<VoucherListResultModel> modelList = new List<VoucherListResultModel>();
            v.dto.ForEach(t => {modelList.Add(ConvertHelper.ChangeType<VoucherListResultModel>(t));});

            page.Data = modelList;

            result.Data = page;
            return result;
        }
    }
}