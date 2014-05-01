using System.Web.Mvc;

namespace CmsCore.Areas.Manage
{
    public class ManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Manage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Manage_default",
                "Manage/{controller}/{action}/{id}",
                new { controller = "Home",action = "Index", id = UrlParameter.Optional },
                new string[] { "CmsCore.Areas.Manage.Controllers" }
            );
        }
    }
}