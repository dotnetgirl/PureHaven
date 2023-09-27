using PureHaven.Service.DTOs.Users;
using PureHaven.Service.Interfaces.Commons;

namespace PureHaven.Service.Interfaces;

public interface IUserService : IService<UserForCreationDto, UserForUpdateDto, UserForResultDto>
{
}