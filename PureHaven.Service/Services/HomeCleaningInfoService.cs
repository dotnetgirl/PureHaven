using PureHaven.Data.IRepositories;
using PureHaven.Data.Repositories;
using PureHaven.Domain.Entities;
using PureHaven.Service.DTOs.HomeCleaningInfos;
using PureHaven.Service.DTOs.Schedules;
using PureHaven.Service.Exceptions;
using PureHaven.Service.Helpers;
using PureHaven.Service.Interfaces;
using PureHaven.Service.Mapper;
using System.Linq;

namespace PureHaven.Service.Services;

public class HomeCleaningInfoService : IHomeCleaningInfoService
{
    private readonly IRepository<HomeCleaningInfo> homeCleaningInfoRepository = new Repository<HomeCleaningInfo>();

    public async Task<Response<HomeCleaningInfoForResultDto>> CreateAsync(HomeCleaningInfoForCreationDto dto)
    {
        var entity = Mapper<HomeCleaningInfo>.Map(dto, new HomeCleaningInfo());
        await homeCleaningInfoRepository.InsertAsync(entity);

        var result = Mapper<HomeCleaningInfoForResultDto>.Map(entity);
        return new Response<HomeCleaningInfoForResultDto>
        {
            Data = result
        };
    }

    public async Task<Response<HomeCleaningInfoForResultDto>> GetByIdAsync(long id)
    {
        var entity = await this.homeCleaningInfoRepository.SelectByIdAsync(id)
            ?? throw new PureHavenException(404, "HomeCleaningInfo is not found");

        var result = Mapper<HomeCleaningInfoForResultDto>.Map(entity);
        return new Response<HomeCleaningInfoForResultDto>
        {
            Data = result
        };
    }

    public async Task<Response<bool>> RemoveAsync(long id)
    {
        var entity = await this.homeCleaningInfoRepository.SelectByIdAsync(id)
            ?? throw new PureHavenException(404, "HomeCleaningInfo is not found");

        return new Response<bool>
        {
            Data = await homeCleaningInfoRepository.DeleteAsync(id)
        };
    }

    public async Task<Response<List<HomeCleaningInfoForResultDto>>> SelectAllAsync()
    {
        var entities = await this.homeCleaningInfoRepository.SelectAllAsync();

        var result = new List<HomeCleaningInfoForResultDto>();
        foreach (var entity in entities)
        {
            var dto = Mapper<HomeCleaningInfoForResultDto>.Map(entity);
            result.Add(dto);
        }

        return new Response<List<HomeCleaningInfoForResultDto>>
        {
            Data = result
        };
    }

    public async Task<Response<List<HomeCleaningInfoForResultDto>>> SelectAllAsyncWithPagination(int page, int pageSize)
    {
        if (page <= 0 || pageSize <= 0)
        {
            throw new ArgumentException("Page number and page size must be greater than 0.");
        }
        var skip = (page - 1) * pageSize;
        var queryableEntities = (await homeCleaningInfoRepository.SelectAllAsync()).AsQueryable();

        var entities = queryableEntities
                        .Skip(skip)
                        .Take(pageSize)
                        .ToList();

        var result = entities.Select(entity => Mapper<HomeCleaningInfoForResultDto>.Map(entity)).ToList();

        return new Response<List<HomeCleaningInfoForResultDto>>
        {
            Data = result
        };
    }

    public async Task<Response<HomeCleaningInfoForResultDto>> UpdateAsync(HomeCleaningInfoForUpdateDto dto)
    {
        var entity = await this.homeCleaningInfoRepository.SelectByIdAsync(dto.Id)
            ?? throw new PureHavenException(404, "HomeCleaningInfo is not found");

        Mapper<HomeCleaningInfo>.Map(dto, entity);
        await homeCleaningInfoRepository.UpdateAsync(entity);
        var result = Mapper<HomeCleaningInfoForResultDto>.Map(entity);

        return new Response<HomeCleaningInfoForResultDto>
        {
            Data = result
        };
    }
}
