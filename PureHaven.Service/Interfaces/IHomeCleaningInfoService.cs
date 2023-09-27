using PureHaven.Service.DTOs.HomeCleaningInfos;
using PureHaven.Service.Interfaces.Commons;

namespace PureHaven.Service.Interfaces;

public interface IHomeCleaningInfoService : IService<HomeCleaningInfoForCreationDto, HomeCleaningInfoForUpdateDto, HomeCleaningInfoForResultDto>
{
}