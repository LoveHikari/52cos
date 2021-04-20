using System.Web.Mvc;

namespace Com.Cos.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new System.Web.Mvc.AuthorizeAttribute());  //将Authorize应用到全部的应用程序的范围类，使AuthorizeAttribute成为全程序的过滤器
            filters.Add(new HandleErrorAttribute());
        }
    }
}
