using MvcApplication.App_Start.CastleInstallers;
using PresentationService;

namespace MvcApplication.App_Start
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