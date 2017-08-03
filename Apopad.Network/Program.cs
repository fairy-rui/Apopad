using Apopad.Common.Repositories;
using Apopad.Network.Config;
using Apopad.Network.Util;
using Autofac;
using SrimsOUC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apopad.Network
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AutoMapperConfig.Initialize();

            var builder = new ContainerBuilder();
            builder.RegisterModule<NetWorkModule>();

            using(var container = builder.Build())
            {
                //var networking = container.Resolve<Networking>();

                //networking.BuildNetWork();
                //导入补全专家信息
                var importExpert = container.Resolve<IImportExpert>();
                importExpert.DoImportExpert();
            }
        }
    }
}
