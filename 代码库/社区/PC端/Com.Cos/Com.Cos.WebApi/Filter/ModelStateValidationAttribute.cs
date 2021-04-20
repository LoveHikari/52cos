using System.Collections.Generic;
using Com.Cos.Infrastructure;
using Com.Cos.WebApi.ResultModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Com.Cos.WebApi.Filter
{
    /// <summary>
    /// ModelState验证过滤器
    /// </summary>
    public class ModelStateValidationAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 方法运行前
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                MessageBase2 result = new MessageBase2();
                if (filterContext.ModelState.Values.Any())
                {
                    result.Error = (int)StatusCodeEnum.INVALID_REQUEST;
                    result.Success = Permanent.FAILED;
                    result.ErrorMsg = GetErrorMessage(filterContext.ModelState);
                }
                filterContext.Result = new JsonResult(result);
            }
            base.OnActionExecuting(filterContext);
        }


        private static string GetErrorMessage(ModelStateDictionary modelState)
        {
            StringBuilder sb = new StringBuilder();
            // 获取所有错误的Key
            List<string> keys = modelState.Keys.ToList();
            //获取每一个key对应的ModelStateDictionary
            foreach (var key in keys)
            {
                var errors = modelState[key].Errors.ToList();
                //将错误描述添加到sb中
                foreach (var error in errors)
                {
                    //sb.AppendFormat("{0}:{1};", key, error.ErrorMessage);
                    sb.AppendFormat("{1};", key, error.ErrorMessage);
                }
            }
            return sb.ToString().TrimEnd(';');
        }
    }
}