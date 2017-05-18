using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;

namespace Apopad.WebServices
{
    public static class AutofacConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(System.Reflection.Assembly.GetExecutingAssembly());

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}