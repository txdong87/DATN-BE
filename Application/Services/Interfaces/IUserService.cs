using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Users.Authentication;
using Application.DTOs.Users.ChangePassword;
using Application.DTOs.Users.GetUser;
using Application.DTOs.Users.GetListUsers;
using Application.DTOs.Users.CreateUser;
using Application.DTOs.Users.EditUser;
using Application.DTOs.Users.DisableUser;
using Application.Common.Models;
using Application.DTOs.Users;
using Domain.Entities;
namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest requestModel);
        //Task<UserInternalModel?> GetInternalModelByIdAsync(Guid id);
        Task<Response> ChangePasswordAsync(ChangePasswordRequest requestModel);
        Task<Response<GetUserResponse>> GetAsync(GetUserRequest request);
        Task<IEnumerable<User>> GetListAsync();
        Task<Response<CreateUserResponse>> CreateUserAsync(CreateUserRequest requestModel);
        Task<Response> DisableUserAsync(DisableUserRequest request);
       
        Task<Response<GetUserResponse>> EditUserAsync(EditUserRequest requestModel);
        Task DeleteUserAsync(int id);
        Task<IEnumerable<UserDTO>> SearchUsersAsync(string username, string fullname, int take, int skip);
        Task<int> checkRole(int userId);
        Task<string> GetDoctorNameAsync(int userId);
    }
}
