using Precificador.Application.Model.Filters;

namespace Precificador.Application.Services.Base
{
    public class CrudServiceBase<TModel, TEntity, TRepository, TFilter> where TRepository : class where TFilter : IFilter
    {
        protected readonly TRepository _repository;

        protected CrudServiceBase(TRepository repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            // Aqui você deve implementar a conversão entre entidade e modelo.
            // Exemplo genérico:
            var entities = await ((dynamic)_repository).GetAllAsync();
            return ((IEnumerable<TEntity>)entities).Select(e => ConvertToModel(e));
        }

        public virtual async Task<TModel> GetByIdAsync(Guid id)
        {
            var entity = await ((dynamic)_repository).GetByIdAsync(id);
            return entity == null ? default : ConvertToModel((TEntity)entity);
        }

        public virtual async Task<IEnumerable<TModel>> GetAllByNameAsync(string nome)
        {
            var entities = await ((dynamic)_repository).GetAllByNameAsync(nome);
            return ((IEnumerable<TEntity>)entities).Select(e => ConvertToModel(e));
        }

        public virtual async Task<bool> AddAsync(TModel model)
        {
            var entity = ConvertToEntity(model);
            return await ((dynamic)_repository).AddAsync(entity);
        }

        public virtual async Task<bool> UpdateAsync(TModel model)
        {
            var entity = await ((dynamic)_repository).GetByIdAsync((Guid)model.GetType().GetProperty("Id").GetValue(model));
            if (entity == null)
                return false;

            UpdateEntityFromModel(entity, model);
            return await ((dynamic)_repository).UpdateAsync(entity);
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await ((dynamic)_repository).GetByIdAsync(id);
            if (entity == null)
                return false;

            ((dynamic)entity).Ativo = false;
            return await ((dynamic)_repository).UpdateAsync(entity);
        }
        public virtual async Task<IEnumerable<TModel>> GetByFilterAsync(TFilter filter)
        {
            var entities = await GetEntitiesByFilterAsync(filter);
            return entities.Select(e => ConvertToModel(e));
        }

        protected abstract TEntity ConvertToEntity(TModel model);
        protected abstract TModel ConvertToModel(TEntity entity);
        protected virtual void UpdateEntityFromModel(TEntity entity, TModel model) { }
        protected abstract Task<IEnumerable<TEntity>> GetEntitiesByFilterAsync(TFilter filter);
    }
}