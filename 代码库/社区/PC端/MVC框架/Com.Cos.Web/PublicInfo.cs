using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using Com.Cos.BLL;
using Com.Cos.Common;
using Com.Cos.IBLL;

namespace Com.Cos.Web
{
    public class PublicInfo
    {
        /// <summary>
        /// 获得登录后的会员id
        /// </summary>
        /// <returns>未登录时返回-1</returns>
        public static int GetLoginUid()
        {
            IMemberService memberService = new MemberService();
            IDictionary<string, string> cookies = GetLoginCookie();
            if (cookies.ContainsKey(ClaimTypes.NameIdentifier))
            {
                int userId = cookies[ClaimTypes.NameIdentifier].ToInt32();
                string pwd = cookies["Password"];
                var member = memberService.Find(userId, pwd);
                return member != null ? userId : -1;
            }
            return -1;
        }
        /// <summary>
        /// 获得登录信息cookie
        /// </summary>
        /// <returns>cookie键值对</returns>
        private static IDictionary<string, string> GetLoginCookie()
        {
            //var identity = (ClaimsIdentity)User.Identity;
            //IEnumerable<Claim> claims = identity.Claims;
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            IEnumerable<Claim> claims = identity.Claims;
            return claims.ToDictionary(k => k.Type, k => k.Value);
        }
    }
}