using OneCap.Bll.Dto.Request;
using OneCap.Bll.Dto.Result;
using OneCap.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OneCap.Bll.Services
{
    public interface ICourseService : IServiceBase
    {
        Task<CourseDto> GetCourseByIdAsync(int id, CancellationToken ct);
        Task<IEnumerable<CourseDto>> GetCoursesAsync(CancellationToken ct);
        Task<CourseDto> CreateCourseAsync(CreateCourseDto creatCourseDto, CancellationToken ct);
        Task UpdateCourseAsync(int id, UpdateCourseDto updateCourseDto, CancellationToken ct);
    }
}
