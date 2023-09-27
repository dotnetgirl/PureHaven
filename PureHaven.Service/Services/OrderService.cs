using PureHaven.Data.IRepositories;
using PureHaven.Data.Repositories;
using PureHaven.Domain.Entities;
using PureHaven.Service.DTOs.Orders;
using PureHaven.Service.Exceptions;
using PureHaven.Service.Helpers;
using PureHaven.Service.Interfaces;
using PureHaven.Service.Mapper;

namespace PureHaven.Service.Services;

public class OrderService : IOrderService
{
    private readonly IRepository<Order> orderRepository = new Repository<Order>();

    public async Task<Response<OrderForResultDto>> CreateAsync(OrderForCreationDto dto)
    {
        var existEntity = (await this.orderRepository.SelectAllAsync())
            .FirstOrDefault(u => u.Email.Equals(dto.Email, StringComparison.OrdinalIgnoreCase)
            && u.EmpoleeId == dto.EmpoleeId);

        if (existEntity is not null)
            throw new PureHavenException(403, "This order is already exist");

        var entity = Mapper<Order>.Map(dto, new Order());
        var result = await orderRepository.InsertAsync(entity);

        var mappedOrder = Mapper<OrderForResultDto>.Map(entity);
        return new Response<OrderForResultDto>
        {
            Data = mappedOrder
        };
    }

    public async Task<Response<OrderForResultDto>> GetByIdAsync(long id)
    {
        var entity = await this.orderRepository.SelectByIdAsync(id)
            ?? throw new PureHavenException(404, "This order is not found");

        var mappedOrder = Mapper<OrderForResultDto>.Map(entity);
        return new Response<OrderForResultDto>
        {
            Data = mappedOrder
        };
    }

    public async Task<Response<bool>> RemoveAsync(long id)
    {
        var entity = await this.orderRepository.SelectByIdAsync(id)
            ?? throw new PureHavenException(404, "This order is not found");

        return new Response<bool>
        {
            Data = await orderRepository.DeleteAsync(id)
        };
    }

    public async Task<Response<List<OrderForResultDto>>> SelectAllAsync()
    {
        var entities = await this.orderRepository.SelectAllAsync();
        var result = new List<OrderForResultDto>();
        foreach (var entity in entities)
        {
            var mappedOrder = Mapper<OrderForResultDto>.Map(entity);
            result.Add(mappedOrder);
        }

        return new Response<List<OrderForResultDto>>
        {
            Data = result
        };
    }

    public async Task<Response<OrderForResultDto>> UpdateAsync(OrderForUpdateDto dto)
    {
        var entity = await this.orderRepository.SelectByIdAsync(dto.Id)
            ?? throw new PureHavenException(404, "order is not found");

        Mapper<Order>.Map(dto, entity);
        await orderRepository.UpdateAsync(entity);
        var result = Mapper<OrderForResultDto>.Map(entity);

        return new Response<OrderForResultDto>
        {
            Data = result
        };
    }
}
