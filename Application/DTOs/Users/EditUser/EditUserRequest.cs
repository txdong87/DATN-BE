using Domain.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Users.EditUser
{
    public class EditUserRequest
    {
        [Required]
        public int UserId { get; set; }
        public int RoleId { get; set; }




    }
}
