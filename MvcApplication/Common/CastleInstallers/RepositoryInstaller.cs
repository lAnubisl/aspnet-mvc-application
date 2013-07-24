﻿using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace MvcApplication.Common.CastleInstallers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (container != null)
            {
                container
                .Register(AllTypes.FromAssemblyNamed("NHibernate.Repository")
                .BasedOn(typeof(NHibernate.Repository.Repository.GenericRepository<>))
                .LifestyleSingleton()
                .WithServiceDefaultInterfaces()
                .Configure(c => c.DependsOn(Property.ForKey("connectionString").Eq(ConfigurationManager.AppSettings["connectionString"]))));
            }
        }
    }
}