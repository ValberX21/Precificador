using Microsoft.Extensions.Logging;
using Precificador.Domain.Repository.Base;
using Precificador.Infrastructure.Data;

namespace Precificador.Infrastructure.Repository.Base
{
    public abstract class BaseRepository<T>(AppDbContext context, ILogger<T> logger) : IBaseRepository<T> where T : class
    {
        protected readonly AppDbContext _context = context;
        protected readonly ILogger<T> _logger = logger;

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
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
                return await Task.FromResult(_context.Set<T>().AsEnumerable());
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
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar {EntityType} com ID {Id}", typeof(T).Name, id);
                return null;
            }
        }
    }
}