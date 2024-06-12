using Autofac;
using platform.empty.ApplicationService.Handler.Queries;
using System.Reflection;
using Module = Autofac.Module;

namespace platform.empty.Container.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblyType = typeof(HealthCheckQueryHandler).GetTypeInfo();
            builder.RegisterAssemblyTypes(assemblyType.Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
