using PureHaven.Service.DTOs.CleaningServices;
namespace PureHaven.Service.DTOs.Schedules;

public class ScheduleForCreationDto
{
    public List<CleaningServiceForCreationDto> Service { get; set; }
}