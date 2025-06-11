namespace Precificador.Domain.Repository.Base
{
    public interface ICrudRepository<TModel, TFilter>
    {
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(Guid id);
        Task<IEnumerable<TModel>> GetByFilterAsync(TFilter filter);
        Task<bool> AddAsync(TModel entity);
        Task<bool> UpdateAsync(TModel entity);
        Task<bool> DeleteAsync(Guid id);
    }
}