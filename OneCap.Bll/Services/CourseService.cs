using AutoMapper;
using Microsoft.Extensions.Logging;
using OneCap.Bll.Dto.Request;
using OneCap.Bll.Dto.Result;
using OneCap.Dal.Entities;
using OneCap.Dal.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OneCap.Bll.Services
{
    public class CourseService : ServiceBase, ICourseService
    {
        public CourseService(IUnitOfWork uow, IMapper mapper, ILogger<CourseService> logger) : base(uow, mapper, logger)
        { 
        }

        public async Task<CourseDto> GetCourseByIdAsync(int id, CancellationToken ct)
        {
            Course courseEntity = await _uow.Courses.GetAsync(id, ct);
            if (courseEntity == null)
                return null;

            CourseDto courseDto = _mapper.Map<CourseDto>(courseEntity);

            return courseDto;
        }

        public async Task<IEnumerable<CourseDto>> GetCoursesAsync(CancellationToken ct)
        {
            var courseEntities = await _uow.Courses.GetAllAsync(ct);
            if (courseEntities == null)
                return null;

            var coursesDto = _mapper.Map<IEnumerable<CourseDto>>(courseEntities);

            return coursesDto;
        }

        public async Task<CourseDto> CreateCourseAsync(CreateCourseDto createCourseDto, CancellationToken ct)
        {
            Course courseEntity = null;
            
            try
            {
                courseEntity = _mapper.Map<Course>(createCourseDto);

                await _uow.Courses.AddAsync(courseEntity, ct);
                await _uow.SaveChangesAsync(ct);
            }
            catch (Exception ex)
            {
                return null;
            }

            return _mapper.Map<CourseDto>(courseEntity);
        }
    }
}
