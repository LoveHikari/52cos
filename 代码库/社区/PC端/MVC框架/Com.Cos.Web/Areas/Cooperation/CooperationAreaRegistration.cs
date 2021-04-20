using System.Web.Mvc;

namespace Com.Cos.Web.Areas.Cooperation
{
    public class CooperationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Cooperation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Cooperation_new",
                url: "Coo/{action}/{id}",
                defaults: new { controller = "Cooperation", action = "Index", id = UrlParameter.Optional },
                //constraints: new { id = "^\\d+$" },
                namespaces: new[] { "Com.Cos.Web.Areas.Cooperation.Controllers" }
            );
            
        }
    }
}