using PureHaven.Domain.Enums;
using System.ComponentModel.DataAnnotations;
namespace PureHaven.Service.DTOs.Users;

public class UserForCreationDto
{
    [MinLength(3), MaxLength(50)]
    [Required(ErrorMessage = "Enter the FirstName")]
    public string FirstName { get; set; }
    [MinLength(3), MaxLength(50)]
    [Required(ErrorMessage = "Enter the LastName")]
    public string LastName { get; set; }
    [EmailAddress(ErrorMessage = "Enter properly")]
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
}
