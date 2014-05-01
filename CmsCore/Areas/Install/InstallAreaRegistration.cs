﻿using System.Web.Mvc;

namespace CmsCore.Areas.Install
{
    public class InstallAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Install";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Install_default",
                "Install/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { "CmsCore.Areas.Install.Controllers" }
            );
        }
    }
}