namespace Precificador.Application.Services.Base
{
    public interface IBaseService<T>
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> AddAsync(T model);
        Task<bool> UpdateAsync(T value);
    }
}