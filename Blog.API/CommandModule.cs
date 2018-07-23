using System;
using System.Linq;
using Autofac;
using Blog.Core.Interfaces;
using Blog.Core;

namespace Blog.API
{
    public class CommandModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder.RegisterAssemblyTypes(assemblies)
                   .Where(o => o.IsAssignableTo<ICommandHandler>())
                   .AsImplementedInterfaces();

            builder.Register<Func<Type, ICommandHandler>>(o =>
            {
                var ctx = o.Resolve<IComponentContext>();

                return t =>
                {
                    var handlerType = typeof(ICommandHandler<>).MakeGenericType(t);
                    return ctx.Resolve(handlerType) as ICommandHandler;
                };
            });

            builder.RegisterType<CommandBus>().AsImplementedInterfaces();
        }
    }
}
