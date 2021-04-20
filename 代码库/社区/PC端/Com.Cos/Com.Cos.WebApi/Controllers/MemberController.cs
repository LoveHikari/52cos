using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Config;
using Com.Cos.Infrastructure.Tencent;
using Com.Cos.Infrastructure.WeChat;
using Com.Cos.WebApi.Models.MemberViewModels;
using Com.Cos.WebApi.ResultModels;
using Com.Cos.WebApi.ResultModels.MemberResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Com.Cos.Infrastructure.Ali;

namespace Com.Cos.WebApi.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/Members")]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly ILoginCodeService _loginCodeService;
        private readonly IExchangeService _exchangeService;
        private readonly IRechargeRecordService _rechargeRecordService;
        private readonly ICooperationService _cooperationService;
        private readonly IRefundService _refundService;
        private readonly ICosFileStatService _cosFileStatService;

        public MemberController(IMemberService memberService, ILoginCodeService loginCodeService, IExchangeService exchangeService, IRechargeRecordService rechargeRecordService,
            ICooperationService cooperationService, IRefundService refundService, ICosFileStatService cosFileStatService)
        {
            _memberService = memberService;
            _loginCodeService = loginCodeService;
            _exchangeService = exchangeService;
            _rechargeRecordService = rechargeRecordService;
            _cooperationService = cooperationService;
            _refundService = refundService;
            _cosFileStatService = cosFileStatService;
        }



        /// <summary>
        /// 根据用户id获得用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET /api/Members/30
        [HttpGet("{id}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Get(int id)
        {
            MessageBase2 result = new MessageBase2();

            MemberDto dto =await _memberService.FindAsync(id);

            result.Data = ConvertHelper.ChangeType<MemberResultModel>(dto);
            return result;
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="model"></param>
        /// <returns></returns>
        // PUT /api/Members/Password/30
        [AcceptVerbs("PUT"), Route("Password"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> PutPassword(int id, [FromBody]PasswordViewModel model)
        {
            MessageBase2 result = new MessageBase2();

            if (await _loginCodeService.FindAsync(model.Phone, model.VerifyCode))
            {
                await _memberService.UpdatePasswordAsync(model.Phone, model.Password);
                result.Success = Permanent.SUCCESS;
            }
            else
            {
                result.Success = Permanent.FAILED;
                result.Error = (int)StatusCodeEnum.UNAUTHORIZED;
                result.ErrorMsg = "验证码已过期或验证码不正确";
            }

            return result;
        }

        /// <summary>
        /// 修改个性签名、性别、昵称
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="model"></param>
        /// <returns></returns>
        // PUT /api/Members/30
        [HttpPut("{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> Put([Required]int id, [FromBody]DescribeViewModel model)
        {
            MessageBase2 result = new MessageBase2();

            var dto = ConvertHelper.ChangeType<MemberDto>(model);
            dto.Id = id;
            await _memberService.UpdateAsync(dto);

            return result;
        }
        /// <summary>
        /// 修改手机号
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        // PUT /api/Members/Phone/30
        [HttpPut, Route("Phone/{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> PutPhone([Required]int id, [FromBody]PhoneViewModel model)
        {
            MessageBase2 result = new MessageBase2();
            if (await _memberService.ExistAsync("phone", model.Phone) > 0)
            {
                result.Success = Permanent.FAILED;
                result.Error = (int)StatusCodeEnum.INVALID_REQUEST;
                result.ErrorMsg = "手机号已存在";
            }
            else
            {
                MemberDto dto = new MemberDto()
                {
                    Id = id,
                    PhoneMob = model.Phone
                };
                await _memberService.UpdateAsync(dto);
                result.Success = Permanent.SUCCESS;
            }


            return result;
        }


        /// <summary>
        /// 修改头像
        /// </summary>
        /// <returns></returns>
        // POST /api/Members/Portrait/30
        [HttpPost, Route("Portrait/{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> PostPortrait(int id, [FromForm]IFormFile portrait)
        {
            MessageBase2 result = new MessageBase2();

            var fileName = ContentDispositionHeaderValue.Parse(portrait.ContentDisposition).FileName.Value.Trim('"');
            var ext = System.IO.Path.GetExtension(fileName);

            fileName = SysHelper.RandomFileName() + ext;

            Stream st = portrait.OpenReadStream();

            QCloudHelper qCloud = new QCloudHelper();
            var b = qCloud.UploadFile("/upload/portrait/", fileName, st);
            CosFileStatDto dto = new CosFileStatDto()
            {
                AccessUrl = b.AccessUrl,
                Url = b.Url,
                SourceUrl = b.SourceUrl,
                ResourcePath = b.ResourcePath
            };
           await _cosFileStatService.AddAsync(dto);


            await _memberService.UpdatePortraitAsync(id, OtherConfig.PortraitWebDir + fileName);

            result.Success = Permanent.SUCCESS;
            return result;
        }
        /// <summary>
        /// 添加充值身家订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST /api/Members/ShenJiaRecharge
        [HttpPost, Route("ShenJiaRecharge"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> PostShenJiaRecharge([FromBody]ShenJiaRechargeViewModel model)
        {
            MessageBase2 result = new MessageBase2();
            RechargeRecordDto dto = new RechargeRecordDto()
            {
                UserId = model.UserId,
                OrderNo = SysHelper.GenerateTradeNo(),
                Money = model.Money,
                WareDesc = model.Type,//"身家充值",
                OrderName = model.Type,//"身家充值"
                Type = model.Type
            };
            int id = await _rechargeRecordService.AddAsync(dto);
            string passbackParams = "merchantType=身家充值&id=" + id;
            if (model.PayType == "Ali")
            {
                result.Data = AliPaySdk.Signature(model.Type, model.Type, model.Money.ToString(CultureInfo.InvariantCulture), dto.OrderNo, passbackParams);
            }
            if (model.PayType == "Wx")
            {
                result.Data = WxPaySdk.UnifiedOrder(model.Type, model.Type, model.Money.ToString(CultureInfo.InvariantCulture), dto.OrderNo, HttpContext.GetUserIp(), passbackParams);
            }

            return result;
        }
        /// <summary>
        /// 获得我发布的兑换
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数据数</param>
        /// <returns></returns>
        // GET /api/Members/Exchange/30?pageIndex=1&pageSize=4
        [HttpGet, Route("Exchange/{userId:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> GetExchange(int userId, int pageIndex, int pageSize)
        {
            MessageBase2 result = new MessageBase2();

            var v = await _exchangeService.FindListAsync(pageIndex, pageSize, "", 0, 0, userId);

            var page = ConvertHelper.ChangeType<MessagePageBase2>(v.pageDto);
            var erList = new List<ExchangeResultModel>();
            v.dto.ForEach(p =>
            {
                erList.Add(new ExchangeResultModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    AddTime = p.AddTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Nickname = p.Nickname,
                    Cover = p.Cover,
                    Examine = p.ExamineName + (p.ExamineName == "审核完成" ? ":" + p.Official : ""),
                    LogisticCode = p.LogisticCode,
                    Portrait = p.Portrait
                });
            });
            page.Data = erList;

            result.Data = page;
            return result;
        }

        /// <summary>
        /// 获得我发布的合作
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页数据数</param>
        /// <returns></returns>
        // GET /api/Members/Cooperation/30?pageIndex=1&pageSize=4
        [HttpGet, Route("Cooperation/{userId:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> GetCooperation(int userId, int pageIndex, int pageSize)
        {
            MessageBase2 result = new MessageBase2();

            var v = await _cooperationService.FindListAsync(pageIndex, pageSize, userId);

            var page = ConvertHelper.ChangeType<MessagePageBase2>(v.pageDto);
            var erList = new List<CooperationResultModel>();
            v.dtoList.ForEach(p =>
            {
                erList.Add(new CooperationResultModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    AddTime = p.AddTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Nickname = p.Nickname,
                    Cover = p.Cover,
                    City = p.City,
                    PersonNum = p.PersonNum
                });
            });
            page.Data = erList;

            result.Data = page;
            return result;
        }
        /// <summary>
        /// 退还押金
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        // POST /api/Transfer/30
        [HttpPost, Route("Transfer/{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> PostTransfer([Range(typeof(int), "1", "999999999", ErrorMessage = "用户id必须大于0")]int id)
        {
            MessageBase2 result = new MessageBase2();
            await _refundService.AddAsync(id);
            return result;
        }
        /// <summary>
        /// 修改支付宝账号
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        // PUT /api/Members/Alipay/30
        [HttpPut, Route("Alipay/{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> PutAlipay(int id, [FromBody]AlipayViewModel model)
        {
            MessageBase2 result = new MessageBase2();

            MemberDto dto = new MemberDto()
            {
                Id = id,
                ImAlipay = model.ImAlipay,
                RealName = model.RealName
            };
            await _memberService.UpdateAsync(dto);

            return result;
        }
    }
}