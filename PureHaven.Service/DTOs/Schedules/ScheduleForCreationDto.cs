using PureHaven.Service.DTOs.HomeCleaningInfos;
namespace PureHaven.Service.DTOs.Schedules;

public class ScheduleForCreationDto
{
    public long EployeeId { get; set; }
    public long OrderId { get; set; }
    public List<HomeCleaningInfoForCreationDto> HomeCleaningInfo { get; set; }
}