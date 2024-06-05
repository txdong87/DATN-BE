using Domain.Entities;

namespace Application.DTOs.Users.CreateUser;

public class CreateUserResponse
{
    public CreateUserResponse(User user)
    {
        Userld = user.Userld;
        Username = user.user;
        Fullname = user.Fullname;
        RoleId = user.RoleId;
    }

    public int Userld { get; set; }
    public string? Username { get; set; }
    public string? Fullname { get; set; }
    public int? RoleId { get; set; }
}
