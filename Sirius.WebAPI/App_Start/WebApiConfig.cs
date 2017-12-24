using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Sirius.Database;
using Sirius.Domain;
using Siruis.Application;

namespace Sirius.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var builder = new ContainerBuilder();

            builder.RegisterModule<CoreImplementationModule>();
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<ApiModule>();
            builder.RegisterModule<DatabaseModule>();
            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            
            config.EnsureInitialized();
        }
    }
}
