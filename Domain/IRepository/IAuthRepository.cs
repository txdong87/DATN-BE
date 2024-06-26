﻿using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IAuthRepository : IBaseRepository<User>
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task CreateUserAsync(User user);
        Task<User> LoginAsync(string username, string password);
        Task<string> GetUserRoleAsync(string username);
    }
}
