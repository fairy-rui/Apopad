using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apopad.Network.AutoMapper.Configurations
{
    public class PaperProfile : Profile
    {
        public PaperProfile()
        {
            CreateMap<Domain.Model.Paper, Model.Paper>()
                .ForMember(c => c.Author, m => m.Ignore())
                .ForMember(p => p.Department, m => m.Ignore());
            CreateMap<Domain.Model.Author, Model.Author>()
                .ForMember(a => a.Paper, m => m.Ignore())
                .ForMember(a => a.Candidate, m => m.Ignore());
            CreateMap<Domain.Model.Candidate, Model.Candidate>()
                .ForMember(c => c.Person, m => m.Ignore())
                .ForMember(c => c.Author, m => m.Ignore());
        }
    }
}
