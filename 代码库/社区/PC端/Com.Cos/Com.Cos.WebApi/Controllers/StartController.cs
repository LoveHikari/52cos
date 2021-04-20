using Com.Cos.Application.DTO;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.Infrastructure.Config;
using Com.Cos.Infrastructure.Tencent;
using Com.Cos.WebApi.Models.MemberViewModels;
using Com.Cos.WebApi.Models.StartViewModels;
using Com.Cos.WebApi.ResultModels;
using Com.Cos.WebApi.ResultModels.StartResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace Com.Cos.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/Members")]
    public class StartController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly ILoginCodeService _loginCodeService;
        private readonly IQuickNavigationService _quickNavigationService;
        private readonly ICosFileStatService _cosFileStatService;
        private readonly IVersionNotesService _versionNotesService;

        public StartController(IMemberService memberService, ILoginCodeService loginCodeService, IQuickNavigationService quickNavigationService, ICosFileStatService cosFileStatService,
            IVersionNotesService versionNotesService)
        {
            _memberService = memberService;
            _loginCodeService = loginCodeService;
            _quickNavigationService = quickNavigationService;
            _cosFileStatService = cosFileStatService;
            _versionNotesService = versionNotesService;
        }
        /// <summary>
        /// 获得验证码
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        // GET /api/Members/SmsCode?phone=134xxxx0761
        [HttpGet, Route("SmsCode"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> SmsCode(string phone)
        {
            MessageBase2 result = new MessageBase2();
            string code = PublishBatchSMSMessage.AuthenticationVerifyCode(phone);

            //string code = "123456";
            await _loginCodeService.AddAsync(phone, code);

            return result;
        }
        /// <summary>
        /// 验证验证码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST /api/Members/SmsCode
        [HttpPost, Route("SmsCode"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> SmsCode([FromBody] SmsCodeViewModel model)
        {
            MessageBase2 result = new MessageBase2();

            if (await _loginCodeService.FindAsync(model.Phone, model.VerifyCode))
            {
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
        /// 第三方登录&amp;注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST /api/Members/OauthLogin
        [HttpPost, Route("OauthLogin"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> PostOauthLogin([FromBody]OauthLoginViewModel model)
        {
            MessageBase2 result = new MessageBase2();
            result.Data = new MemberLoginResultModel();
            int userId;

            userId = await _memberService.ExistAsync(model.Type, model.UserName);
            if (userId <= 0)  //如果用户已经存在，则直接返回，如果不存在则注册
            {
                //头像保存到本地
                string fileName = SysHelper.RandomFileName() + ".png";
                QCloudHelper qCloud = new QCloudHelper();


                Stream stream = HttpHelper.GetHttpWebRequest2(model.Figureurl);
                var b = qCloud.UploadFile("/upload/portrait/", fileName, stream);

                CosFileStatDto cosDto = new CosFileStatDto()
                {
                    AccessUrl = b.AccessUrl,
                    Url = b.Url,
                    SourceUrl = b.SourceUrl,
                    ResourcePath = b.ResourcePath
                };
                await _cosFileStatService.AddAsync(cosDto);


                userId = await _memberService.AddAsync(model.Type, model.UserName, HttpContext.GetUserIp(), "", model.Nickname, model.Gender, OtherConfig.PortraitWebDir + fileName);


            }
            MemberDto dto = await _memberService.FindAsync(userId);
            result.Data = ConvertHelper.ChangeType<MemberLoginResultModel>(dto);


            return result;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        // POST /api/Members/Register
        [HttpPost, Route("Register"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> PostRegister([FromBody]RegisterViewModel model)
        {
            MessageBase2 result = new MessageBase2();
            if (model.Type == "phone" && !await _loginCodeService.FindAsync(model.UserName, model.VerifyCode))
            {
                //ModelState.AddModelError("VerifyCode", "短信验证码不正确或已失效");
                result.Error = (int)StatusCodeEnum.INVALID_REQUEST;
                result.Success = Permanent.FAILED;
                result.ErrorMsg = "短信验证码不正确或已失效";

                return result;
            }

            int userId = await _memberService.AddAsync(model.Type, model.UserName, HttpContext.GetUserIp(), model.Password);
            result.Success = Permanent.SUCCESS;


            return result;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        // POST /api/Members/Login
        [HttpPost, Route("Login"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> PostLogin([FromBody]LoginViewModel model)
        {
            MessageBase2 result = new MessageBase2();

            result.Data = new MemberLoginResultModel();

            if (await _memberService.ExistAsync(model.Type, model.UserName) > 0)
            {
                int id = await _memberService.FindAsync(model.Type, model.UserName, model.Password);
                if (id > 0)  //如果用户已经存在，则直接返回
                {
                    var dto = await _memberService.FindAsync(id);
                    result.Success = Permanent.SUCCESS;
                    result.Data = ConvertHelper.ChangeType<MemberLoginResultModel>(dto);
                }
                else
                {
                    result.Success = Permanent.FAILED;
                    result.Error = (int)StatusCodeEnum.UNAUTHORIZED;
                    result.ErrorMsg = "用户名或密码错误";
                }
            }
            else
            {
                result.Success = Permanent.FAILED;
                result.Error = (int)StatusCodeEnum.NOT_FOUND;
                result.ErrorMsg = "该用户不存在";
            }

            return result;
        }

        /// <summary>
        /// 获得用户协议
        /// </summary>
        /// <returns></returns>
        // GET /api/Members/UserAgreement
        [AcceptVerbs("GET"), Route("UserAgreement/{id:int}"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> UserAgreement(int id)
        {
            MessageBase2 result = new MessageBase2();
            string count = (await _quickNavigationService.FindAsync(id)).Cont;

            result.Data = count;
            return result;
        }
        /// <summary>
        /// 获得版本更新
        /// </summary>
        /// <param name="terminal">终端</param>
        /// <param name="localVersion">版本号</param>
        /// <returns></returns>
        [AcceptVerbs("GET"), Route("GetVersion"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> GetVersion([RegularExpression("IOS|Android", ErrorMessage = "不支持的终端类型")]string terminal, string localVersion = "0")
        {
            MessageBase2 result = new MessageBase2();

            VersionResultModel model = new VersionResultModel();

            string version = await this._versionNotesService.FindAsync(terminal);

            model.IsUpdate = false;

            if (terminal == "IOS")
            {
                model.Url = OtherConfig.AppleDownloadUrl;
            }
            else if (terminal == "Android")
            {
                model.Url = OtherConfig.AndroidDownloadUrl;
            }

            int ve = version.Replace(".", "").ToInt32();

            if (localVersion.Replace(".", "").ToInt32() < ve)
            {
                model.IsUpdate = true;
            }
            result.Data = model;
            return result;
        }

    }
}
