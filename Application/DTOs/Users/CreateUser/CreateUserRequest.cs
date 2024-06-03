using Domain.Shared.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Users.CreateUser;

public class CreateUserRequest
{
    [Required]
    public string FullName { get; set; } = null!;


    [Required]
    public DateTime DateOfBirth { get; set; }



    [Required]
    public int Role { get; set; }

}