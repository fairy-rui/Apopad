using AutoMapper;
using System;
using System.Reflection;

namespace Apopad.WebServices
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(Assembly.GetExecutingAssembly());
            });

            try
            {
                Mapper.AssertConfigurationIsValid();
            }
            catch (Exception)
            {

            }
        }
    }
}