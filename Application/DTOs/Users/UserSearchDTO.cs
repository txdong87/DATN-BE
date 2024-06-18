using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Users
{
    public class UserSearchDTO
    {
        public string? Username { get; set; }
        public string? Fullname { get; set; }
        public int Take { get; set; } = 10;
        public int Skip { get; set; } = 0;
    }
}
