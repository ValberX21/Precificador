using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Precificador.Domain.Entities;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;
using Precificador.Infrastructure.Data;
using Precificador.Infrastructure.Repository.Base;

namespace Precificador.Infrastructure.Repository
{
    public class GrupoRepository(AppDbContext context, ILogger<Grupo> logger) : CrudRepositoryBase<Grupo, NomeFilter>(context, logger), IGrupoRepository
    {
        public override async Task<IEnumerable<Grupo>> GetByFilterAsync(NomeFilter filter)
        {
            try
            {
                var query = _context.Grupos.AsQueryable().Where(c => c.Ativo);

                if (filter != null && !string.IsNullOrEmpty(filter.Nome))
                {
                    query = query.Where(c => c.Nome.Contains(filter.Nome));
                }

                return await query.ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar todos os registros de {EntityType}", typeof(Grupo).Name);
                return [];
            }
        }
    }
}