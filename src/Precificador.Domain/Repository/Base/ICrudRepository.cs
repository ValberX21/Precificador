namespace Precificador.Domain.Repository.Base
{
    public interface ICrudRepository<TModel, TFilter>
    {
        Task<TModel> GetByIdAsync(Guid id);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<bool> AddAsync(TModel entity);
        Task<bool> UpdateAsync(TModel entity);
        Task<IEnumerable<TModel>> GetByFilterAsync(TFilter filter);
    }
}