namespace PureHaven.Service.DTOs.Orders;
public class OrderForUpdateDto
{
    public string UserFullName { get; set; }
    public string Email { get; set; }
    public long EmpoleeId { get; set; }
    public DateTime DayOfCleaning { get; set; }
    public DateTime StartTimeCleaning { get; set; }
    public DateTime EndTimeCleaning { get; set; }
}
