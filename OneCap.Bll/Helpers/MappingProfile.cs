﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OneCap.Bll.Dto.Request;
using OneCap.Bll.Dto.Result;
using OneCap.Dal.Entities;

namespace OneCap.Bll.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, RoleDto>();
            CreateMap<CreateCourseDto, Course>();

            CreateMap<CreateRoleDto, IdentityRole>();
            CreateMap<IdentityRole, RoleDto>();
        }
    }
}