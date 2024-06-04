using Domain.Entities;

namespace Application.DTOs.Users.Authentication;

public class AuthenticationResponse
{
    public AuthenticationResponse(User user, string token)
    {
        Id = user.Userld;
        Username = user.user;
        Role = (int)user.RoleId;
        Token = token;
    }

    public Guid Id { get; set; }

    public string Username { get; set; }

    public int Role { get; set; }

    public string Token { get; set; }

}