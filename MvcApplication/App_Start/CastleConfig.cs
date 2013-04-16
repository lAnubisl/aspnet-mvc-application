using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication.App_Start.CastleInstallers;
using PresentationService;

namespace MvcApplication
{
    public class CastleConfig
    {
        public static void RegisterComponents()
        {
            IOC.ContainerInstance.Install(
                new RepositoryInstaller(),
                new DomainServiceInstaller(),
                new PresentationServiceInstaller(),
                new ControllerInstaller());
        }
    }
}