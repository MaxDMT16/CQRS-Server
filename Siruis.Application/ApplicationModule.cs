using Autofac;
using Sirius.Abstraction.Factories;
using Siruis.Application.Buses;
using Siruis.Application.Factories;

namespace Siruis.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandBus>().AsImplementedInterfaces();
            builder.RegisterType<QueryBus>().AsImplementedInterfaces();

            builder.RegisterType<HttpClientFactory>().AsImplementedInterfaces().SingleInstance();
            builder.Register(context => context.Resolve<IHttpClientFactory>().Create()).AsSelf();
        }
    }
}