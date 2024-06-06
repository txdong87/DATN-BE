using Domain.Entities;
using Domain.Shared.Enums;

namespace Application.Common.Models;

public class UserInternalModel
{
    public UserInternalModel(User user)
    {
        Id = user.UserId;
        Username = user.user;
        Role = user.Role;
    }

    public int Id { get; }

    public string Username { get; }

    public Role Role { get; }

}