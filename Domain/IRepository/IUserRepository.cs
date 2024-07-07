using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IUserRepository
    {

        Task<User> GetUserByUsernameAsync(int userId);
        Task<User> GetUserByIdAsync(int userId);
        Task DeleteAsync(int id);
        Task<IEnumerable<User>> SearchAsync(string username, string fullname, int take, int skip);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
