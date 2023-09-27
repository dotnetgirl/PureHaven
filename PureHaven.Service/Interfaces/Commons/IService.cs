using PureHaven.Service.Helpers;

namespace PureHaven.Service.Interfaces.Commons;

public interface IService<TCreate, TUpdate, TResult>
{
    Task<Response<TResult>> CreateAsync(TCreate dto);
    Task<Response<TResult>> UpdateAsync(TUpdate dto);
    Task<Response<bool>> RemoveAsync(long id);
    Task<Response<TResult>> GetByIdAsync(long id);
    Task<Response<List<TResult>>> SelectAllAsync();
}