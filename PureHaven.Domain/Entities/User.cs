using PureHaven.Domain.Commons;
using PureHaven.Domain.Enums;

namespace PureHaven.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
}