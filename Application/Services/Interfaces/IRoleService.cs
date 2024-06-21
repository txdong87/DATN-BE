using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllRolesAsync();
        Task<RoleDto> GetRoleByIdAsync(int id);
        Task<int> CreateRoleAsync(RoleDto roleDto);
        Task UpdateRoleAsync(int id, RoleDto roleDto);
        Task DeleteRoleAsync(int id);
    }
}
