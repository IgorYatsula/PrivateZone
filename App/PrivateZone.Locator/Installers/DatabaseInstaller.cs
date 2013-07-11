using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PrivateZone.Core.Data;
using PrivateZone.Data;

namespace PrivateZone.Locator.Installers
{
    public class DatabaseInstaller : IWindsorInstaller
    {
        private const string CONNECTION_NAME = "PrivateZoneConnection";

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof (IRepository<>))
                         .ImplementedBy(typeof (Repository<>))
                         .DependsOn(Dependency.OnValue<string>(
                             ConfigurationManager.ConnectionStrings[CONNECTION_NAME].ConnectionString))
                         .LifestyleTransient());
        }
    }
}