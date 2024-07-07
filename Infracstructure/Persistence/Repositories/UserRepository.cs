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
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }
        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<IEnumerable<User>> SearchAsync(string username, string fullname, int take, int skip)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(username))
            {
                query = query.Where(u => u.user.Contains(username));
            }

            if (!string.IsNullOrEmpty(fullname))
            {
                query = query.Where(u => u.Fullname.Contains(fullname));
            }

            return await query.OrderBy(u => u.UserId).Skip(skip).Take(take).ToListAsync();
        }
    }
}
