using PureHaven.Service.DTOs.CleaningServices;

namespace PureHaven.Service.DTOs.Schedules;
public class ScheduleForResultDto
{
    public long Id { get; set; }
    public List<CleaningServiceForResultDto> Service { get; set; }
}