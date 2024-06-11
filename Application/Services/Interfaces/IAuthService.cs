using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<string?> AuthenticateAsync(string username, string password);
        Task RegisterUserAsync(string username, string password, int roleId,string fullname);
        Task<string> GetUserRoleAsync(string username);
    }
}
