using Precificador.Application.Model.Base;
using Precificador.Application.Model.Filters;
using Precificador.Domain.Entities.Base;
using Precificador.Domain.Repository.Base;

namespace Precificador.Application.Services.Base
{
    public interface ICrudService<TModel, TEntity, TRepository, TFilter> where TModel : ModelBase where TEntity : CrudBase where TRepository : ICrudRepository<TEntity, TFilter> where TFilter : IFilter
    {
        Task<IList<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(Guid id);
        Task<IEnumerable<TModel>> GetByFilterAsync(TFilter filter);
        Task<bool> AddAsync(TModel model);
        Task<bool> UpdateAsync(TModel value);
        Task<bool> DeleteAsync(Guid id);
    }
}