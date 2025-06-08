using Microsoft.Extensions.Logging;
using Precificador.Domain.Entities.Base;
using Precificador.Domain.Repository.Base;
using Precificador.Infrastructure.Data;

namespace Precificador.Infrastructure.Repository.Base
{
    public abstract class BaseEntityRepository<T>(AppDbContext context, ILogger<T> logger) : BaseRepository<T>(context, logger), IBaseEntityRepository<T> where T : BaseEntity
    {
        public new async Task<bool> AddAsync(T entity)
        {
            entity.Id = Guid.NewGuid();
            entity.DataCriacao = DateTime.Now;
            entity.Ativo = true;
            return await base.AddAsync(entity);
        }

        public new async Task<IEnumerable<T>> GetAllAsync()
        {
            var allEntities = await base.GetAllAsync();
            return allEntities.Where(x => x.Ativo);
        }

        public new async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await base.GetByIdAsync(id);
            return entity != null && entity.Ativo ? entity : null;
        }

        public async Task<IEnumerable<T>> GetAllByNameAsync(string nome)
        {
            try
            {
                return await Task.FromResult(_context.Set<T>().AsEnumerable().Where(x => x.Nome.Contains(nome) && x.Ativo));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os registros de {EntityType}", typeof(T).Name);
                return [];
            }
        }

        public new async Task<bool> UpdateAsync(T entity)
        {
            entity.DataAlteracao = DateTime.UtcNow;
            return await base.UpdateAsync(entity);
        }
    }
}