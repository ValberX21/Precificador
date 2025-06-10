using Microsoft.Extensions.Logging;
using Precificador.Domain.Entities.Base;
using Precificador.Domain.Repository.Base;
using Precificador.Infrastructure.Data;

namespace Precificador.Infrastructure.Repository.Base
{
    public abstract class CrudRepositoryBase<T>(AppDbContext context, ILogger<T> logger) : ICrudRepository<T> where T : CrudBase
    {
        protected readonly AppDbContext _context = context;
        protected readonly ILogger<T> _logger = logger;

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                entity.Id = Guid.NewGuid();
                entity.DataCriacao = DateTime.Now;
                entity.Ativo = true;
                await _context.Set<T>().AddAsync(entity);
                return await _context.SaveChangesAsync().ContinueWith(t => t.IsCompletedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao inserir {EntityType}", typeof(T).Name);
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await Task.FromResult(_context.Set<T>().AsEnumerable().Where(x => x.Ativo));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os registros de {EntityType}", typeof(T).Name);
                return [];
            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Set<T>().FindAsync(id);
                return result != null && result.Ativo ? result : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar {EntityType} com ID {Id}", typeof(T).Name, id);
                return null;
            }
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

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                entity.DataAlteracao = DateTime.UtcNow;
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