using Autofac;
using AutoMapper;
using MediatR;
using platform.empty.ApiContract.Request.Queries;
using platform.empty.ApplicationService.Handler.Queries;
using platform.empty.Container.Decorator;
using System.Reflection;
using Module = Autofac.Module;

namespace platform.empty.Container.Modules
{
    public class MediatRModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(HealthCheckQuery).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(HealthCheckQueryHandler).Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(ExceptionHandler<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(LoggingHandler<,>)).As(typeof(IPipelineBehavior<,>));

            builder.RegisterType(typeof(Mapper)).As(typeof(IMapper)).AsSelf().InstancePerLifetimeScope();
            //builder.RegisterType(typeof(AutoMapperConfiguration)).As(typeof(IAutoMapperConfiguration)).AsSelf().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
