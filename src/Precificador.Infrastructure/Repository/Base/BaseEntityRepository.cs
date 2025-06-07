using Microsoft.Extensions.Logging;
using Precificador.Domain.Entities;
using Precificador.Domain.Repository.Base;
using Precificador.Infrastructure.Data;

namespace Precificador.Infrastructure.Repository.Base
{
    public abstract class BaseEntityRepository<T> : BaseRepository<T>, IBaseEntityRepository<T> where T : BaseEntity
    {
        public BaseEntityRepository(AppDbContext context, ILogger<T> logger) : base(context, logger)
        {
            //
        }

        public async Task<IEnumerable<T>> GetAllByNameAsync(string nome)
        {
            try
            {
                return await Task.FromResult(_context.Set<T>().AsEnumerable().Where(x => x.Nome.Contains(nome)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os registros de {EntityType}", typeof(T).Name);
                return Enumerable.Empty<T>();
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);

                if (entity == null)
                {
                    return false;
                }

                entity.Ativo = false;
                entity.DataAlteracao = DateTime.UtcNow;
                return await UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar {EntityType}", typeof(T).Name);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                return await _context.SaveChangesAsync().ContinueWith(t => t.IsCompletedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar {EntityType}", typeof(T).Name);
                return false;
            }
        }
    }
}