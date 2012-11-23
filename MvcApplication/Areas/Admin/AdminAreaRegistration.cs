using System;
using System.Web.Mvc;

namespace MvcApplication.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        private static readonly string[] Namespaces = new[] { "MvcApplication.Areas.Admin.Controllers" };

        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            context.MapRoute("Admin_default", "Admin/{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, Namespaces);
        }
    }
}