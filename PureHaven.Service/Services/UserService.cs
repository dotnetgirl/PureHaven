using PureHaven.Domain.Entities;
using PureHaven.Service.DTOs.Users;
using PureHaven.Service.Interfaces;
using PureHaven.Data.Repositories;
using PureHaven.Data.IRepositories;
using PureHaven.Service.Exceptions;

namespace PureHaven.Service.Services;
public class UserService : IUserService
{
    private readonly IRepository<User> userRepository = new Repository<User>();
    public async Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
    {
        var user = (await this.userRepository.SelectAllAsync()).FirstOrDefault(u => u.Email.ToLower() == dto.Email.ToLower());
        if (user is not null)
            throw new PureHavenException(400, "User is already exist");

        var person = new User()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = dto.Password,
            PhoneNumber = dto.PhoneNumber,
            CreatedAt = DateTime.UtcNow
        };

        var result = await userRepository.InsertAsync(user);

        var mappedUser = new UserForResultDto()
        {
            Id = result.Id,
            FirstName = result.FirstName,
            LastName = result.LastName,
            Role = result.Role,
        };

        return mappedUser;
    }

    public async Task<List<UserForResultDto>> GetAllAsync()
    {
        var users = await this.userRepository.SelectAllAsync();
        var result = new List<UserForResultDto>();

        foreach (var user in users)
        {
            var mappedUser = new UserForResultDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
            };
            result.Add(mappedUser);
        }

        return result;
    }

    public async Task<UserForResultDto> GetByIdAsync(long id)
    {
        var user = await this.userRepository.SelectByIdAsync(id);
        if (user is null)
            throw new PureHavenException(404, "User is not found");

        var mappedUser = new UserForResultDto()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Role = user.Role,
        };

        return mappedUser;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await this.userRepository.SelectByIdAsync(id);
        if (user is null)
            throw new PureHavenException(404, "User is not found");

        return await this.userRepository.DeleteAsync(id);
    }

    public async Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto)
    {
        var user = await this.userRepository.SelectByIdAsync(dto.Id);
        if (user is null)
            throw new PureHavenException(404, "User is not found");

        var mappedUser = new User()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            UpdatedAt = DateTime.UtcNow,
            Role = dto.Role,
        };
        await this.userRepository.UpdateAsync(mappedUser);

        var result = new UserForResultDto()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Role = dto.Role
        };
        return result;
    }
}
