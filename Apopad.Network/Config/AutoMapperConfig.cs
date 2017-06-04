using Apopad.Network.AutoMapper.Configurations;
using AutoMapper;
using System;

namespace Apopad.Network.Config
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new KeyWordProfile());
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
