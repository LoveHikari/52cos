using System;
using Com.Cos.Application.Interfaces;
using Com.Cos.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Com.Cos.WebApi.Filter
{
    /// <summary>
    /// 访问拦截器
    /// </summary>
    public class AccessAttribute : ActionFilterAttribute
    {
        private readonly ILoginIPService _loginIpService;
        public AccessAttribute(ILoginIPService loginIpService)
        {
            _loginIpService = loginIpService;
        }
        /// <summary>
        /// 方法运行前
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ip = filterContext.HttpContext.GetUserIp();
            var url = filterContext.HttpContext.Request.Path;
            _loginIpService.Add(ip, url);
            base.OnActionExecuting(filterContext);
        }
    }
}