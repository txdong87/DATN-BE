using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AuthenDTO
{
    public class RegisterUserDto
    {
        public string User { get; set; }

        public string Password { get; set; }
        public string FullName { get; set; }
        public int RoleId { get; set; }
    }
}
