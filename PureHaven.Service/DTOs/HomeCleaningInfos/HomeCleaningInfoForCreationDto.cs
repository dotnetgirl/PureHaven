namespace PureHaven.Service.DTOs.HomeCleaningInfos;
public class HomeCleaningInfoForCreationDto
{
    public long EmployeeId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; } = 2;
}