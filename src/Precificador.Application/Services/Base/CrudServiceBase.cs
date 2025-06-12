using Precificador.Application.Model.Base;
using Precificador.Domain.Entities.Base;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository.Base;

namespace Precificador.Application.Services.Base
{
    public abstract class CrudServiceBase<TModel, TEntity, TFilter, TRepository>(TRepository repository) where TModel : ModelBase where TEntity : CrudBase where TFilter : IFilter where TRepository : ICrudRepository<TEntity, TFilter>
    {
        protected readonly TRepository _repository = repository;

        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return (IEnumerable<TEntity>?)await _repository.GetAllAsync() == null ? [] : ConvertToModel(await _repository.GetAllAsync());
        }

        public virtual async Task<TModel?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : ConvertToModel(entity as TEntity);
        }

        public virtual async Task<IEnumerable<TModel>> GetByFilterAsync(TFilter filter)
        {
            var entities = await GetEntitiesByFilterAsync(filter);
            return entities == null ? [] : ConvertToModel(entities);
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

        public virtual IEnumerable<TModel> ConvertToModel(IEnumerable<TEntity> entity)
        {
            return entity?.Select(e => ConvertToModel(e))?.ToList() ?? [];
        }

        protected abstract TEntity ConvertToEntity(TModel model);
        protected abstract TModel ConvertToModel(TEntity entity);
        protected abstract void UpdateEntityFromModel(TEntity entity, TModel model);
        protected abstract Task<IEnumerable<TEntity>> GetEntitiesByFilterAsync(TFilter filter);
    }
}