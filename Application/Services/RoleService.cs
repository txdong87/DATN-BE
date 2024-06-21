using Application.DTOs;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllRolesAsync();
            return roles.Select(role => new RoleDto
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName
            });
        }

        public async Task<RoleDto> GetRoleByIdAsync(int id)
        {
            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null)
            {
                return null;
            }

            return new RoleDto
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName
            };
        }

        public async Task<int> CreateRoleAsync(RoleDto roleDto)
        {
            var role = new Role
            {
                RoleName = roleDto.RoleName
            };

            await _roleRepository.CreateRoleAsync(role);
            return role.RoleId;
        }

        public async Task UpdateRoleAsync(int id, RoleDto roleDto)
        {
            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null)
            {
                // Handle the case when the role doesn't exist
                return;
            }

            role.RoleName = roleDto.RoleName;
            await _roleRepository.UpdateRoleAsync(role);
        }

        public async Task DeleteRoleAsync(int id)
        {
            await _roleRepository.DeleteRoleAsync(id);
        }
    }
}
