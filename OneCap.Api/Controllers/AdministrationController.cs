using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OneCap.Bll.Dto.Request;
using OneCap.Bll.Dto.Result;
using OneCap.Bll.Models;
using OneCap.Bll.Services;
using OneCap.Dal.Entities;
using System;
using System.Linq;
using System.Security.Claims;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministrationController(ILogger<AdministrationController> logger, 
            IAdministrationService administrationService, 
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _administrationService = administrationService;
            _userManager = userManager;
            _roleManager = roleManager;
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
            var Roles = _administrationService.GetRoles(ct);

            if (Roles == null)
                return NotFound();

            return Ok(Roles);
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserClaims(string userId, CancellationToken ct)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var existingUserClaims = await _userManager.GetClaimsAsync(user);

            var model = new UserClaimsDto()
            {
                UserId = userId
            };

            foreach (Claim claim in ClaimStore.AllClaims)
            {
                UserClaimDto userClaim = new UserClaimDto()
                {
                    ClaimType = claim.Type
                };

                if (existingUserClaims.Any(c => c.Type == claim.Type))
                {
                    userClaim.IsSelected = true;
                }

                model.Claims.Add(userClaim);
            }

            return Ok(model);
        }
    }
}
