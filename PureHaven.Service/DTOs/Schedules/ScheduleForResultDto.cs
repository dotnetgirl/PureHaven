using PureHaven.Service.DTOs.HomeCleaningInfos;
using PureHaven.Service.DTOs.HomeCleaningInfos;

namespace PureHaven.Service.DTOs.Schedules;
public class ScheduleForResultDto
{
    public long Id { get; set; }
    public long EployeeId { get; set; }
    public long OrderId { get; set; }
    public List<HomeCleaningInfoForCreationDto> HomeCleaningInfo { get; set; }
}