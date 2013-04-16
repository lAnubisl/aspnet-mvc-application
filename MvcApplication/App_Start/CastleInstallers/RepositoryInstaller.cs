using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace MvcApplication.App_Start.CastleInstallers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (container != null)
            {
                container
                .Register(Classes.FromAssemblyNamed("NHibernate.Repository")
                .BasedOn(typeof(NHibernate.Repository.Repository.GenericRepository<>))
                .LifestyleSingleton()
                .WithServiceDefaultInterfaces()
                .Configure(c => c.DependsOn(Property.ForKey("sessionFactoryName").Eq("MVC"))));
            }
        }
    }
}