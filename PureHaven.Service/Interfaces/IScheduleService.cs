using PureHaven.Service.DTOs.Schedules;
using PureHaven.Service.Interfaces.Commons;

namespace PureHaven.Service.Interfaces;

public interface IScheduleService : IService<ScheduleForCreationDto, ScheduleForUpdateDto, ScheduleForResultDto>
{
}