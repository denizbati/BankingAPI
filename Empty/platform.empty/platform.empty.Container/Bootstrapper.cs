using Autofac;
using platform.empty.Container.Modules;

namespace platform.empty.Container
{
    public class Bootstrapper
    {
        public static ILifetimeScope Container { get; private set; }

        public static void RegisterModules(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new MediatRModule());
            containerBuilder.RegisterModule(new ApplicationModule());
        }

        public static void SetContainer(ILifetimeScope autofacContainer)
        {
            Container = autofacContainer;
        }
    }
}
