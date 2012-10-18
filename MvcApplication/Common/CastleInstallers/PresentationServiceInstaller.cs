using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace MVCApplication.Common.CastleInstallers
{
    public class PresentationServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (container != null)
            {
                container
                .Register(AllTypes.FromAssemblyNamed("PresentationService")
                              .BasedOn(typeof(PresentationService.Interfaces.IBasePresentationService))
                              .LifestyleSingleton()
                              .WithServiceDefaultInterfaces());
            }
        }
    }
}