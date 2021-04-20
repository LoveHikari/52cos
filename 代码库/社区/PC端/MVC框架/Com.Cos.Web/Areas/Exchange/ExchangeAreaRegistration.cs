using System.Web.Mvc;

namespace Com.Cos.Web.Areas.Exchange
{
    public class ExchangeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Exchange";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Exchange_new",
                url: "Exc/{action}/{id}",
                defaults: new { controller = "Exchange", action = "Index", id = UrlParameter.Optional },
                constraints: new { id = "^\\d+$" },
                namespaces: new[] { "Com.Cos.Web.Areas.Exchange.Controllers" }
            );
            context.MapRoute(
                name: "Exchange_list",
                url: "Exc/{action}/{examineUsName}/{classUsName}/{id}",
                defaults: new { controller = "Exchange", action = "ExcList", examineUsName = UrlParameter.Optional, classUsName = UrlParameter.Optional, id = UrlParameter.Optional },
                namespaces: new[] { "Com.Cos.Web.Areas.Exchange.Controllers" }
            );
        }
    }
}