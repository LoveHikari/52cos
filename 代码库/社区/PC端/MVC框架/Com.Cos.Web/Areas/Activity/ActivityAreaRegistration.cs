using System.Web.Mvc;

namespace Com.Cos.Web.Areas.Activity
{
    public class ActivityAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Activity";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            //context.MapRoute(
            //    "Activity_default",
            //    "Activity/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
            context.MapRoute(
                name: "Activity_new",
                url: "Activity/{action}/{id}",
                defaults: new { controller = "Activity", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Com.Cos.Web.Areas.Activity.Controllers" }
            );
        }
    }
}