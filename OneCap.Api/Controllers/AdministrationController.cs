using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OneCap.Bll.Dto.Request;
using OneCap.Bll.Dto.Result;
using OneCap.Bll.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OneCap.Api.Controllers
{
    [ApiController]
    [Route("api/administration")]
    public class AdministrationController : ControllerBase
    {
        private readonly ILogger<AdministrationController> _logger;
        private readonly IAdministrationService _administrationService;

        public AdministrationController(ILogger<AdministrationController> logger, IAdministrationService administrationService)
        {
            _logger = logger;
            _administrationService = administrationService;
        }

        [HttpPost]
        [Route("roles")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto model, CancellationToken ct)
        {
            RoleDto roleToRetun = null;
            var result = await _administrationService.CreateRoleAsync(model, roleToRetun, ct);

            if (result.Succeeded)
                return CreatedAtRoute("GetRole", new { id = roleToRetun.Id }, roleToRetun);

            return BadRequest(result.Errors); 
        }

        [HttpGet("{id}", Name = "GetRole")]
        [Route("roles")]
        public async Task<IActionResult> GetRole(string id, CancellationToken ct)
        {
            var Role = await _administrationService.GetRoleAsync(id, ct);

            if (Role == null)
                return NotFound();

            return Ok(Role);
        }

        [HttpGet]
        [Route("roles")]
        public  IActionResult GetRoles(CancellationToken ct)
        {
            var Roles = _administrationService.GetRolesAsync(ct);

            if (Roles == null)
                return NotFound();

            return Ok(Roles);
        }
    }
}
