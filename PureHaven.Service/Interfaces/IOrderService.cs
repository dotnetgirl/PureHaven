using PureHaven.Service.DTOs.Orders;
using PureHaven.Service.Interfaces.Commons;

namespace PureHaven.Service.Interfaces;

public interface IOrderService : IService<OrderForCreationDto, OrderForUpdateDto, OrderForResultDto>
{
}
