using Microsoft.Extensions.Logging;
using Precificador.Domain.Entities.Base;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository.Base;
using Precificador.Infrastructure.Data;

namespace Precificador.Infrastructure.Repository.Base
{
    public abstract class CrudRepositoryBase<TModel, TFilter>(AppDbContext context, ILogger<TModel> logger) : ICrudRepository<TModel, TFilter> where TModel : CrudBase where TFilter : IFilter
    {
        protected readonly AppDbContext _context = context;
        protected readonly ILogger<TModel> _logger = logger;

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            try
            {
                return await Task.FromResult(_context.Set<TModel>().AsEnumerable().Where(x => x.Ativo));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os registros de {EntityType}", typeof(TModel).Name);
                return [];
            }
        }

        public async Task<TModel> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Set<TModel>().FindAsync(id);
                return result != null && result.Ativo ? result : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar {EntityType} com ID {Id}", typeof(TModel).Name, id);
                return null;
            }
        }


        public async Task<bool> AddAsync(TModel entity)
        {
            try
            {
                entity.Id = Guid.NewGuid();
                entity.DataCriacao = DateTime.Now;
                entity.Ativo = true;
                await _context.Set<TModel>().AddAsync(entity);
                return await _context.SaveChangesAsync().ContinueWith(t => t.IsCompletedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao inserir {EntityType}", typeof(TModel).Name);
                return false;
            }
        }

        public async Task<IEnumerable<TModel>> GetByFilterAsync(TFilter filter)
        {
            throw new NotImplementedException("Método GetByFilterAsync não implementado para o repositório base. Deve ser implementado nas classes derivadas.");
        }

        public async Task<bool> UpdateAsync(TModel entity)
        {
            try
            {
                entity.DataAlteracao = DateTime.UtcNow;
                _context.Set<TModel>().Update(entity);
                return await _context.SaveChangesAsync().ContinueWith(t => t.IsCompletedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar {EntityType}", typeof(TModel).Name);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if(entity == null)
            {
                _logger.LogWarning("Tentativa de deletar {EntityType} com ID {Id} que não existe", typeof(TModel).Name, id);
                return false;
            }

            entity.Ativo = false;

            try
            {
                return await UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao remover {EntityType}", typeof(TModel).Name);
                return false;
            }
        }
    }
}