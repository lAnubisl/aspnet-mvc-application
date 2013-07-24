#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using DomainService.DomainModels;
using log4net;
using MvcApplication.App_Start;
using MvcApplication.Common;
using PresentationService;

#endregion

namespace MvcApplication
{
    //// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    //// visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(MvcApplication));

        private static readonly IList<string> IgnoreExtentions = new List<string> { "js", "css", "png", "gif", "jpg", "txt", "ico" };

        public static User LoggedInUser
        {
            get
            {
                var systemUser = HttpContext.Current.User as SystemUser;
                return systemUser != null ? systemUser.LoggedInUser : null;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Application_Start should not be static or it will not called")]
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes, IgnoreExtentions.ToArray());
            CastleConfig.RegisterComponents();
            BinderConfig.RegisterBinders();

            //// Configure log4net
            log4net.Config.XmlConfigurator.Configure();

            //// Adds and configures all components using WindsorInstallers from executing assembly

            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Request.CurrentExecutionFilePathExtension != null && IgnoreExtentions.All(ext => !Request.CurrentExecutionFilePathExtension.Equals("." + ext)) && HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
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
            IOC.Dispose();
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
    }
}