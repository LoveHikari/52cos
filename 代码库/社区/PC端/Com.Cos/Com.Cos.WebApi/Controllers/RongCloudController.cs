using System.Threading.Tasks;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Com.Cos.WebApi.ResultModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Com.Cos.WebApi.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// 融云控制器
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/RongClouds")]
    public class RongCloudController : Controller
    {
        private readonly IMemberService _memberService;
        public RongCloudController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        /// <summary>
        /// 获得融云token
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="nickname">用户昵称</param>
        /// <returns></returns>
        // GET: api/RongClouds/Token?userId=30&nickname=昵称
        [HttpGet, Route("Token"), MapToApiVersion("1.0"), EnableCors("AllowSpecificOrigin")]
        public async Task<object> GetToken(int userId, string nickname)
        {
            MessageBase2 result = new MessageBase2();
            string token = RongCloudHelper.GetToken(userId.ToString(), nickname);
            await _memberService.UpdateRongTokenAsync(userId, token);
            result.Data = token;
            return result;
        }

    }
}
