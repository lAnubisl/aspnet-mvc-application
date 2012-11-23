using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using DomainService.DomainModels;
using log4net;
using MvcApplication.Binders.Admin.Category;
using MvcApplication.Binders.Admin.Consignment;
using MvcApplication.Binders.Admin.Product;
using MvcApplication.Common;
using MvcApplication.Common.CastleInstallers;
using PresentationService;
using PresentationService.Interfaces.Admin;
using PresentationService.Models.AdminModels.CategoryModels;
using PresentationService.Models.AdminModels.ConsignmentModels;
using PresentationService.Models.AdminModels.ProductModels;

namespace MvcApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        public static readonly ILog Logger = LogManager.GetLogger(typeof(MvcApplication));

        private static readonly IList<string> IgnoreExtentions = new List<string> { "js", "css", "png", "gif", "jpg", "txt", "ico" };

        private static readonly string[] Namespaces = new[] { "MvcApplication.Controllers" };

        public static User LoggedInUser
        {
            get
            {
                var systemUser = HttpContext.Current.User as SystemUser;
                return systemUser != null ? systemUser.LoggedInUser : null;
            }
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.IgnoreRoute("{*resource}", new { resource = string.Format(@".*\.({0})(/.*)?", string.Join("|", IgnoreExtentions.ToArray())) });

            routes.MapRoute("Home", "{action}", new { controller = "Home", action = "Index" }, Namespaces);
            routes.MapRoute("Add", "{controller}/Add", new { controller = "Category", action = "Add" }, Namespaces);
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, Namespaces);

            ////This route supports links to static html pages ex.: http://www.domain.com/Traider/test/mypage.html
            ////routes.MapRoute("TraderStaticPage","Trader/{*page}", new { controller = "TraderStatic", action = "Redirect" }, new { page = @"[\w%/]+.html$" });
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Application_Start should not be static or it will not called")]
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalFilters.Filters.Add(new HandleErrorAttribute());
            RegisterRoutes(RouteTable.Routes);

            // Configure log4net
            log4net.Config.XmlConfigurator.Configure();

            // Adds and configures all components using WindsorInstallers from executing assembly
            IOC.ContainerInstance.Install(
                new RepositoryInstaller(),
                new DomainServiceInstaller(),
                new PresentationServiceInstaller(),
                new ControllerInstaller());

            AddModelBinders();

            ControllerBuilder.Current.SetControllerFactory(new CastleControllerFactory());
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (IgnoreExtentions.All(ext => !Request.RawUrl.EndsWith("." + ext)) && HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var identity = HttpContext.Current.User.Identity as FormsIdentity;
                if (identity != null)
                {
                    var ticket = identity.Ticket;
                    var roles = ticket.UserData.Split(',');
                    HttpContext.Current.User = new SystemUser(identity, roles);
                }
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {
            IOC.ContainerInstance.Dispose();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Catches all errors in application")]
        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                var exception = HttpContext.Current.Server.GetLastError();
                if (exception.Message != "File does not exist.")
                {
                    Logger.Error("Error at application from " + Request.ServerVariables["REMOTE_ADDR"], HttpContext.Current.Server.GetLastError());
                }
            }

            // ReSharper disable EmptyGeneralCatchClause
            catch (Exception)
            // ReSharper restore EmptyGeneralCatchClause
            {
                ////DO NOTHING
            }
        }

        private static void AddModelBinders()
        {
            ModelBinders.Binders.Add(typeof(CategoryEditModel), new CategoryEditModelBinder(IOC.ContainerInstance.Resolve<ICategoryPresentationService>()));
            ModelBinders.Binders.Add(typeof(ProductEditModel), new ProductEditModelBinder(IOC.ContainerInstance.Resolve<IProductPresentationService>()));
            ModelBinders.Binders.Add(typeof(ConsignmentEditModel), new ConsignmentEditModelBinder(IOC.ContainerInstance.Resolve<IConsignmentPresentationService>()));
        }
    }
}