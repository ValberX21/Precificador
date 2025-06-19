using Precificador.Domain.Entities.Base;
using Precificador.Domain.Filters;

namespace Precificador.Domain.Repository.Base
{
    public interface ICrudRepository<TEntity, TFilter> where TEntity : CrudBase where TFilter : IFilter
    {
        Task<IEnumerable<TEntity>?> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>?> GetByFilterAsync(TFilter filter);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
    }
}