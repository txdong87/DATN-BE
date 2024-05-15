using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
namespace Domain.Entities
{
    public interface IAuthRepository : IBaseRepository<User>
    {
        Task<User> LoginAsync(string username, string password);
        string GenerateJwtToken(User user);
    }
}
