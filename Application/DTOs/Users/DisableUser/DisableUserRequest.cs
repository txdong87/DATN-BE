﻿using System.ComponentModel.DataAnnotations;
using Domain.Shared.Enums;

namespace Application.DTOs.Users.DisableUser;

public class DisableUserRequest
{
    [Required]
    public int Id { get; set; }

}