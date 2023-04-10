using System.Web.Mvc;

namespace Web_Ban_Quan_Ao.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new {controller = "Clothing" ,action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}