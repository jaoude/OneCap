using AutoMapper;
using Microsoft.Extensions.Logging;
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

        public async Task<CourseDto> GetCourseByIdAsync(Guid id, CancellationToken ct)
        {
            Course courseEntity = await _uow.Courses.GetCourseByIdAsync(ct, id);
            if (courseEntity == null)
                return null;

            CourseDto courseDto = _mapper.Map<CourseDto>(courseEntity);

            return courseDto;
        }
    }
}
