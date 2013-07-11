using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace PrivateZone.Locator
{
    public sealed class IoC
    {
        private IWindsorContainer container;

        private static readonly IoC instance = new IoC();

        static IoC()
        {
        }

        private IoC()
        {
        }

        public static IoC Current
        {
            get { return instance; }
        }

        public IWindsorContainer Container
        {
            get { return container = container ?? new WindsorContainer(); }
        }

        public void Init()
        {
            Container.Install(FromAssembly.This());
        }
    }
}