using Apopad.Common.Normalization;
using Apopad.Common.Repositories;
using Apopad.Common.Search;
using Apopad.Domain.Repositories.EntityFramework;
using Apopad.Domain.Service;
using Autofac;
using Autofac.Integration.WebApi;
using System.Data.Entity;
using System.Web.Http;

namespace Apopad.WebServices
{
    public class ApopadModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApopadContext>().As<DbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EntityFrameworkRepositoryContext>()
                .As<IRepositoryContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ParseName>().As<IParseName>()
                .InstancePerLifetimeScope();

            builder.RegisterType<LevenshteinAnalyser>().As<IAnalyser>()
                .SingleInstance();
            builder.RegisterType<Filter>().As<IFilter>().SingleInstance();

            builder.RegisterType<PretreatmentService>().As<IPretreatmentService>()
                .OnActivated(e => e.Instance.Initialize())
                .InstancePerLifetimeScope();
            builder.RegisterType<LookUpService>().As<ILookUpService>()
                .InstancePerLifetimeScope();

            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            base.Load(builder);
        }
    }
}