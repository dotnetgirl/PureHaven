using PureHaven.Domain.Enums;

namespace PureHaven.Service.DTOs.Users;

public class UserForUpdateDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
}
