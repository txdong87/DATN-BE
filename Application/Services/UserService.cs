﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Infrastructure.Persistence.Interfaces;
using Application.Services.Interfaces;
using Application.DTOs.Users.Authentication;
using Application.DTOs.Users.ChangePassword;
using Application.DTOs.Users.GetUser;
using Application.DTOs.Users.GetListUsers;
using Application.DTOs.Users.CreateUser;
using Application.DTOs.Users.DisableUser;
using Application.DTOs.Users.EditUser;
using Domain.Entities;
using Domain.Shared.Helpers;
using Domain.Shared.Constants;
using Application.Helpers;
using Domain.Shared.Enums;
using Application.Common.Models;
using Domain.IRepository;
using Application.DTOs.Users;
using Infrastructure.Persistence.Repositories;

namespace Application.Services.Interfaces;



public class UserService : BaseService, IUserService

{
    private readonly IUserRepository _userRepository;
    public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository) : base(unitOfWork)
    {
        _userRepository = userRepository;
    }

    public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest requestModel)
    {
        var userRepository = UnitOfWork.AsyncRepository<User>();

        var user = await userRepository.GetAsync(u =>u.user == requestModel.Username);

        if (user == null ||
            !HashStringHelper.IsValid(requestModel.Password, user.Password))
        {
            return new Response<AuthenticationResponse>(false, ErrorMessages.LoginFailed);
        }

        var token = JwtHelper.GenerateJwtToken(user);
        var authenticationResponse = new AuthenticationResponse(user, token);

        return new Response<AuthenticationResponse>(true, authenticationResponse);
    }

    public async Task<Response> ChangePasswordAsync(ChangePasswordRequest requestModel)
    {
        if (requestModel.UserId == null)
        {
            return new Response(false, ErrorMessages.BadRequest);
        }

        var userRepository = UnitOfWork.AsyncRepository<User>();

        var user = await userRepository.GetAsync(u => u.UserId == requestModel.UserId);

        if (user == null)
        {
            return new Response(false, ErrorMessages.BadRequest);
        }

        if (!HashStringHelper.IsValid(requestModel.OldPassword, user.Password))
        {
            return new Response(false, ErrorMessages.WrongOldPassword);
        }

        if (HashStringHelper.IsValid(requestModel.NewPassword, user.Password))
        {
            return new Response(false, ErrorMessages.MatchingOldAndNewPassword);
        }

        user.Password = HashStringHelper.HashString(requestModel.NewPassword);

        

        await userRepository.UpdateAsync(user);
        await UnitOfWork.SaveChangesAsync();

        return new Response(true, Messages.ActionSuccess);
    }

    public async Task<Response<CreateUserResponse>> CreateUserAsync(CreateUserRequest requestModel)
    {
        var userRepository = UnitOfWork.AsyncRepository<User>();

        if (requestModel == null)
        {
            return new Response<CreateUserResponse>(false, ErrorMessages.BadRequest);
        }

        

        var validUserList = await userRepository.ListAsync();


        var sameUserNameCount = validUserList
                                    .Count(u => UserNameHelper.CheckValidUserName(requestModel.FullName, u.Fullname));

     

        var newPassword = BCrypt.Net.BCrypt.HashPassword(requestModel.Password);

        var user = new User
        {
            Fullname = requestModel.FullName,
            user= requestModel.User,
            Password = newPassword,
            RoleId = requestModel.RoleId,
        };

        var responseModel = new CreateUserResponse(user);

        await userRepository.AddAsync(user);
        await UnitOfWork.SaveChangesAsync();

        return new Response<CreateUserResponse>(true, Messages.ActionSuccess, responseModel);
    }

    //public async Task<UserInternalModel?> GetInternalModelByIdAsync(Guid id)
    //{
    //    var userRepository = UnitOfWork.AsyncRepository<User>();

    //    var user = await userRepository.GetAsync(u => !u.IsDeleted && u.Id == id);

    //    if (user == null)
    //    {
    //        return null;
    //    }

    //    return new UserInternalModel(user);
    //}

    public async Task<Response<GetUserResponse>> GetAsync(GetUserRequest request)
    {
        var userRepository = UnitOfWork.AsyncRepository<User>();

        var user = await userRepository.GetAsync(u => u.UserId == request.Id);

        if (user == null)
        {
            return new Response<GetUserResponse>(false, ErrorMessages.NotFound);
        }

        var getUserDto = new GetUserResponse(user);

        return new Response<GetUserResponse>(true, getUserDto);
    }

    public async Task<IEnumerable<UserDTO>> GetListAsync()

    {
        var users = await _userRepository.GetAllUsersAsync();
        return users.Select(user => new UserDTO
        {
            UserId = user.UserId,
            Username=user.user,
            Fullname=user.Fullname,
            RoleId=user.RoleId
        }).ToList();
    }

    public async Task<Response> IsAbleToDisableUser(int id)
    {
        var hasValidAssignment = await HasValidAssignment(id);

        if (hasValidAssignment)
        {
            return new Response(false, ErrorMessages.CannotDisableUser);
        }

        return new Response(true, Messages.CanDisableUser);
    }

    public async Task<Response> DisableUserAsync(DisableUserRequest request)
    {
        var userRepository = UnitOfWork.AsyncRepository<User>();

        var user = await userRepository.GetAsync(u =>u.UserId == request.Id );

        if (user == null)
        {
            return new Response(false, ErrorMessages.NotFound);
        }

        var hasValidAssignment = await HasValidAssignment(request.Id);

        if (hasValidAssignment)
        {
            return new Response(false, ErrorMessages.CannotDisableUser);
        }


        await userRepository.UpdateAsync(user);
        await UnitOfWork.SaveChangesAsync();

        return new Response(true, Messages.ActionSuccess);
    }

    public async Task<Response<GetUserResponse>> EditUserAsync(EditUserRequest requestModel)
    {
        var userRepository = UnitOfWork.AsyncRepository<User>();

        var user = await userRepository.GetAsync(u =>  u.UserId == requestModel.UserId);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
        if (user == null)
        {
            return new Response<GetUserResponse>(false, ErrorMessages.NotFound);
        }

        user.RoleId = requestModel.RoleId;

        await userRepository.UpdateAsync(user);
        await UnitOfWork.SaveChangesAsync();

        return new Response<GetUserResponse>(true, "Success", new GetUserResponse(user));
    }
    public async Task DeleteUserAsync(int id)
    {
        await _userRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<UserDTO>> SearchUsersAsync(string username, string fullname, int take, int skip)
    {
        if (take == 0) take = 10; // Default take value if it's zero

        var users = await _userRepository.SearchAsync(username, fullname, take, skip);
        return users.Select(user => new UserDTO
        {
            UserId = user.UserId,
            Username = user.user,
            Fullname = user.Fullname,
            Password = user.Password,
            RoleId = user.RoleId
        }).ToList();
    }
    private async Task<bool> HasValidAssignment(int userId)
    {
        var userRepository = UnitOfWork.AsyncRepository<User>();

        var user = await userRepository.ListAsync(a => a.UserId == userId);

        return user.Any();
    }
    public async Task<int> checkRole(int userId)
    {
        var user = await _userRepository.GetUserByUsernameAsync(userId);

        return user?.RoleId ?? -1;
    }
    public async Task<string> GetDoctorNameAsync(int userId)
    {
        var user = await _userRepository.GetUserByUsernameAsync(userId);
        return user?.Fullname;
    }

}
