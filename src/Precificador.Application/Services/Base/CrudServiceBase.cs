using Precificador.Application.Model.Base;
using Precificador.Application.Model.Filters;
using Precificador.Domain.Entities.Base;
using Precificador.Domain.Repository.Base;

namespace Precificador.Application.Services.Base
{
    public abstract class CrudServiceBase<TModel, TEntity, TRepository, TFilter> where TModel : ModelBase where TEntity : CrudBase where TRepository : ICrudRepository<TEntity, TFilter> where TFilter : IFilter
    {
        protected readonly TRepository _repository;

        protected CrudServiceBase(TRepository repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return ((IEnumerable<TEntity>)entities).Select(e => ConvertToModel(e));
        }

        public virtual async Task<TModel> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? default : ConvertToModel(entity as TEntity);
        }

        public virtual async Task<IEnumerable<TModel>> GetByFilterAsync(TFilter filter)
        {
            var entities = await GetEntitiesByFilterAsync(filter);
            return entities.Select(e => ConvertToModel(e));
        }

        public virtual async Task<bool> AddAsync(TModel model)
        {
            var entity = ConvertToEntity(model);
            return await _repository.AddAsync(entity);
        }

        public virtual async Task<bool> UpdateAsync(TModel model)
        {
            var entity = await _repository.GetByIdAsync(model.Id);
            
            if (entity == null)
                return false;

            UpdateEntityFromModel(entity, model);
            return await _repository.UpdateAsync(entity);
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            
            if (entity == null)
                return false;

            entity.Ativo = false;
            return await _repository.UpdateAsync(entity);
        }

        protected abstract TEntity ConvertToEntity(TModel model);
        protected abstract TModel ConvertToModel(TEntity entity);
        protected virtual void UpdateEntityFromModel(TEntity entity, TModel model) { }
        protected abstract Task<IEnumerable<TEntity>> GetEntitiesByFilterAsync(TFilter filter);
    }
}