using Microsoft.AspNetCore.Identity;
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
    public interface IAdministrationService : IServiceBase
    {
        Task<IdentityResult> CreateRoleAsync(CreateRoleDto model, RoleDto roleToReturn, CancellationToken ct);

        Task<RoleDto> GetRoleAsync(string id, CancellationToken ct);

        List<RoleDto> GetRolesAsync(CancellationToken ct);
    }
}
