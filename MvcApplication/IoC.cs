using System;
using Castle.Windsor;

namespace PresentationService
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "IOC", Justification = "IOC - Inversion Of Control")]
    public static class IOC2
    {
        private static readonly IWindsorContainer Container = new WindsorContainer();

        public static IWindsorContainer ContainerInstance
        {
            get { return Container; }
        }

        public static void Dispose()
        {
            Container.Dispose();
        }

        public static void Release(object obj)
        {
            Container.Release(obj);
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static object Resolve(Type type)
        {
            return Container.Resolve(type);
        }
    }
}