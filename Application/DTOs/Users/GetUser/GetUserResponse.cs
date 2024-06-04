using Domain.Entities;

namespace Application.DTOs.Users.GetUser;

public class GetUserResponse
{
    public GetUserResponse(User user)
    {
        Id = user.Userld;
        Fullname = user.Fullname;
        RoleId = (int)user.RoleId;
    }

    public Guid Id { get; set; }

    public string Fullname { get; set; }
    public int RoleId { get; set; }

}