using System.ComponentModel.DataAnnotations;

namespace PureHaven.Service.DTOs.Orders;
public class OrderForCreationDto
{
    [Required(ErrorMessage = "Enter the FullName")]
    public string UserFullName { get; set; }
    [EmailAddress(ErrorMessage = "Enter properly")]
    public string Email { get; set; }
    public long EmpoleeId { get; set; }
    public DateTime DayOfCleaning { get; set; }
    public DateTime StartTimeCleaning { get; set; }
    public DateTime EndTimeCleaning { get; set; }
}