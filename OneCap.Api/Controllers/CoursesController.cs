using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OneCap.Bll.Services;

namespace OneCap.Api.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ILogger<CoursesController> _logger;
        private readonly ICourseService _courseService;

        public CoursesController(ILogger<CoursesController> logger, ICourseService courseService)
        {
            _logger = logger;
            _courseService = courseService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCourse(Guid id, CancellationToken ct)
        {
            var courseDto = await _courseService.GetCourseByIdAsync(id, ct);
            
            if (courseDto == null)
                return NotFound();
            
            return Ok(courseDto);
        }

        public async Task<ActionResult> GetCourses(CancellationToken ct)
        {
            var coursesDto = await _courseService.GetCoursesAsync(ct);
            if (coursesDto == null)
                return NotFound();

            return Ok(coursesDto);
        }
    }
}
