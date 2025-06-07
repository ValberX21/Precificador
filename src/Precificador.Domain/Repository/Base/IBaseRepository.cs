namespace Precificador.Domain.Repository.Base
{
    public interface IBaseRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AddAsync(T entity);
    }
}