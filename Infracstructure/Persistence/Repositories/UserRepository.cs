using Domain.Entities;
using Domain.IRepository;
using Infracstructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRepository :  IUserRepository
    {
        private readonly datnContext _context;

        public UserRepository(datnContext context)
        {
            _context = context;
        }


        public async Task<User> GetUserByUsernameAsync(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Userld == userId);
        }
    }
}
