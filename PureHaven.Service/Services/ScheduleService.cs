using PureHaven.Service.DTOs.Users;
using PureHaven.Service.Interfaces;
namespace PureHaven.Service.Services;
public class ScheduleService : IScheduleService
{
    public Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserForResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserForResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
