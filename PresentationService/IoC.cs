using Castle.Windsor;

namespace PresentationService
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "IOC", Justification = "IOC - Inversion Of Control")]
    public static class IOC
    {
        private static readonly IWindsorContainer Container = new WindsorContainer();

        public static IWindsorContainer ContainerInstance
        {
            get { return Container; }
        }
    }
}