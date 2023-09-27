using PureHaven.Data.IRepositories;
using PureHaven.Data.Repositories;
using PureHaven.Domain.Entities;
using PureHaven.Service.DTOs.Users;
using PureHaven.Service.Exceptions;
using PureHaven.Service.Helpers;
using PureHaven.Service.Interfaces;
using PureHaven.Service.Mapper;

namespace PureHaven.Service.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> userRepository = new Repository<User>();

    public async Task<Response<UserForResultDto>> CreateAsync(UserForCreationDto dto)
    {
        var user = (await this.userRepository.SelectAllAsync())
            .FirstOrDefault(u => u.Email.Equals(dto.Email, StringComparison.OrdinalIgnoreCase));
        if (user is not null)
            throw new PureHavenException(400, "User is already exist");

        var entity = Mapper<User>.Map(dto, new User());
        var result = await userRepository.InsertAsync(entity);

        var mappedUser = Mapper<UserForResultDto>.Map(entity);
        return new Response<UserForResultDto>
        {
            Data = mappedUser
        };
    }

    public async Task<Response<UserForResultDto>> GetByIdAsync(long id)
    {
        var entity = await this.userRepository.SelectByIdAsync(id)
            ?? throw new PureHavenException(404, "User is not found");

        var mappedUser = Mapper<UserForResultDto>.Map(entity);
        return new Response<UserForResultDto>
        {
            Data = mappedUser
        };
    }

    public async Task<Response<bool>> RemoveAsync(long id)
    {
        var entity = await this.userRepository.SelectByIdAsync(id)
            ?? throw new PureHavenException(404, "User is not found");

        return new Response<bool>
        {
            Data = await userRepository.DeleteAsync(id)
        };
    }

    public async Task<Response<List<UserForResultDto>>> SelectAllAsync()
    {
        var entities = await this.userRepository.SelectAllAsync();
        var result = new List<UserForResultDto>();
        foreach (var entity in entities)
        {
            var mappedUser = Mapper<UserForResultDto>.Map(entity);
            result.Add(mappedUser);
        }

        return new Response<List<UserForResultDto>>
        {
            Data = result
        };
    }

    public async Task<Response<UserForResultDto>> UpdateAsync(UserForUpdateDto dto)
    {
        var entity = await this.userRepository.SelectByIdAsync(dto.Id)
            ?? throw new PureHavenException(404, "User is not found");

        Mapper<User>.Map(dto, entity);
        await userRepository.UpdateAsync(entity);
        var result = Mapper<UserForResultDto>.Map(entity);

        return new Response<UserForResultDto>
        {
            Data = result
        };
    }
}
