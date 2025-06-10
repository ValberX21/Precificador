namespace Precificador.Application.Services.Base
{
    public interface ICrudService<TModel, TEntity, TRepository, TFilter>
    {
        Task<IList<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(Guid id);
        Task<bool> AddAsync(TModel model);
        Task<bool> UpdateAsync(TModel value);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<TModel>> GetByFilterAsync(TFilter filter);
    }
}