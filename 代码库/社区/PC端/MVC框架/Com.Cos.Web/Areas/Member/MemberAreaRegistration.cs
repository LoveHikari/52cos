using System.Web.Mvc;

namespace Com.Cos.Web.Areas.Member
{
    public class MemberAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Member";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //context.MapRoute(
            //    "Member_default",
            //    "Member/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
            context.MapRoute(
                name: "Member_new",
                url: "User/{action}/{id}",
                defaults: new { controller = "Member", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Com.Cos.Web.Areas.Member.Controllers" }
            );
        }
    }
}