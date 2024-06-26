﻿using Domain.Entities;
using Domain.Interfaces;
using Domain.IRepository;
using Infracstructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class AuthRepository : RepositoryBase<User>, IAuthRepository
    {
        private readonly datnContext _context;
        private readonly string _secretKey;
        public AuthRepository(datnContext dbContext, string secretKey) : base(dbContext)
        {
            _context = dbContext;
            _secretKey = secretKey;
        }

        public new async Task<User?> GetAsync(
            Expression<Func<User, bool>>? predicate = null,
            CancellationToken cancellationToken = default)
        {
            var dbSet = predicate == null ? _dbSet : _dbSet.Where(predicate);

            return await dbSet
                .FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            var user = await _dbSet.FirstOrDefaultAsync(u => u.user == username);
            if (user == null)
            {
                Console.WriteLine("User not found");
            }
            else
            {
                Console.WriteLine("lôgigign");
            }
            return user;
        }

        public async Task CreateUserAsync(User user)
        {
            _dbSet.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                                 .Include(u => u.Role) 
                                 .FirstOrDefaultAsync(u => u.user == username);
        }

        public async Task<string> GetUserRoleAsync(string username)
        {
            var user = await GetUserByUsernameAsync(username);
            return user?.Role?.RoleName;  // Truy xuất RoleName từ property RoleName
        }
    }
}
