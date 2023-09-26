using PureHaven.Service.DTOs.CleaningServices;
namespace PureHaven.Service.DTOs.Schedules;

public class ScheduleForUpdateDto
{
    public long Id { get; set; }
    public List<CleaningServiceForUpdateDto> Service { get; set; }
}
