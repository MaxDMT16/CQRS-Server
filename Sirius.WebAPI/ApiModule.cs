using Autofac;
using Autofac.Features.AttributeFilters;
using Autofac.Integration.WebApi;

namespace Sirius.WebAPI
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(ThisAssembly).WithAttributeFiltering();
        }
    }
}