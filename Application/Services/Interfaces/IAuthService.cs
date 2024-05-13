﻿

namespace Application.Services.Interfaces;

public interface IAuthService
{
    Task<string> AuthenticateAsync(string username, string password);
    //Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest requestModel);
    //Task<UserInternalModel?> GetInternalModelByIdAsync(Guid id);
    //Task<Response> ChangePasswordAsync(ChangePasswordRequest requestModel);
    //Task<Response<GetUserResponse>> GetAsync(GetUserRequest request);
    //Task<Response<GetListUsersResponse>> GetListAsync(GetListUsersRequest request);
    //Task<Response<CreateUserResponse>> CreateUserAsync(CreateUserRequest requestModel);
    //Task<Response> DisableUserAsync(DisableUserRequest request);
    //Task<Response> IsAbleToDisableUser(Guid id);
    //Task<Response<GetUserResponse>> EditUserAsync(EditUserRequest requestModel);
}