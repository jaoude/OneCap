using AutoMapper;
using OneCap.Bll.Dto.Result;
using OneCap.Dal.Entities;

namespace OneCap.Bll.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>();
        }
    }
}