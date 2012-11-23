using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace MvcApplication.Common.CastleInstallers
{
    public class DomainServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (container != null)
            {
                container
                .Register(AllTypes.FromAssemblyNamed("DomainService")
                .BasedOn(typeof(DomainService.DomainServices.GenericDomainService<,>))
                .LifestyleSingleton()
                .WithServiceDefaultInterfaces());
            }
        }
    }
}