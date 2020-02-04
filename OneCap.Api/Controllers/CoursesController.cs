using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OneCap.Bll.Dto.Request;
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

        [HttpGet("{id}", Name = "GetCourse")]
        public async Task<ActionResult> GetCourse(int id, CancellationToken ct)
        {
            var courseDto = await _courseService.GetCourseByIdAsync(id, ct);

            if (courseDto == null)
                return NotFound();

            return Ok(courseDto);
        }

        [HttpGet]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        //[Authorize(Roles = "User")]
        public async Task<ActionResult> GetCourses(CancellationToken ct)
        {
            var coursesDto = await _courseService.GetCoursesAsync(ct);
            if (coursesDto == null)
                return NotFound();

            return Ok(coursesDto);
        }

        [HttpPost]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> CreateCourse([FromBody] CreateCourseDto createCourseDto, CancellationToken ct)
        {
            if (createCourseDto == null)
                return BadRequest();

            var courseToReturn = await _courseService.CreateCourseAsync(createCourseDto, ct);

            if (courseToReturn == null)
                throw new Exception("Creating a course failed on save.");


            return CreatedAtRoute("GetCourse", new { id = courseToReturn.Id }, courseToReturn);
        }

        [HttpPut("{id}")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> UpdateCourse(int id, [FromBody] UpdateCourseDto updateCourseDto, CancellationToken ct)
        {
            if (updateCourseDto == null)
                return BadRequest();

            await _courseService.UpdateCourseAsync(id, updateCourseDto, ct);

            return NoContent();
        }
    }
}
