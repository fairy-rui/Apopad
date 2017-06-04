using Apopad.Domain.Model;
using AutoMapper;

namespace Apopad.Network.AutoMapper.Configurations
{
    public class KeyWordProfile : Profile
    {
        public KeyWordProfile()
        {
            CreateMap<Keyword, KeyWords>()
                .ForMember(k => k.Name, s => s.MapFrom(k => k.KeyWord));
        }
    }
}
