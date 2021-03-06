﻿using Apopad.Common.Repositories;
using Apopad.Domain.Repositories.EntityFramework;
using Apopad.Network.Util;
using Autofac;
using SrimsOUC.Data.Model;
using System.Data.Entity;

namespace Apopad.Network.Config
{
    public class NetWorkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApopadContext>().As<DbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EntityFrameworkRepositoryContext>()
                .As<IRepositoryContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SrimsContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Networking>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CoAuthorNetwork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ImportExpert>()
                .As<IImportExpert>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
