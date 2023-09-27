using PureHaven.Data.IRepositories;
using PureHaven.Data.Repositories;
using PureHaven.Domain.Entities;
using PureHaven.Service.DTOs.Schedules;
using PureHaven.Service.Exceptions;
using PureHaven.Service.Helpers;
using PureHaven.Service.Interfaces;
using PureHaven.Service.Mapper;

namespace PureHaven.Service.Services;

public class ScheduleService : IScheduleService
{
    private readonly IRepository<Schedule> ScheduleRepository = new Repository<Schedule>();

    public async Task<Response<ScheduleForResultDto>> CreateAsync(ScheduleForCreationDto dto)
    {
        var entity = Mapper<Schedule>.Map(dto, new Schedule());
        await ScheduleRepository.InsertAsync(entity);

        var mappedSchedule = Mapper<ScheduleForResultDto>.Map(entity);
        return new Response<ScheduleForResultDto>
        {
            Data = mappedSchedule
        };
    }

    public async Task<Response<ScheduleForResultDto>> GetByIdAsync(long id)
    {
        var entity = await this.ScheduleRepository.SelectByIdAsync(id)
            ?? throw new PureHavenException(404, "Schedule is not found");

        var mappedSchedule = Mapper<ScheduleForResultDto>.Map(entity);
        return new Response<ScheduleForResultDto>
        {
            Data = mappedSchedule
        };
    }

    public async Task<Response<bool>> RemoveAsync(long id)
    {
        var entity = await this.ScheduleRepository.SelectByIdAsync(id)
            ?? throw new PureHavenException(404, "Schedule is not found");

        return new Response<bool>
        {
            Data = await ScheduleRepository.DeleteAsync(id)
        };
    }

    public async Task<Response<List<ScheduleForResultDto>>> SelectAllAsync()
    {
        var entities = await this.ScheduleRepository.SelectAllAsync();
        var result = new List<ScheduleForResultDto>();
        foreach (var entity in entities)
        {
            var mappedSchedule = Mapper<ScheduleForResultDto>.Map(entity);
            result.Add(mappedSchedule);
        }

        return new Response<List<ScheduleForResultDto>>
        {
            Data = result
        };
    }

    public async Task<Response<ScheduleForResultDto>> UpdateAsync(ScheduleForUpdateDto dto)
    {
        var entity = await this.ScheduleRepository.SelectByIdAsync(dto.Id)
            ?? throw new PureHavenException(404, "Schedule is not found");

        Mapper<Schedule>.Map(dto, entity);
        await ScheduleRepository.UpdateAsync(entity);
        var result = Mapper<ScheduleForResultDto>.Map(entity);

        return new Response<ScheduleForResultDto>
        {
            Data = result
        };
    }
}
