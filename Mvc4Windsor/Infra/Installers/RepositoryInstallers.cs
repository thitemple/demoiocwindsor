using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Mvc4Windsor.Models;
using Mvc4Windsor.Models.Repository;

namespace Mvc4Windsor.Infra.Installers
{
    public class RepositoryInstallers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(
                Component.For<TarefasContext>()
                    .LifestylePerWebRequest());

            container.Register(
                Component.For<IDependencia>()
                .ImplementedBy<Dependencia>()
                .LifestyleTransient(),
                Component.For<ITarefaRepository>()
                .ImplementedBy<TarefaEntityFrameworkRepository>()
                .LifestyleTransient());

        }
    }
}