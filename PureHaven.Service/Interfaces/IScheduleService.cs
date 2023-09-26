using PureHaven.Service.DTOs.Users;
namespace PureHaven.Service.Interfaces;
public interface IScheduleService
{
    public Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
    public Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto);
    public Task<bool> RemoveAsync(long id);
    public Task<UserForResultDto> GetByIdAsync(long id);
    public Task<List<UserForResultDto>> GetAllAsync();
}