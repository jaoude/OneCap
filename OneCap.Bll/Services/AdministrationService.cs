using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
    public class AdministrationService : ServiceBase, IAdministrationService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministrationService(IUnitOfWork uow, IMapper mapper, ILogger<AdministrationService> logger, RoleManager<IdentityRole> roleManager) 
            : base(uow, mapper, logger)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateRoleAsync(CreateRoleDto model, RoleDto roleToRetun, CancellationToken ct)
        {
            var IdentityRole = _mapper.Map<IdentityRole>(model);
            var result = await _roleManager.CreateAsync(IdentityRole);
            
            if (result.Succeeded)
                roleToRetun = _mapper.Map<RoleDto>(IdentityRole);

            return result;
        }


        public async Task<RoleDto> GetRoleAsync(string id, CancellationToken ct)
        {
            var IdentityRole = await _roleManager.FindByIdAsync(id);

            if (IdentityRole == null)
                return null;

            return _mapper.Map<RoleDto>(IdentityRole);
        }

        public List<RoleDto> GetRolesAsync(CancellationToken ct)
        {
            var IdentityRoles = _roleManager.Roles;

            if (IdentityRoles == null)
                return null;

            return _mapper.Map<List<RoleDto>>(IdentityRoles);
        }
    }
}
