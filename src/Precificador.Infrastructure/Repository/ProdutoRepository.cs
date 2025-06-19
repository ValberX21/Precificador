using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Precificador.Domain.Entities;
using Precificador.Domain.Filters;
using Precificador.Domain.Repository;
using Precificador.Infrastructure.Data;
using Precificador.Infrastructure.Repository.Base;

namespace Precificador.Infrastructure.Repository
{
    public class ProdutoRepository(AppDbContext context, ILogger<Produto> logger) : CrudRepositoryBase<Produto, NomeFilter>(context, logger), IProdutoRepository
    {
        public override async Task<IEnumerable<Produto>?> GetByFilterAsync(NomeFilter filter)
        {
            try
            {
                var query = _context.Produtos.AsQueryable().Where(c => c.Ativo);

                if (filter != null && !string.IsNullOrEmpty(filter.Nome))
                {
                    query = query.Where(c => c.Nome.Contains(filter.Nome));
                }

                return await query.ToListAsync().ConfigureAwait(false);
            }
            catch (DbUpdateException ex)
            {
                LogErrorFetchingByFilter(_logger, typeof(Produto).Name, ex);
                return [];
            }
            catch (InvalidOperationException ex)
            {
                LogErrorFetchingByFilter(_logger, typeof(Produto).Name, ex);
                return [];
            }
            catch (Exception ex)
            {
                LogErrorFetchingByFilter(_logger, typeof(Produto).Name, ex);
                throw;
            }
        }
    }
}