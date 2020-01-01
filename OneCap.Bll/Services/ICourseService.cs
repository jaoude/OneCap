using OneCap.Bll.Dto.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OneCap.Bll.Services
{
    public interface ICourseService : IServiceBase
    {
        Task<CourseDto> GetCourseByIdAsync(Guid id, CancellationToken ct);
    }
}
