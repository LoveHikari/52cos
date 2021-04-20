using Com.Cos.Infrastructure;
using Com.Cos.WebApi.ResultModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using NLog;

namespace Com.Cos.WebApi.Filter
{
    /// <summary>
    /// 异常拦截器
    /// </summary>
    public class ExceptionAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 发生异常时
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(ExceptionContext filterContext)
        {
            //获取异常信息 
            Exception error = filterContext.Exception;
            string message = error.Message;//错误信息
            filterContext.ExceptionHandled = true;
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Error(error);
            MessageBase2 result = new MessageBase2();
            result.Error = (int)StatusCodeEnum.INTERNAL_SERVER_ERROR;
            result.Success = Permanent.FAILED;
#if DEBUG
            result.ErrorMsg = message;
#else
            result.ErrorMsg = "系统繁忙，请稍后再试！";
#endif
            filterContext.Result = new JsonResult(result);

            base.OnException(filterContext);
        }
    }
}