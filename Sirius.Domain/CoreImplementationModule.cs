using Autofac;
using Sirius.Abstraction.CQRS;
using Sirius.Domain.Services;

namespace Sirius.Domain
{
    public class CoreImplementationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .AsImplementedInterfaces();

            builder.RegisterType<TokenService>().AsImplementedInterfaces();

            builder.RegisterType<Sha512Service>().AsImplementedInterfaces();
        }
    }
}