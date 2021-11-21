using System.Web.Mvc;

namespace BlogWebTinTuc.Areas.BTV
{
    public class BTVAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BTV";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BTV_default",
                "BTV/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}