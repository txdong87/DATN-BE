using Domain.Entities;
using Domain.Shared.Enums;

namespace Application.Common.Models;

public class UserInternalModel
{
    public UserInternalModel(User user)
    {
        Id = user.Userld;
        Username = user.user;
        Role = user.Role;
    }

    public Guid Id { get; }

    public string Username { get; }

    public Role Role { get; }

}