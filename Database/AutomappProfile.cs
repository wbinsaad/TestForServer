using AutoMapper;
using TestForServer.Models;
using TestForServer.ModelViews;

namespace TestForServer.Database
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            CreateMap<TextDto, Text>().ReverseMap();
        }
    }
}
