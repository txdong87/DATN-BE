using Domain.Shared.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Users.CreateUser;

public class CreateUserRequest
{
    public string User { get; set; }

    public string Password { get; set; }
    public string FullName { get; set; }
    public int RoleId { get; set; }

}