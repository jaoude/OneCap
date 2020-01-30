﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OneCap.Bll.Dto.Request;
using OneCap.Bll.Dto.Result;
using OneCap.Bll.Models;
using OneCap.Bll.Services;
using OneCap.Dal.Entities;
using System;
using System.Collections.Generic;
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

        [HttpPost("roles")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto model, CancellationToken ct)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole() { Name = model.RoleName });

            if (result.Succeeded)
            {
                var roleToReturn = _roleManager.Roles.FirstOrDefault(c => c.Name == model.RoleName);
                RoleDto roleToRetunDto = new RoleDto() 
                { 
                    Id = roleToReturn.Id, 
                    Name = roleToReturn.Name, 
                    NormalizedName = roleToReturn.NormalizedName, 
                    ConcurrencyStamp = roleToReturn.ConcurrencyStamp 
                };

                return CreatedAtRoute("GetRole", new { id = roleToRetunDto.Id }, roleToRetunDto);
            }

            return BadRequest(result.Errors);
        }

        [HttpGet("roles/{id}", Name = "GetRole")]
        public async Task<IActionResult> GetRoleById([FromRoute]string id, CancellationToken ct)
        {
            var Role = await _administrationService.GetRoleAsync(id, ct);

            if (Role == null)
                return NotFound();

            return Ok(Role);
        }

        [HttpGet("roles")]
        public IActionResult GetRoles(CancellationToken ct)
        {
            var Roles = _administrationService.GetRoles(ct);

            if (Roles == null)
                return NotFound();

            return Ok(Roles);
        }

        [HttpPost("userclaims")]
        public async Task<IActionResult> ManageUserClaims([FromBody] UserClaimsDto model, CancellationToken ct)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            // test ab#2

            if (user == null)
            {
                return NotFound();
            }

            var existingClaims = await _userManager.GetClaimsAsync(user);
            var result = await _userManager.RemoveClaimsAsync(user, existingClaims);

            if (!result.Succeeded)
                return BadRequest(); // TDOD Bad request is not the best returned error 

            var claims = model.Claims.Select(c => new Claim(c.ClaimType, c.ClaimType));

            result = await _userManager.AddClaimsAsync(user, claims);
            if (!result.Succeeded)
                return BadRequest(); // TDOD Bad request is not the best returned error 

            return CreatedAtRoute("GetUserClaims", new { id = model.UserId }, model);
        }

        [HttpGet("userclaims/{id}", Name = "GetUserClaims")]
        public async Task<IActionResult> GetUserClaims([FromRoute]string id, CancellationToken ct)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var existingClaims = await _userManager.GetClaimsAsync(user);
            var claims = existingClaims.Select(c => new UserClaimDto() { ClaimType = c.Type, IsSelected = true });

            var result = new UserClaimsDto()
            {
                UserId = id,
                Claims = claims.ToList()
            };

            return Ok(result);
        }
    }
}
